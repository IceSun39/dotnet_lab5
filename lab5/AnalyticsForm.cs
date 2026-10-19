using lab5.Classes;

namespace lab5
{
    public partial class AnalyticsForm : Form
    {
        private readonly Storage _storage;

        public AnalyticsForm(Storage storage)
        {
            InitializeComponent();
            _storage = storage;

            ShowTotals();
            ShowProductValues();
        }

        // Проекція: вартість кожної позиції
        private void btnValues_Click(object sender, EventArgs e)
        {
            ShowProductValues();
        }

        // Групування за типом
        private void btnTypes_Click(object sender, EventArgs e)
        {
            dgvAnalytics.DataSource = _storage.GetTypeStatistics();

            SetColumn("Type", "Тип");
            SetColumn("ProductsCount", "Кількість позицій");
            SetColumn("TotalAmount", "Загальна кількість");
            SetColumn("AveragePrice", "Середня ціна", "N2");
        }

        // Групування за сортом (Dictionary перетворюємо на список для таблиці)
        private void btnGrades_Click(object sender, EventArgs e)
        {
            dgvAnalytics.DataSource = _storage.CountByGrade()
                .Select(pair => new { Grade = pair.Key, Count = pair.Value })
                .OrderBy(item => item.Grade)
                .ToList();

            SetColumn("Grade", "Сорт");
            SetColumn("Count", "Кількість позицій");
        }

        private void ShowProductValues()
        {
            dgvAnalytics.DataSource = _storage.GetProductValues();

            SetColumn("Type", "Тип");
            SetColumn("Grade", "Сорт");
            SetColumn("TotalValue", "Загальна вартість", "N2");
        }

        // Агрегації: сума та середнє
        private void ShowTotals()
        {
            lblTotal.Text = $"Загальна вартість складу: {_storage.GetTotalValue():N2}";
            lblAverage.Text = $"Середня ціна: {_storage.GetAveragePrice():N2}";
        }

        private void SetColumn(string name, string header, string? format = null)
        {
            var column = dgvAnalytics.Columns[name];
            if (column == null) return;

            column.HeaderText = header;
            if (format != null)
            {
                column.DefaultCellStyle.Format = format;
            }
        }
    }
}
