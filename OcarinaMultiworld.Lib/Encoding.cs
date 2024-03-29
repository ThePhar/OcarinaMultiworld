﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    >= 0xAB and <= 0xC4 => (char) (b - 0x6A), // A - Z
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
                for (var i = limit - bytes.Count; i > 0; i--)
                    bytes.Add(0xDF);
            }

            return bytes.ToArray();
        }

        // Shamelessly stolen (and modified) from https://stackoverflow.com/a/16932448/8891387
        public static string PropertyList(this object obj, int indent = 0)
        {
            var props = obj.GetType().GetProperties();
            var sb = new StringBuilder();

            sb.Append('\n');
            
            foreach (var p in props)
            {
                var tabs = string.Concat(Enumerable.Repeat("\t", indent));
                sb.AppendLine(tabs + p.Name + ": " + p.GetValue(obj, null));
            }

            return sb.ToString();
        }
    }
}
