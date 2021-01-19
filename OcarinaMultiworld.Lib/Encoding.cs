using System.Collections.Generic;

namespace OcarinaMultiworld.Lib
{
    public static class Encoding
    {
        public static string ConvertToAscii(this byte[] bytes)
        {
            var text = "";

            foreach (var b in bytes)
            {
                text += b switch
                {
                    <= 0x09             => (char) (b + 0x30), // 0 - 9
                    >= 0xAB and <= 0xC3 => (char) (b - 0x6A), // A - Z
                    >= 0xC5 and <= 0xDE => (char) (b - 0x64), // a - z
                    0xEA                => ".",
                    0xE4                => "-",
                    _                   => " ",
                };
            }

            return text.TrimEnd();
        }

        public static byte[] ConvertToOot(this string text, int limit = 8, bool fillEndOfLine = true)
        {
            List<byte> bytes = new();

            if (text.Length > limit)
                text = text.Substring(0, limit);

            foreach (var c in text)
            {
                var code = (byte) c;

                switch (code)
                {
                    // 0 to 9
                    case >= 0x30 and <= 0x39:
                        bytes.Add((byte) (code - 0x30));
                        break;

                    // A - Z
                    case >= 0x41 and <= 0x5A:
                        bytes.Add((byte) (code + 0x6A));
                        break;

                    // a - z
                    case >= 0x61 and <= 0x7A:
                        bytes.Add((byte) (code + 0x64));
                        break;

                    // .
                    case 0x2E:
                        bytes.Add(0xEA);
                        break;

                    // -
                    case 0x2D:
                        bytes.Add(0xE4);
                        break;

                    default:
                        bytes.Add(0xDF);
                        break;
                }
            }

            if (fillEndOfLine)
            {
                for (var i = limit - bytes.Count; i < limit; i++)
                    bytes.Add(0xDF);
            }

            return bytes.ToArray();
        }
    }
}
