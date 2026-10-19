using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab5.Classes;
using lab5.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab5.Tests
{
    [TestClass]
    public class StorageTests
    {
     
        private class FakeFileSaver : IFileSaver
        {
            public Task SaveAsync<T>(string filePath, List<T> data) => Task.CompletedTask;
        }

        private class FakeFileLoader : IFileLoader
        {
            public Task<List<T>> LoadAsync<T>(string filePath) => Task.FromResult(new List<T>());
        }

        private Storage _storage;

        private static Storage CreateEmptyStorage()
        {
            return new Storage(new FakeFileSaver(), new FakeFileLoader(), "test.json");
        }

        // Перед кожним тестом наповнюємо склад однаковими даними
        [TestInitialize]
        public void TestInitialize()
        {
            _storage = CreateEmptyStorage();
            _storage.AddProduct(new Product("Milk", 20, "A", 10));    // вартість 200
            _storage.AddProduct(new Product("Milk", 30, "B", 5));     // вартість 150
            _storage.AddProduct(new Product("Bread", 10, "A", 20));   // вартість 200
            _storage.AddProduct(new Product("Cheese", 100, "A", 1));  // вартість 100
        }

        // ---------- Базова логіка ----------

        [TestMethod]
        public void AddProduct_Should_AddProductToCollection()
        {
            _storage.AddProduct(new Product("Eggs", 5, "A", 50));

            Assert.AreEqual(5, _storage.Products.Count, "Продукт не було додано.");
        }

        [TestMethod]
        public void RemoveProduct_Should_RemoveProductFromCollection()
        {
            var product = _storage.Products[0];

            _storage.RemoveProduct(product);

            Assert.AreEqual(3, _storage.Products.Count, "Продукт не було видалено.");
            Assert.IsFalse(_storage.Products.Contains(product));
        }

        [TestMethod]
        public void SortByAmount_Should_OrderByAmountAscending()
        {
            _storage.SortByAmount();

            var amounts = _storage.Products.Select(p => p.Amount).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 5, 10, 20 }, amounts);
        }

        [TestMethod]
        public void FilterByType_Should_IgnoreCase()
        {
            _storage.FilterByType("milk");

            Assert.AreEqual(2, _storage.Products.Count);
        }

        [TestMethod]
        public void ResetFilter_Should_RestoreAllProducts()
        {
            _storage.FilterByType("Bread");

            _storage.ResetFilter();

            Assert.AreEqual(4, _storage.Products.Count);
        }

        

        [TestMethod]
        public void GetProductsWithAmountLessThan_Should_ReturnSortedProductsWithSmallerAmount()
        {
            var result = _storage.GetProductsWithAmountLessThan(10);

           
            CollectionAssert.AreEqual(new[] { 1, 5 }, result.Select(p => p.Amount).ToArray());
        }

        [TestMethod]
        public void GetProductsWithAmountLessThan_Should_ReturnEmptyList_WhenNothingMatches()
        {
            var result = _storage.GetProductsWithAmountLessThan(1);

            Assert.AreEqual(0, result.Count);
        }

      

        [TestMethod]
        public void GetProductValues_Should_ProjectTotalValueOfEachProduct()
        {
            var values = _storage.GetProductValues();

            Assert.AreEqual(4, values.Count);
            Assert.AreEqual("Milk", values[0].Type);
            Assert.AreEqual("A", values[0].Grade);
            Assert.AreEqual(200, values[0].TotalValue, 0.0001);
            Assert.AreEqual(150, values[1].TotalValue, 0.0001);
        }

 
        [TestMethod]
        public void GetTypeStatistics_Should_GroupProductsByType()
        {
            var stats = _storage.GetTypeStatistics();

            Assert.AreEqual(3, stats.Count, "Очікувалось 3 групи: Bread, Cheese, Milk.");

            var milk = stats.First(s => s.Type == "Milk");
            Assert.AreEqual(2, milk.ProductsCount);
            Assert.AreEqual(15, milk.TotalAmount);
            Assert.AreEqual(25, milk.AveragePrice, 0.0001);
        }

        [TestMethod]
        public void GetTypeStatistics_Should_IgnoreCaseWhenGrouping()
        {
            _storage.AddProduct(new Product("milk", 40, "A", 1));

            var stats = _storage.GetTypeStatistics();

            Assert.AreEqual(3, stats.Count, "\"Milk\" та \"milk\" мають бути однією групою.");
        }

        [TestMethod]
        public void CountByGrade_Should_ReturnNumberOfProductsInEachGrade()
        {
            var result = _storage.CountByGrade();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(3, result["A"]);
            Assert.AreEqual(1, result["B"]);
        }

   

        [TestMethod]
        public void GetTotalValue_Should_ReturnSumOfPriceTimesAmount()
        {
            Assert.AreEqual(650, _storage.GetTotalValue(), 0.0001);
        }

        [TestMethod]
        public void GetTotalValue_Should_ReturnZero_WhenStorageIsEmpty()
        {
            var empty = CreateEmptyStorage();

            Assert.AreEqual(0, empty.GetTotalValue(), 0.0001);
        }

        [TestMethod]
        public void GetAveragePrice_Should_ReturnAverageOfPrices()
        {
            Assert.AreEqual(40, _storage.GetAveragePrice(), 0.0001);
        }

        [TestMethod]
        public void GetAveragePrice_Should_ReturnZero_WhenStorageIsEmpty()
        {
            var empty = CreateEmptyStorage();

            Assert.AreEqual(0, empty.GetAveragePrice(), 0.0001);
        }
    }
}