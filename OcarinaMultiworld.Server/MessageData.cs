using System.Collections.Generic;
using System.Text;

namespace OcarinaMultiworld.Server
{
    public class MessageData : Dictionary<string, object>
    {
        private MessageData() { }
        
        public MessageData(IEnumerable<string> table)
        {
            var entry = this;

            foreach (var evt in table)
            {
                var evtSplit = evt.Split(":");

                var depth = 0;
                var entryDive = entry;
                while (evtSplit.TryGetValue(out _, depth + 2))
                {
                    if (!entryDive.ContainsKey(evtSplit[depth]))
                        entryDive.Add(evtSplit[depth], new MessageData());

                    entryDive = (MessageData) entryDive[evtSplit[depth]];
                    depth += 1;
                }

                if (evtSplit.TryGetValue(out var e1, depth) && evtSplit.TryGetValue(out var e2, depth + 1))
                    entryDive[e1] = e2;
                else
                    entryDive.Add(entryDive.Count.ToString(), evt);
            }
        }
        
        public override string ToString() => DataToString(this);

        private static string DataToString(object data, string header = "")
        {
            var builder = new StringBuilder();

            if (data is MessageData entry)
            {
                foreach (var (key, value) in entry)
                {
                    switch (header)
                    {
                        case "" when int.TryParse(key, out _):
                            builder.Append(value + ",");
                            break;

                        case "":
                            builder.Append(DataToString(value, key) + ",");
                            break;

                        default:
                            builder.Append(DataToString(value, $"{header}:{key}") + ",");
                            break;
                    }
                }

                builder.Remove(builder.Length - 1, 1);
            }
            else if (header != "")
            {
                builder.Append($"{header}:{data}");
            }
            else
            {
                builder.Append($"{data}");
            }

            return builder.ToString();
        }
    }
}
