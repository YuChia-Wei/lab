using System;
using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> sources, Func<TSource, int, TResult> joeySelectWithIndex)
        {
            var index = 0;
            foreach (var source in sources)
            {
                yield return joeySelectWithIndex(source, index);
                index++;
            }
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> validFunc)
        {
            var result = new List<TSource>();

            foreach (var item in sources)
            {
                if (validFunc(item))
                    result.Add(item);
            }

            return result;
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> sources, Func<TSource, int, bool> prediGate)
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

        public static bool JoeyAll<TSource>(this IEnumerable<TSource> girls, Func<TSource, bool> predicate)
        {
            var enumerator = girls.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!predicate(current))
                {
                    return false;
                }
            }

            return true;
        }

        public static TSource JoeyFirst<TSource>(this IEnumerable<TSource> sources)
        {
            var enumerator = sources.GetEnumerator();

            return enumerator.MoveNext()
                ? enumerator.Current
                : throw new InvalidOperationException($"{nameof(sources)} is Empty.");
        }

        public static TSource JoeyFirst<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            var enumerator = sources.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return current;
                }
            }

            throw new InvalidOperationException($"{nameof(sources)} is Empty.");
        }

        public static TSource JoeyLast<TSource>(this IEnumerable<TSource> employees, Func<TSource, bool> predicate)
        {
            return employees.JoeyWhere(predicate).JoeyLast();
        }

        public static TSource JoeyLast<TSource>(this IEnumerable<TSource> sources)
        {
            var enumerator = sources.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException($"{nameof(sources)} is Not Found.");
            }

            var current = enumerator.Current;

            while (enumerator.MoveNext())
            {
                current = enumerator.Current;
            }

            return current;

            //這種方法當出現型別內容就是 null 的時候，會出現問題
            //因為我們現在就是要取得 "最後" 一個
            //Employee current = null;
            //while (enumerator.MoveNext())
            //{
            //    current = enumerator.Current;
            //}

            //return current ?? throw new InvalidOperationException($"{nameof(sources)} is Empty.");
        }

        public static IEnumerable<Employee> JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            return employees;
        }

        public static IEnumerable<Employee> JoeyThenBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            return employees;
        }
    }
}