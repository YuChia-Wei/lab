using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public static partial class LinqExtensions
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