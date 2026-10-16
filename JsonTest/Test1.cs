using System;
using lab5.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace JsonTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestClass]
        public class FileHandlerTests
        {
            private string _testDirectory;
            private string _testFilePath;

            [TestInitialize]
            public void TestInitialize()
            {
                _testDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                _testFilePath = Path.Combine(_testDirectory, "products.json");
                Directory.CreateDirectory(_testDirectory);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                if (Directory.Exists(_testDirectory))
                {
                    Directory.Delete(_testDirectory, true);
                }
            }



            [TestMethod]
            public async Task SaveAsync_Should_CreateFile()
            {
                var products = new List<Product> { new Product("Milk", 29.5, "A", 10) };
                var fileSaver = new JsonFileWriter();

                await fileSaver.SaveAsync(_testFilePath, products);

                Assert.IsTrue(File.Exists(_testFilePath), "Файл не було створено.");
            }

            [TestMethod]
            public async Task SaveAsync_Should_WriteDataToFile()
            {
                var products = new List<Product>
            {
                new Product("Milk", 29.5, "A", 10),
                new Product("Bread", 15, "B", 3)
            };
                var fileSaver = new JsonFileWriter();

                await fileSaver.SaveAsync(_testFilePath, products);

                string fileContent = await File.ReadAllTextAsync(_testFilePath);
                Assert.IsFalse(string.IsNullOrWhiteSpace(fileContent), "Файл порожній.");
                StringAssert.Contains(fileContent, "Milk", "У файлі немає очікуваних даних.");
            }

            [TestMethod]
            public async Task SaveAsync_Should_CreateDirectoryIfNotExists()
            {
                string nestedPath = Path.Combine(_testDirectory, "nested", "products.json");
                var fileSaver = new JsonFileWriter();

                await fileSaver.SaveAsync(nestedPath, new List<Product>());

                Assert.IsTrue(File.Exists(nestedPath), "Папку та файл не було створено.");
            }

            // ---------- JsonFileReader ----------

            [TestMethod]
            public async Task LoadAsync_Should_ReturnNull_WhenFileDoesNotExist()
            {
                var fileReader = new JsonFileReader();

                var result = await fileReader.LoadAsync<Product>(_testFilePath);

                Assert.IsNull(result, "Для неіснуючого файлу очікувався null.");
            }

            [TestMethod]
            public async Task LoadAsync_Should_ReturnData_WhenFileExists()
            {
                var products = new List<Product>
            {
                new Product("Milk", 29.5, "A", 10),
                new Product("Bread", 15, "B", 3)
            };
                await new JsonFileWriter().SaveAsync(_testFilePath, products);
                var fileReader = new JsonFileReader();

                var loadedProducts = await fileReader.LoadAsync<Product>(_testFilePath);

                Assert.IsNotNull(loadedProducts, "Десеріалізація не вдалася.");
                Assert.AreEqual(2, loadedProducts.Count, "Кількість десеріалізованих об'єктів не збігається.");
                Assert.AreEqual("Milk", loadedProducts[0].Type);
                Assert.AreEqual(29.5, loadedProducts[0].Price);
                Assert.AreEqual(3, loadedProducts[1].Amount);
            }

            [TestMethod]
            public async Task LoadAsync_Should_ThrowJsonException_WhenJsonIsInvalid()
            {
                await File.WriteAllTextAsync(_testFilePath, "це не json");
                var fileReader = new JsonFileReader();

                await Assert.ThrowsExceptionAsync<JsonException>(
                    () => fileReader.LoadAsync<Product>(_testFilePath));
            }

        }
    }
}
