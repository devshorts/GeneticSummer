using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve
{
    public static class ListUtil
    {
        private static Random rng = new Random();

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var t in list)
            {
                action(t);
            }   
        }
    }
}
