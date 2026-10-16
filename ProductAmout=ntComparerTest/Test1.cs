using System;
using lab5.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ProductAmountComparerTest
{
    [TestClass]
    public class Test1
    {
        private readonly ProductAmountComparer comparer = new ProductAmountComparer();

        [TestMethod]
        public void Compare_BothNull_ReturnsZero()
        {
            Assert.AreEqual(0, comparer.Compare(null, null));
        }

        [TestMethod]
        public void Compare_FirstNull_ReturnsNegative()
        {
            var product = new Product("Milk", 10, "A", 5);

            Assert.IsTrue(comparer.Compare(null, product) < 0);
        }

        [TestMethod]
        public void Compare_SecondNull_ReturnsPositive()
        {
            var product = new Product("Milk", 10, "A", 5);

            Assert.IsTrue(comparer.Compare(product, null) > 0);
        }

        [TestMethod]
        [DataRow(3, 7, -1)]
        [DataRow(5, 5, 0)]
        [DataRow(9, 2, 1)]
        public void Compare_ComparesByAmount(int amount1, int amount2, int expectedSign)
        {
            var first = new Product("A", 10, "A", amount1);
            var second = new Product("B", 10, "A", amount2);

            int result = comparer.Compare(first, second);

            Assert.AreEqual(expectedSign, Math.Sign(result));
        }

        [TestMethod]
        public void Sort_WithComparer_OrdersByAmountAscending()
        {
            var list = new List<Product>
            {
                new Product("A", 10, "A", 30),
                new Product("B", 10, "A", 10),
                new Product("C", 10, "A", 20)
            };

            list.Sort(comparer);

            CollectionAssert.AreEqual(new[] { 10, 20, 30 }, list.Select(p => p.Amount).ToArray());
        }

    }
}
