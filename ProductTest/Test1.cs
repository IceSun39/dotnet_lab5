using System;
using lab5.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab5.Tests
{
    [TestClass]
    public class ProductTests
    {
        // Тестування конструкторів
        [TestMethod]
        public void Constructor_Default_SetsDefaultValues()
        {
            var product = new Product();

            Assert.AreEqual("Unknown", product.Type);
            Assert.AreEqual(0.0, product.Price);
            Assert.AreEqual("Unknown", product.Grade);
            Assert.AreEqual(0, product.Amount);
        }

        [TestMethod]
        public void Constructor_WithValidArguments_CreatesProductObject()
        {
            var product = new Product("Milk", 29.5, "A", 10);

            Assert.AreEqual("Milk", product.Type);
            Assert.AreEqual(29.5, product.Price);
            Assert.AreEqual("A", product.Grade);
            Assert.AreEqual(10, product.Amount);
        }

        // Тестування валідації властивостей
        [TestMethod]
        public void Price_NegativeValue_ThrowsArgumentException()
        {
            var product = new Product();

            Assert.ThrowsException<ArgumentException>(() => product.Price = -1);
        }

        [TestMethod]
        public void Amount_ValidValue_SetsAmount()
        {
            var product = new Product();

            product.Amount = 5;

            Assert.AreEqual(5, product.Amount);
        }

        [TestMethod]
        public void Amount_NegativeValue_ThrowsArgumentException()
        {
            var product = new Product();

            Assert.ThrowsException<ArgumentException>(() => product.Amount = -1);
        }

        // Тестування CompareTo
        [TestMethod]
        public void CompareTo_Null_ReturnsOne()
        {
            var product = new Product("Milk", 10, "A", 5);

            Assert.AreEqual(1, product.CompareTo(null));
        }

        [TestMethod]
        [DataRow(3, 7, -1)]
        [DataRow(5, 5, 0)]
        [DataRow(9, 2, 1)]
        public void CompareTo_ComparesByAmount(int amount1, int amount2, int expectedSign)
        {
            var first = new Product("A", 10, "A", amount1);
            var second = new Product("B", 10, "A", amount2);

            int result = first.CompareTo(second);

            Assert.AreEqual(expectedSign, Math.Sign(result));
        }

        // Тестування ToString
        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            var product = new Product("Milk", 10.0, "A", 5);

            Assert.AreEqual("Type: Milk, Price: 10, Grade: A, Amount: 5", product.ToString());
        }
    }
}