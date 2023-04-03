using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group4
{
    public class CompareExpressions : IComparer<double>
    {
        // to compare expressions using IComparer
        public int Compare(double x, double y)
        {
            return x.CompareTo(y);
        }
    }
}