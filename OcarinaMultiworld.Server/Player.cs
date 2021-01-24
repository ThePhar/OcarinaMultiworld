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

        public void Enqueue(Message message)
        {
            if (message != null)
            {
                _queue.Enqueue(message);
                Program.WriteToFile(message.Raw);
            }
        }
        
        public void SendQueue(int max = int.MaxValue)
        {
            var sentMessages = 0;
            while (!_queue.IsEmpty && Active && sentMessages < max)
            {
                var stream = _socket.GetStream();
                stream.WriteTimeout = 3000;

                try
                {
                    // Peek, in-case we lose connection while attempting to send a message.
                    if (_queue.TryPeek(out var message))
                    {
                        var bytes = Encoding.ASCII.GetBytes(message.Raw);
                        stream.Write(bytes, 0, bytes.Length);
                        
                        // Successfully wrote message to client. Go ahead and dequeue it now.
                        _queue.TryDequeue(out _);
                        sentMessages++;
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"({Id}) {Name} has lost connection while attempting to receive queued message.");
                    _socket.Close();
                }
            }
        }

        public bool TryConnect(TcpClient client)
        {
            if (Active)
            {
                client.ErrorAndClose();
                return false;
            }
            
            _socket = client;
            return true;
        }

        private readonly ConcurrentQueue<Message> _queue = new();
        private          TcpClient                _socket;
    }
}
