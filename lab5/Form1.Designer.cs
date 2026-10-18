using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    partial class Form1
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
            lblType = new Label();
            txtType = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblGrade = new Label();
            txtGrade = new TextBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            btnAdd = new Button();
            dgvProducts = new DataGridView();
            lblLimit = new Label();
            txtLimit = new TextBox();
            btnFilter = new Button();
            btnDelete = new Button();
            btnSort = new Button();
            btnLoad = new Button();
            btnSave = new Button();
            lblResult = new Label();
            dgvResult = new DataGridView();
            sortByPrice = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 15);
            lblTitle.TabIndex = 19;
            lblTitle.Text = "Додати/редагувати продукт";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(12, 48);
            lblType.Name = "lblType";
            lblType.Size = new Size(31, 15);
            lblType.TabIndex = 18;
            lblType.Text = "Тип:";
            // 
            // txtType
            // 
            txtType.Location = new Point(90, 45);
            txtType.Name = "txtType";
            txtType.Size = new Size(280, 23);
            txtType.TabIndex = 17;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(400, 48);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 15);
            lblPrice.TabIndex = 16;
            lblPrice.Text = "Ціна:";
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Location = new Point(480, 45);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(328, 23);
            txtPrice.TabIndex = 15;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(12, 83);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(37, 15);
            lblGrade.TabIndex = 14;
            lblGrade.Text = "Сорт:";
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(90, 80);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(280, 23);
            txtGrade.TabIndex = 13;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(400, 83);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(59, 15);
            lblAmount.TabIndex = 12;
            lblAmount.Text = "Кількість:";
            // 
            // txtAmount
            // 
            txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAmount.Location = new Point(480, 80);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(328, 23);
            txtAmount.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.Location = new Point(12, 115);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(796, 28);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Додати продукт";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 158);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(796, 230);
            dgvProducts.TabIndex = 9;
            // 
            // lblLimit
            // 
            lblLimit.AutoSize = true;
            lblLimit.Location = new Point(12, 400);
            lblLimit.Name = "lblLimit";
            lblLimit.Size = new Size(115, 15);
            lblLimit.TabIndex = 8;
            lblLimit.Text = "Кількість менша за:";
            // 
            // txtLimit
            // 
            txtLimit.Location = new Point(135, 396);
            txtLimit.Name = "txtLimit";
            txtLimit.Size = new Size(60, 23);
            txtLimit.TabIndex = 7;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(205, 394);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(90, 27);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Фільтр";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(305, 394);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 27);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(405, 394);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(160, 27);
            btnSort.TabIndex = 4;
            btnSort.Text = "Сортувати за кількістю";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(575, 394);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 27);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Завантажити";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(705, 394);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResult.Location = new Point(12, 435);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(366, 15);
            lblResult.TabIndex = 1;
            lblResult.Text = "Результат: кількість менша за задану (за зростанням кількості)";
            // 
            // dgvResult
            // 
            dgvResult.AllowUserToAddRows = false;
            dgvResult.AllowUserToDeleteRows = false;
            dgvResult.AllowUserToResizeRows = false;
            dgvResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResult.BackgroundColor = Color.White;
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Location = new Point(12, 458);
            dgvResult.MultiSelect = false;
            dgvResult.Name = "dgvResult";
            dgvResult.ReadOnly = true;
            dgvResult.RowHeadersVisible = false;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.Size = new Size(796, 200);
            dgvResult.TabIndex = 0;
            // 
            // sortByPrice
            // 
            sortByPrice.Location = new Point(405, 431);
            sortByPrice.Name = "sortByPrice";
            sortByPrice.Size = new Size(160, 23);
            sortByPrice.TabIndex = 20;
            sortByPrice.Text = "Сортувати за ціною";
            sortByPrice.UseVisualStyleBackColor = true;
            sortByPrice.Click += sortByPrice_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 672);
            Controls.Add(sortByPrice);
            Controls.Add(dgvResult);
            Controls.Add(lblResult);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(btnSort);
            Controls.Add(btnDelete);
            Controls.Add(btnFilter);
            Controls.Add(txtLimit);
            Controls.Add(lblLimit);
            Controls.Add(dgvProducts);
            Controls.Add(btnAdd);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(txtGrade);
            Controls.Add(lblGrade);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtType);
            Controls.Add(lblType);
            Controls.Add(lblTitle);
            MinimumSize = new Size(700, 560);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Склад продукції";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblType;
        private TextBox txtType;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblGrade;
        private TextBox txtGrade;
        private Label lblAmount;
        private TextBox txtAmount;
        private Button btnAdd;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colAmount;
        private Label lblLimit;
        private TextBox txtLimit;
        private Button btnFilter;
        private Button btnDelete;
        private Button btnSort;
        private Button btnLoad;
        private Button btnSave;
        private Label lblResult;
        private DataGridView dgvResult;
        private DataGridViewTextBoxColumn colResType;
        private DataGridViewTextBoxColumn colResPrice;
        private DataGridViewTextBoxColumn colResGrade;
        private DataGridViewTextBoxColumn colResAmount;
        private Button sortByPrice;
    }
}