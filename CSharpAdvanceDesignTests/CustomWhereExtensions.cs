using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public class CustomWhereExtensions
    {
        public static List<TSource> JoeyWhere<TSource>(List<TSource> sources, Func<TSource, bool> validFunc)
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