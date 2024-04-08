using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src == null)
            {
                return;
            }

            foreach (T item in src)
            {
                action(item);
            }
        }

    }
}
