using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer : IComparer<Employee>
    {
        public ComboComparer(IComparer<Employee> firstCombineKeyComparer, IComparer<Employee> secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        private IComparer<Employee> FirstCombineKeyComparer { get; set; }
        private IComparer<Employee> SecondCombineKeyComparer { get; set; }

        public int Compare(Employee x, Employee y)
        {
            var firstCompareResult = FirstCombineKeyComparer.Compare(x, y);
            var secondCompareResult = SecondCombineKeyComparer.Compare(x, y);

            if (firstCompareResult < 0)
            {
                return firstCompareResult;
            }

            return firstCompareResult == 0 ? secondCompareResult : firstCompareResult;
        }
    }
}