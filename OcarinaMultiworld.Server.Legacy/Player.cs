using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace OcarinaMultiworld.Server
{
    public class Player
    {
        public string Name { get; }
        public int    Id   { get; }

        public bool Active => _socket != null && _socket.Connected;
        public int  Queued => _queue.Count;
        
        public Player(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public Player(string name, int id, TcpClient socket)
        {
            Name = name;
            Id = id;
            _socket = socket;
        }

        public void Enqueue(Message message)
        {
            if (message != null)
            {
                _queue.Enqueue(message);
                Program.WriteToFile(message.ToString());
            }
        }

        public void SendQueue(int max = int.MaxValue)
        {
            var sentMessages = 0;
            while (!_queue.IsEmpty && Active && sentMessages < max)
            {
                try
                {
                    // Peek, in-case we lose connection while attempting to send a message.
                    if (_queue.TryPeek(out var message))
                    {
                        Send(message);

                        // Successfully wrote message to client. Go ahead and dequeue it now.
                        _queue.TryDequeue(out _);
                        sentMessages++;
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine($"({Id}) {Name} has lost connection while attempting to receive queued message.");
                    _socket.Close();
                }
            }
        }

        public bool Ready(TcpClient client)
        {
            if (Active)
            {
                client.Close();
                return false;
            }

            _socket = client;
            return true;
        }

        public void Error()
        {
            Send(Message.Error());
            Disconnect();
        }
        
        public void Disconnect()
        {
            _socket?.Close();
        }

        public void Send(Message message)
        {
            var stream = _socket.GetStream();
            stream.Write(Encoding.ASCII.GetBytes(message.ToString()));
        }

        public Message Read()
        {
            var stream = _socket.GetStream();
            
            var request = "";
            var buffer = new byte[512];

            int i;
            while (!request.EndsWith("\n") && (i = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                request += Encoding.ASCII.GetString(buffer, 0, i);
            }

            if (!request.EndsWith("\n"))
                throw new IOException("Invalid request from client.");

            return new Message(request);
        }

        private readonly ConcurrentQueue<Message> _queue = new();
        private          TcpClient                _socket;
    }
}
