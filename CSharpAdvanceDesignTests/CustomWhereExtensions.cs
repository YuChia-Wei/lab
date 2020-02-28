using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public static class CustomWhereExtensions
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> sources, Func<TSource, bool> validFunc)
        {
            var result = new List<TSource>();

            foreach (var item in sources)
            {
                if (validFunc(item))
                    result.Add(item);
            }

            return result;
        }

        public static List<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> sources, Func<TSource, int, bool> prediGate)
        {
            var index = 0;
            var result = new List<TSource>();
            foreach (var item in sources)
            {
                if (prediGate(item, index))
                    result.Add(item);

                index++;
            }

            return result;
        }
    }
}