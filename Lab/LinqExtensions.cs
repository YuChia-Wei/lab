using System;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public static class LinqExtensions
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

        public static IEnumerable<TSource> JoeyTake<TSource>(this IEnumerable<TSource> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index < count)
                {
                    yield return enumerator.Current;
                }
                else
                {
                    break;
                }

                index++;
            }
        }

        public static IEnumerable<Employee> JoeySkip(this IEnumerable<Employee> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index >= count)
                {
                    yield return enumerator.Current;
                }

                index++;
            }
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> numbers, Func<TSource, bool> predicate)
        {
            var enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> employees)
        {
            return employees.GetEnumerator().MoveNext();
        }
    }
}