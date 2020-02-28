using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeySelectTests
    {
        [Test]
        public void append_port_9191_to_urls()
        {
            var urls = GetUrls();

            var actual = JoeySelect(urls, s => $"{s}:9191");
            var expected = new List<string>
            {
                "http://tw.yahoo.com:9191",
                "https://facebook.com:9191",
                "https://twitter.com:9191",
                "http://github.com:9191",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void replace_http_to_https()
        {
            var urls = GetUrls();

            Func<string, string> selector = url => url.Replace("http:", "https:");
            var actual = JoeySelect(urls, selector);
            var expected = new List<string>
            {
                "https://tw.yahoo.com",
                "https://facebook.com",
                "https://twitter.com",
                "https://github.com",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void select_full_name()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };

            var joeySelectForEmployee = JoeySelect(employees, e => $"{e.FirstName} {e.LastName}");

            var expected = new[]
            {
                "Joey Chen",
                "Tom Li",
                "David Chen"
            };

            expected.ToExpectedObject().ShouldMatch(joeySelectForEmployee);
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
        }

        private static IEnumerable<string> GetUrls()
        {
            yield return "http://tw.yahoo.com";
            yield return "https://facebook.com";
            yield return "https://twitter.com";
            yield return "http://github.com";
        }

        private IEnumerable<TResult> JoeySelect<TSource, TResult>(IEnumerable<TSource> sources, Func<TSource, TResult> selector)
        {
            foreach (var employee in sources)
            {
                yield return selector(employee);
            }
        }
    }
}