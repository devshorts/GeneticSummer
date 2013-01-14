using System;
using System.Collections.Generic;

namespace Evolve.Common
{
    public static class ListUtil
    {
        private static Random Random = new Random();

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int index = list.Count;
            while (index > 1)
            {
                index--;
                int k = Random.Next(index + 1);
                T value = list[k];
                list[k] = list[index];
                list[index] = value;
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
