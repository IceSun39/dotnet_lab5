using lab5.Classes;

namespace lab5
{
    public partial class Form1 : Form
    {
        private readonly Storage _storage;
        private readonly BindingSource _productsSource = new BindingSource();
        private readonly BindingSource _resultSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            string filePath = Path.Combine(AppContext.BaseDirectory, "products.json");
            _storage = new Storage(new JsonFileWriter(), new JsonFileReader(), filePath);

            _productsSource.DataSource = _storage.Products;
            dgvProducts.DataSource = _productsSource;
            _storage.Products.CollectionChanged += (s, e) => _productsSource.ResetBindings(false);

            _resultSource.DataSource = new List<Product>();
            dgvResult.DataSource = _resultSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtType.Text) || string.IsNullOrWhiteSpace(txtGrade.Text))
            {
                ShowError("Заповніть поля \"Тип\" та \"Сорт\".");
                return;
            }
            if (!double.TryParse(txtPrice.Text, out double price))
            {
                ShowError("Ціна має бути числом.");
                return;
            }
            if (!int.TryParse(txtAmount.Text, out int amount))
            {
                ShowError("Кількість має бути цілим числом.");
                return;
            }

            try
            {
                var product = new Product
                {
                    Type = txtType.Text.Trim(),
                    Price = price,
                    Grade = txtGrade.Text.Trim(),
                    Amount = amount
                };
                _storage.AddProduct(product);
                ClearInputs();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product product)
            {
                _storage.RemoveProduct(product);
            }
            else
            {
                ShowError("Виберіть продукт у таблиці.");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            _storage.SortByAmount();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLimit.Text, out int limit))
            {
                ShowError("Введіть ціле число в поле \"Кількість менша за\".");
                return;
            }

            _resultSource.DataSource = _storage.GetProductsWithAmountLessThan(limit);
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                await _storage.LoadAsync();
                _resultSource.DataSource = new List<Product>();
            }
            catch (Exception ex)
            {
                ShowError("Не вдалося завантажити файл: " + ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                await _storage.SaveAsync();
                MessageBox.Show("Дані збережено.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Не вдалося зберегти файл: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            txtType.Clear();
            txtPrice.Clear();
            txtGrade.Clear();
            txtAmount.Clear();
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sortByPrice_Click(object sender, EventArgs e)
        {
            _storage.SortByPrice();
        }
    }
}