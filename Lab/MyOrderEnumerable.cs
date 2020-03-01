﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public class MyOrderEnumerable : IEnumerable<Employee>
    {
        private readonly IEnumerable<Employee> _employees;
        private IComparer<Employee> _combineKeyComparer;

        public MyOrderEnumerable(IEnumerable<Employee> employees, IComparer<Employee> combineKeyComparer)
        {
            _employees = employees;
            _combineKeyComparer = combineKeyComparer;
        }

        public static IEnumerator<Employee> JoeySort(IEnumerable<Employee> employees,
            IComparer<Employee> comboComparer)
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

                    if (comboComparer.Compare(employee, minElement) < 0)
                    {
                        minElement = employee;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        public static IEnumerable<Employee> JoeySort(IEnumerable<Employee> employees)
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

        public IEnumerator<Employee> GetEnumerator()
        {
            return JoeySort(_employees, _combineKeyComparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyOrderEnumerable Append(IComparer<Employee> comparer)
        {
            _combineKeyComparer = new ComboComparer(_combineKeyComparer, comparer);
            return this;
        }
    }
}