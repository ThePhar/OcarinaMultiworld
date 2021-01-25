using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace OcarinaMultiworld.Server
{
    public static class Extensions
    {
        public static bool TryGetValue<TItem>(this IList<TItem> list, out TItem item, int index)
        {
            try
            {
                item = list[index];
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(TItem);
                return false;
            }
        }
    }
}
