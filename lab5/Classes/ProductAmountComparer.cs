using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Classes
{
    public class ProductAmountComparer: IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Amount.CompareTo(y.Amount);
        }
    }
}
