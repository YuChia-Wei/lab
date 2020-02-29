using System;
using System.Collections.Generic;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyLastTest
    {
        [Test]
        public void get_last_employee()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"},
            };

            var employee = JoeyLast(employees);

            new Employee { FirstName = "Cash", LastName = "Li" }
                .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_last_employee_when_no_employee()
        {
            var employees = new Employee[]
            {
            };

            TestDelegate action = () => JoeyLast(employees);
            Assert.Throws<InvalidOperationException>(action);
        }

        private Employee JoeyLast(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException($"{nameof(employees)} is Empty.");
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

            //return current ?? throw new InvalidOperationException($"{nameof(employees)} is Empty.");
        }
    }
}