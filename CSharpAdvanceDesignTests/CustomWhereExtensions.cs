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
    }
}