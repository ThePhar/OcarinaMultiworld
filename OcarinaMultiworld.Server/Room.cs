using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace OcarinaMultiworld.Server
{
    public class Room
    {
        private const int TimeoutPeriod = 60 * 1000; // 60 Seconds.

        private readonly TcpListener _server;
        private readonly Dictionary<string, Player> _players = new();

        public Room(string ip, int port, IEnumerable<string> players)
        {
            var addr = IPAddress.Parse(ip);
            _server = new TcpListener(addr, port);
            _server.Start();

            foreach (var player in players)
            {
                _players.Add(player, new Player(player, _players.Count + 1));
            }
            
            // TODO: Remove these bugs.
            Message[] messages = new[]
            {
                new Message("sOcarinaMultiworld,Billyum,Ready\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:187,m:0:t:1,m:0:k:2621696,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:138,m:0:t:4,m:0:k:2621697,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:184,m:0:t:2,m:0:k:2621699,m:0:f:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:132,m:0:t:2,m:0:k:2621698,m:0:f:6\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:72,m:0:t:2,m:0:k:5570816,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:4,m:0:k:16712962,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("sOcarinaMultiworld,Billyum,Ready\n"),
                new Message("sOcarinaMultiworld,Billyum,Ready\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:7,m:0:k:2621698,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:62,m:0:t:7,m:0:k:2621696,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rPhar,m:0:i:189,m:0:t:6,m:0:k:2621699,m:0:f:1\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:75,m:0:t:8,m:0:k:4325472,m:0:f:6\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rPhar,m:0:i:1,m:0:t:6,m:0:k:5570816,m:0:f:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:2,m:0:k:2883636,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:78,m:0:t:2,m:0:k:3473470,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:259,m:0:f:1\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:61,m:0:t:8,m:0:k:259,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rPhar,m:0:i:44,m:0:t:5,m:0:k:16712962,m:0:f:1\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:134,m:0:t:5,m:0:k:261,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:102,m:0:t:1,m:0:k:257,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:1,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rPhar,m:0:i:74,m:0:t:7,m:0:k:5373967,m:0:f:1\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:46,m:0:t:7,m:0:k:258,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:1,m:0:k:262,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:2,c:t:1\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:2,c:f:6:1,c:t:6\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rPhar,m:0:i:76,m:0:t:6,m:0:k:4063496,m:0:f:1\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:62,m:0:t:4,m:0:k:260,m:0:f:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,m:0:i:86,m:0:t:8,m:0:k:3604993,m:0:f:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:71,m:0:t:2,m:0:k:1114191,m:0:f:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:124,m:0:t:4,m:0:k:5963895,m:0:f:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("sOcarinaMultiworld,Phar,Ready\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,m:0:i:78,m:0:t:8,m:0:k:5374014,m:0:f:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rPhar,n:1\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,m:0:i:128,m:0:t:2,m:0:k:6225991,m:0:f:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("sOcarinaMultiworld,Saber,Unready\n"),
                new Message("sOcarinaMultiworld,Saber,Unready\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,m:0:i:61,m:0:t:8,m:0:k:6225991,m:0:f:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("sOcarinaMultiworld,Billyum,Ready\n"),
                new Message("sOcarinaMultiworld,Billyum,Ready\n"),
                new Message("sOcarinaMultiworld,Billyum,Ready\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rBillyum,n:6\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("sOcarinaMultiworld,Saber,Ready\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rSaber,n:3\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rPhar,c:f:1:1,c:f:6:3,c:t:1\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rSaber,c:f:3:1,c:t:3\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("rBillyum,c:f:1:3,c:f:6:1,c:t:6\n"),
                new Message("sOcarinaMultiworld,Saber,Unready\n"),
                new Message("sOcarinaMultiworld,Saber,Unready\n"),
            };

            Message lastMessage = null;
            foreach (var message in messages)
            {
                if (lastMessage != null && lastMessage.ToString() == message.ToString())
                    continue;

                lastMessage = message;
                
                _players["Dorian"].Enqueue(message);
                _players["Bliven"].Enqueue(message);
                _players["Jaxus"].Enqueue(message);
                _players["Mike"].Enqueue(message);
                _players["David"].Enqueue(message);
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

        private void HandleClient(object obj)
        {
            var client = (TcpClient) obj;
            var stream = client.GetStream();

            // Set timeouts.
            stream.ReadTimeout = TimeoutPeriod;
            stream.WriteTimeout = TimeoutPeriod;
            
            // Initial player object.
            var player = new Player("Unknown", -1, client);
            Player roomPlayer = null;

            try
            {
                // Startup sequence.
                var initializing = true;
                while (initializing)
                {
                    var message = player.Read();

                    switch (message.Type)
                    {
                        case MessageType.Ping:
                            player.Send(Message.Ping());
                            break;
                        
                        case MessageType.Config:
                            if (_players.TryGetValue(message.Sender, out roomPlayer))
                            {
                                player.Send(Message.Config(message.Data["0"].ToString(), _players.Count));
                                break;
                            }
                            
                            player.Error();
                            initializing = false;
                            break;

                        case MessageType.PlayerNumber:
                            if (roomPlayer != null)
                            {
                                player.Send(Message.ServerNumber());
                                player.Send(Message.InitialRamEvent());
                                player.Send(Message.PlayerList(_players));

                                // Send player numbers.
                                foreach (var (_, other) in _players)
                                {
                                    player.Send(Message.PlayerNumber(other));
                                }

                                // Tell everyone this player is ready.
                                roomPlayer.Ready(client);
                                foreach (var (_, other) in _players)
                                {
                                    if (other.Active)
                                        other.Enqueue(Message.Status(roomPlayer, true));
                                }

                                player = roomPlayer;
                                initializing = false;
                                break;
                            }

                            player.Error();
                            initializing = false;
                            break;
                    }
                }

                // Normal event loop.
                while (client.Connected)
                {
                    // Wait for messages.
                    var message = player.Read();
                    switch (message.Type)
                    {
                        // Send queue 100 events to prevent timeout every ping.
                        case MessageType.Ping:
                            player.Send(Message.Ping());
                            player.SendQueue(100);
                            break;

                        case MessageType.Quit:
                            player.Disconnect();

                            foreach (var (_, other) in _players)
                            {
                                if (other.Active)
                                    other.Enqueue(Message.Status(player, false));
                            }

                            break;

                        // Ignore these event types.
                        case MessageType.Config:
                        case MessageType.Error:
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

                    // TODO: Remove this debug message when I'm ready to publish.
                    PrintRoomInformation(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                try
                {
                    player.Error();
                }
                catch
                {
                    // ignored
                }
            }
            finally
            {
                client.Close();
            }
        }

        private void PrintRoomInformation(Message message)
        {
            Console.Clear();

            Console.WriteLine($"Received {message.Type} Message from {message.Sender}.");
            Console.WriteLine($"Raw: {message}");

            foreach (var (_, p) in _players)
            {
                Console.WriteLine($"Player: {p.Name}");
                Console.WriteLine($"Number: {p.Id}");
                Console.WriteLine($"Queued: {p.Queued}");
                Console.WriteLine($"Active: {p.Active}\n");
            }
        }
    }
}
