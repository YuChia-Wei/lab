﻿using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyOrderByTests
    {
        [Test]
        public void orderBy_lastName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastName(employees);

            var expected = new[]
            {
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_and_FirstName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastNameAndFirstName(employees, new ComboComparer(new CombineKeyComparer(employee => employee.LastName, Comparer<string>.Default), new CombineKeyComparer(employee1 => employee1.FirstName, Comparer<string>.Default)));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyOrderByLastNameAndFirstName(
            IEnumerable<Employee> employees, ComboComparer comboComparer)
        {
            //Selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var employee = elements[i];
                    var finalCompareResult = FinalCompareResult(comboComparer, employee, minElement);

                    if (finalCompareResult < 0)
                    {
                        minElement = employee;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        private static int FinalCompareResult(ComboComparer comboComparer, Employee employee, Employee minElement)
        {
            var firstCompareResult = comboComparer.FirstCombineKeyComparer.Compare(employee, minElement);
            var secondCompareResult = comboComparer.SecondCombineKeyComparer.Compare(employee, minElement);

            var finalCompareResult = firstCompareResult;

            if (firstCompareResult < 0)
            {
                //minElement = employee;
                //index = i;
            }
            else if (firstCompareResult == 0)
            {
                finalCompareResult = secondCompareResult;
            }

            return finalCompareResult;
        }

        private IEnumerable<Employee> JoeyOrderByLastName(IEnumerable<Employee> employees)
        {
            //Selection sort
            var stringComparer = Comparer<string>.Default;
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (stringComparer.Compare(elements[i].LastName, minElement.LastName) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }
}