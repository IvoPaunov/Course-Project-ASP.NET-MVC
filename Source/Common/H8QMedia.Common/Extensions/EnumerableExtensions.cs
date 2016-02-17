namespace H8QMedia.Common.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        //public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        action(item);
        //    }
        //}

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }

            return null;
        }
    }
}
