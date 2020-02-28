using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public static class CustomSelection
    {
        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> sources, Func<TSource, TResult> selector)
        {
            foreach (var employee in sources)
            {
                yield return selector(employee);
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource,TResult>(this IEnumerable<TSource> sources, Func<TSource, int, TResult> joeySelectWithIndex)
        {
            var index = 0;
            foreach (var source in sources)
            {
                yield return joeySelectWithIndex(source, index);
                index++;
            }
        }
    }
}