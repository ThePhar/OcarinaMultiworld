using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcarinaMultiworld.Server
{
    public record Message
    {
        public const string ServerName = "OcarinaMultiworld";
        
        public MessageType Type   { get; private init; }
        public string      Sender { get; private init; }
        public MessageData Data   { get; private init; }

        private Message() { }

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
        }

        public override string ToString()
        {
            if (Data != null)
            {
                return $"{MessageTypeToCharacter(Type)}{Sender},{Data}\n";
            }
            
            return $"{MessageTypeToCharacter(Type)}{Sender},\n";
        }

        public static Message Ping()
        {
            return new() { Type = MessageType.Ping, Sender = ServerName };
        }

        public static Message ServerNumber()
        {
            return new()
            {
                Type = MessageType.PlayerNumber,
                Sender = ServerName,
                Data = new MessageData(new []{ ServerName, "-1" }),
            };
        }

        public static Message PlayerNumber(Player player)
        {
            return new()
            {
                Type = MessageType.RamEvent, // ¯\_(ツ)_/¯
                Sender = player.Name,
                Data = new MessageData(new []{ $"n:{player.Id}" }),
            };
        }

        public static Message PlayerList(IDictionary<string, Player> players)
        {
            var list = new StringBuilder();

            foreach (var (_, player) in players)
            {
                var ready = player.Active ? "Ready" : "Unready";
                list.Append($"l:{player.Name}:status:{ready},l:{player.Name}:num:{player.Id},");
            }

            list.Remove(list.Length - 1, 1);

            return new()
            {
                Type = MessageType.PlayerList,
                Sender = ServerName,
                Data = new MessageData(list.ToString().Split(",")),
            };
        }
        
        // Still not quite sure what this is used for, but it's required as far as I can tell during connection sequence.
        public static Message InitialRamEvent()
        {
            return new()
            {
                Type = MessageType.RamEvent,
                Sender = ServerName,
                Data = new MessageData(new[] { "i:0:1" }),
            };
        }

        public static Message Error()
        {
            return new()
            {
                Type = MessageType.Error,
                Sender = ServerName,
            };
        }

        public static Message Config(string hash, int count)
        {
            return new()
            {
                Type = MessageType.Config,
                Sender = ServerName,
                Data = new MessageData(new[] { hash, $"{count}" }),
            };
        }

        public static Message Status(Player player, bool ready)
        {
            return new()
            {
                Type = MessageType.PlayerStatus,
                Sender = ServerName,
                Data = new MessageData(new[] { player.Name, ready ? "Ready" : "Unready" }),
            };
        }

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
