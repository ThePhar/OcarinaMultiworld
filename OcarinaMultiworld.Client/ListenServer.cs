using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OcarinaMultiworld.Client
{
    public class ListenServer
    {
        private readonly TcpListener _server;
        private          TcpClient   _client;
        public           ListenState State = ListenState.NotRunning;

        public ListenServer(string ip, int port)
        {
            var localAddr = IPAddress.Parse(ip);
            _server = new TcpListener(localAddr, port);
            _server.Start();
        }

        public void StartListener()
        {
            try
            {
                while (true)
                {
                    if (_client != null && _client.Connected) 
                        continue;
                    
                    State = ListenState.Initializing;
                    
                    Console.WriteLine("Waiting for connection from ootr-bridge.lua");
                    _client = _server.AcceptTcpClient();
                    Console.WriteLine("Connected to ootr-bridge.lua ...");

                    State = ListenState.Ready;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"Socket Exception: {e}");
                State = ListenState.Closed;
                _server.Stop();
            }
        }

        public byte[] ReadFromMemory(uint address, uint bytes = 1)
        {
            var str = $"read,{address},{bytes}\n";
            var message = Encoding.ASCII.GetBytes(str);

            return SendMessage(message);
        }

        public byte[] WriteToMemory(uint address, byte[] bytes)
        {
            var str = $"write,{address},{string.Join(",", bytes)}\n";
            var message = Encoding.ASCII.GetBytes(str);

            return SendMessage(message);
        }

        private byte[] SendMessage(byte[] message)
        {
            // Block until state is ready.
            while (State != ListenState.Ready) { }

            if (_client == null || !_client.Connected)
                throw new IOException("No connection to ootr-bridge.lua could be found.");

            State = ListenState.Busy;

            var stream = _client.GetStream();
            stream.ReadTimeout = 5000;

            try
            {
                var buffer = new byte[512];
                var response = "";

                stream.Write(message, 0, message.Length);

                int i;
                while (!response.EndsWith("\n") && (i = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    response += Encoding.ASCII.GetString(buffer, 0, i);
                }

                if (!response.EndsWith("\n"))
                    throw new Exception("Invalid response from bridge script.");

                return JsonConvert.DeserializeObject<byte[]>(response);
            }
            catch (IOException)
            {
                Console.WriteLine("Connection to ootr-bridge.lua timed out ...");
                _client.Close();
                State = ListenState.NotRunning;

                return Array.Empty<byte>();
            }
            catch
            {
                Console.Write($"Exception occured while sending message: {Encoding.ASCII.GetString(message)}");
                _client.Close();
                State = ListenState.NotRunning;

                throw;
            }
            finally
            {
                State = ListenState.Ready;
            }
        }
    }
}
