using Alba.CsConsoleFormat;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace OcarinaMultiworld.Server
{
    public class Server
    {
        private readonly TcpListener   _server;
        private readonly Dictionary<string, Player> _players = new();

        public Server(string ip, int port, IEnumerable<string> players)
        {
            var addr = IPAddress.Parse(ip);
            _server = new TcpListener(addr, port);
            _server.Start();

            foreach (var player in players)
            {
                _players.Add(player, new Player(player, _players.Count + 1));
            }
        }

        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for connections...");
                    var client = _server.AcceptTcpClient();

                    Console.WriteLine("A client has connected!");
                    var thread = new Thread(HandleClient);
                    thread.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
                _server.Stop();
            }
        }

        public void HandleClient(object obj)
        {
            var client = (TcpClient) obj;

            try
            {
                
                
                while (true)
                {
                    Console.Clear();

                    foreach (var (_, p) in _players)
                    {
                        Console.WriteLine($"Player: {p.Name}");
                        Console.WriteLine($"Number: {p.Id}");
                        Console.WriteLine($"Queued: {p.Queued}\n");
                        Console.WriteLine($"Active: {p.Active}\n");
                    }
                    
                    var message = AwaitMessage(client);
                    var breakLoop = false;

                    // Valid player.
                    if (_players.TryGetValue(message.Sender, out var player))
                    {
                        switch (message.Type)
                        {
                            case MessageType.Config:
                                if (player.TryConnect(client))
                                    SendMessage(client, $"c{Message.ServerName},{message.Data["0"]},{_players.Count}\n");

                                break;

                            case MessageType.Ping:
                                SendMessage(client, $"{ Message.Ping }");
                                player.SendQueue(100);
                                break;

                            case MessageType.Quit:
                                breakLoop = true;
                                client.Close();

                                foreach (var (_, other) in _players)
                                {
                                    if (other.Active)
                                        other.Enqueue(new Message($"s{player.Name},{player.Name},Unready\n"));
                                }
                                
                                break;

                            case MessageType.PlayerNumber:
                                SendMessage(client, $"n{Message.ServerName},{Message.ServerName},-1\n");

                                SendMessage(client, $"{ Message.InitialRamEvent }");
                                
                                SendMessage(client, $"l{Message.ServerName},{Message.PlayerList(_players)}\n");

                                // Send every player's number.
                                foreach (var (_, other) in _players)
                                {
                                    SendMessage(client, $"{ Message.PlayerNumber(other) }");
                                    
                                    if (other.Active)
                                        other.Enqueue(new Message($"s{player.Name},{player.Name},Ready\n"));
                                }
                                
                                
                                break;

                            // Ignore
                            case MessageType.PlayerList:
                            case MessageType.PlayerStatus:
                                break;

                            // Forward Events
                            default:
                                foreach (var (_, other) in _players)
                                {
                                    if (other.Name == player.Name) 
                                        continue;
                                    
                                    other.Enqueue(message);
                                }
                                
                                break;
                        }

                        if (breakLoop) break;
                    }

                    // Invalid player.
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                client.ErrorAndClose();
            }
            finally
            {
                client.Close();
                
                Console.Clear();

                foreach (var (_, p) in _players)
                {
                    Console.WriteLine($"Player: {p.Name}");
                    Console.WriteLine($"Number: {p.Id}");
                    Console.WriteLine($"Queued: {p.Queued}");
                    Console.WriteLine($"Active: {p.Active}\n");
                }
            }
        }

        private void SendMessage(TcpClient client, string message)
        {
            var stream = client.GetStream();
            stream.WriteTimeout = 3000; // 3 seconds.
            stream.Write(Encoding.ASCII.GetBytes(message));
        }

        private Message AwaitMessage(TcpClient client)
        {
            var stream = client.GetStream();
            stream.ReadTimeout = 10000; // 10 seconds.
            
            var request = "";
            var buffer = new byte[512];

            int i;
            while (!request.EndsWith("\n") && (i = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                request += Encoding.ASCII.GetString(buffer, 0, i);
            }
                
            if (!request.EndsWith("\n"))
                throw new Exception("Invalid request from client.");

            Console.WriteLine(request);
            
            return new Message(request);
        }
    }
}
