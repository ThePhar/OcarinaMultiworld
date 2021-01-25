using Newtonsoft.Json;
using OcarinaMultiworld.Lib;
using System;
using System.IO;
using System.Text;
using System.Threading;
using Encoding = System.Text.Encoding;

namespace OcarinaMultiworld.Server
{
    internal static class Program
    {
        private static ReaderWriterLockSlim _lock = new();
        
        public static void Main(string[] args)
        {
            var players = new string[]
            {
                "Phar",
                "Dorian",
                "Saber",
                "Bliven",
                "Jaxus",
                "Billyum",
                "Mike",
                "David",
            };
            
            
            
            var server = new Room("74.91.122.225", 50000, players);
            server.StartListener();

        }

        public static void WriteToFile(string data)
        {
            var path = Path.GetFullPath(Path.Combine("log", "log.txt"));
            
            _lock.EnterWriteLock();
            try
            {
                using var fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                
                var byteData = Encoding.ASCII.GetBytes(data);
                fs.Write(byteData, 0, byteData.Length);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
