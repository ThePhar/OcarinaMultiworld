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
            // var players = new string[]
            // {
            //     "Phar",
            //     "Dorrie",
            //     "Saber",
            //     "Bliven",
            //     "Test",
            //     "Whatever",
            // };
            //
            // var server = new Server("127.0.0.1", 50000, players);
            // server.StartListener();

            var test1 = "cKnear,ae6faa3628e420aeb0acd51ce27fcf8269f484a2\n";
            var test2 = "lPhar,l:Cainsith:status:Unready,l:Cainsith:num:3,l:Knear:status:Unready,l:Knear:num:2,l:Phar:status:Unready,l:Phar:num:1\n";
            var test3 = "qPhar,q:";

            Console.WriteLine(test1);
            Console.WriteLine(new Message(test1));

            Console.WriteLine();
            
            Console.WriteLine(test2);
            Console.WriteLine(new Message(test2));
            
            Console.WriteLine();
            
            Console.WriteLine(test3);
            Console.WriteLine(new Message(test3));

        }

        public static void WriteToFile(string data)
        {
            // var path = Path.GetFullPath(Path.Combine("log", "log.txt"));
            //
            // _lock.EnterWriteLock();
            // try
            // {
            //     using var fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            //     
            //     var byteData = Encoding.ASCII.GetBytes(data);
            //     fs.Write(byteData, 0, byteData.Length);
            // }
            // finally
            // {
            //     _lock.ExitWriteLock();
            // }
        }
    }
}
