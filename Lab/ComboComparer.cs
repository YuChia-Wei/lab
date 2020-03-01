using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer
    {
        public ComboComparer(IComparer<Employee> firstCombineKeyComparer, IComparer<Employee> secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        public IComparer<Employee> FirstCombineKeyComparer { get; private set; }
        public IComparer<Employee> SecondCombineKeyComparer { get; private set; }

        public int FinalCompareResult(Employee employee, Employee minElement)
        {
            var firstCompareResult = FirstCombineKeyComparer.Compare(employee, minElement);
            var secondCompareResult = SecondCombineKeyComparer.Compare(employee, minElement);

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
    }
}