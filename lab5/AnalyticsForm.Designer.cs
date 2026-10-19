using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    partial class AnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnValues = new Button();
            btnTypes = new Button();
            btnGrades = new Button();
            dgvAnalytics = new DataGridView();
            lblTotal = new Label();
            lblAverage = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAnalytics).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Аналітика складу (LINQ)";

            // btnValues
            btnValues.Location = new Point(12, 40);
            btnValues.Name = "btnValues";
            btnValues.Size = new Size(198, 28);
            btnValues.Text = "Вартість позицій";
            btnValues.UseVisualStyleBackColor = true;
            btnValues.Click += btnValues_Click;

            // btnTypes
            btnTypes.Location = new Point(220, 40);
            btnTypes.Name = "btnTypes";
            btnTypes.Size = new Size(198, 28);
            btnTypes.Text = "Статистика за типами";
            btnTypes.UseVisualStyleBackColor = true;
            btnTypes.Click += btnTypes_Click;

            // btnGrades
            btnGrades.Location = new Point(428, 40);
            btnGrades.Name = "btnGrades";
            btnGrades.Size = new Size(198, 28);
            btnGrades.Text = "Кількість за сортами";
            btnGrades.UseVisualStyleBackColor = true;
            btnGrades.Click += btnGrades_Click;

            // dgvAnalytics
            dgvAnalytics.AllowUserToAddRows = false;
            dgvAnalytics.AllowUserToDeleteRows = false;
            dgvAnalytics.AllowUserToResizeRows = false;
            dgvAnalytics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnalytics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnalytics.BackgroundColor = Color.White;
            dgvAnalytics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalytics.Location = new Point(12, 80);
            dgvAnalytics.MultiSelect = false;
            dgvAnalytics.Name = "dgvAnalytics";
            dgvAnalytics.ReadOnly = true;
            dgvAnalytics.RowHeadersVisible = false;
            dgvAnalytics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnalytics.Size = new Size(614, 330);

            // lblTotal
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 425);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Загальна вартість складу:";

            // lblAverage
            lblAverage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAverage.AutoSize = true;
            lblAverage.Location = new Point(12, 450);
            lblAverage.Name = "lblAverage";
            lblAverage.Text = "Середня ціна:";

            // AnalyticsForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 480);
            Controls.Add(lblAverage);
            Controls.Add(lblTotal);
            Controls.Add(dgvAnalytics);
            Controls.Add(btnGrades);
            Controls.Add(btnTypes);
            Controls.Add(btnValues);
            Controls.Add(lblTitle);
            MinimumSize = new Size(500, 400);
            Name = "AnalyticsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Аналітика";
            ((System.ComponentModel.ISupportInitialize)dgvAnalytics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnValues;
        private Button btnTypes;
        private Button btnGrades;
        private DataGridView dgvAnalytics;
        private Label lblTotal;
        private Label lblAverage;
    }
}
