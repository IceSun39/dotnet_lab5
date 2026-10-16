using lab5.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Classes
{
    public class Storage
    {
        private readonly IFileSaver _fileSaver;
        private readonly IFileLoader _fileLoader;
        private readonly string _filePath;
        public ObservableCollection<Product> Products { get; }
        private List<Product> _allProducts;

        public Storage(IFileSaver fileSaver, IFileLoader fileLoader, string filePath)
        {
            _fileSaver = fileSaver;
            _fileLoader = fileLoader;
            _filePath = filePath;
            Products = new ObservableCollection<Product>();
            _allProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            _allProducts.Add(product);
        }
        public void RemoveProduct(Product product) {
            Products.Remove(product);
            _allProducts.Remove(product);
        }
        public void SortByAmount()
        {
            var sortedProducts = new List<Product>(_allProducts);
            sortedProducts.Sort(new ProductAmountComparer());
            UpdateVisibleCollection(sortedProducts);
        }

        public void FilterByType(string type)
        {
            var filteredProducts = _allProducts.Where(p => p.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
            UpdateVisibleCollection(filteredProducts);
        }
        public void ResetFilter()
        {
            UpdateVisibleCollection(_allProducts);
        }

        private void UpdateVisibleCollection(List<Product> filteredProducts)
        {
            Products.Clear();
            foreach (var product in filteredProducts)
            {
                Products.Add(product);
            }
        }

        public async Task SaveAsync()
        {
            await _fileSaver.SaveAsync(_filePath, _allProducts);
        }

        public async Task LoadAsync()
        {
            var loadedProducts = await _fileLoader.LoadAsync<Product>(_filePath);
            if (loadedProducts != null)
            {
                _allProducts = loadedProducts;
                UpdateVisibleCollection(_allProducts);
            }
        }

        public List<Product> GetProductsWithAmountLessThan(int limit)
        {
            var result = _allProducts.Where(p => p.Amount < limit).ToList();
            result.Sort(new ProductAmountComparer());
            return result;
        }
    }
}
