using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcarinaMultiworld.Server
{
    public record Message
    {
        public MessageType Type   { get; private init; }
        public string      Sender { get; private init; }
        public MessageData Data   { get; private init; }

        private string _raw;
        public string Raw
        {
            get
            {
                if (_raw != null)
                    return _raw;

                return ToString();
            }
        }

        public static readonly string ServerName = "OcarinaMultiworld";

        public Message(string rawMessage)
        {
            // Remove the first character which denotes the type of message and trim message of extra spaces and newlines.
            var data = rawMessage.Substring(1).Trim(); 
            // Split into array of characters.
            var parameters = data.Split(",");
            
            Type = CharacterToMessageType(rawMessage[0]);
            Sender = parameters[0];

            if (parameters.TryGetValue(out _, 1))
            {
                // Skip the first element, since that's our sender's name.
                Data = new MessageData(parameters.Skip(1));
            }

            _raw = rawMessage;
        }
        
        private Message() { }

        public override string ToString() => Data != null 
                ? $"{MessageTypeToCharacter(Type)}{Sender},{Data}\n"
                : $"{MessageTypeToCharacter(Type)}{Sender},\n";

        public static Message Ping => new Message
        {
            Type = MessageType.Ping,
            Sender = ServerName,
        };
        
        public static Message ServerNumber => new Message
        {
            Type = MessageType.PlayerNumber,
            Sender = ServerName,
            Data = new MessageData(new[] { ServerName, "-1" }),
        };
        
        public static Message PlayerNumber(Player player) => new Message
        {
            Type = MessageType.RamEvent,
            Sender = player.Name,
            Data = new MessageData(new[] { $"n:{player.Id}" }),
        };

        public static string PlayerList(IDictionary<string, Player> players)
        {
            var list = new StringBuilder();

            foreach (var (_, player) in players)
            {
                var ready = player.Active ? "Ready" : "Unready";
                list.Append($"l:{player.Name}:status:{ready},l:{player.Name}:num:{player.Id},");
            }

            list.Remove(list.Length - 1, 1);

            return list.ToString();
        }
        
        // Still not quite sure what this is used for???
        public static Message InitialRamEvent => new Message
        {
            Type = MessageType.RamEvent,
            Sender = ServerName,
            Data = new MessageData(new[] { "i:0:1" }),
        };
        
        public static Message Error => new Message
        {
            Type = MessageType.Error,
            Sender = ServerName,
        };
        
        public static Message Config(string hash, int count) => new Message
        {
            Type = MessageType.Config,
            Sender = ServerName,
            Data = new MessageData(new[] { hash, count.ToString() }),
        };

        private static MessageType CharacterToMessageType(char character)
        {
            return character switch
            {
                'm' => MessageType.Memory,
                'c' => MessageType.Config,
                'p' => MessageType.Ping,
                'q' => MessageType.Quit,
                'r' => MessageType.RamEvent,
                'n' => MessageType.PlayerNumber,
                'l' => MessageType.PlayerList,
                'k' => MessageType.KickPlayer,
                's' => MessageType.PlayerStatus,
                'e' => MessageType.Error,
                _   => throw new NotImplementedException($"Char {character} is not implemented."),
            };
        }
        
        private static char MessageTypeToCharacter(MessageType type)
        {
            return type switch
            {
                MessageType.Memory       => 'm',
                MessageType.Config       => 'c',
                MessageType.Ping         => 'p',
                MessageType.Quit         => 'q',
                MessageType.RamEvent     => 'r',
                MessageType.PlayerNumber => 'n',
                MessageType.PlayerList   => 'l',
                MessageType.KickPlayer   => 'k',
                MessageType.PlayerStatus => 's',
                MessageType.Error        => 'e',
                _                        => throw new NotImplementedException($"MessageType {type} is not implemented."),
            };
        }
    }
}
