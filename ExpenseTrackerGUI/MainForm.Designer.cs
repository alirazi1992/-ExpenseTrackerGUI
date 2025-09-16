namespace ExpenseTrackerGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblTotalValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();

            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.SuspendLayout();

            // Inputs row
            this.lblDate.AutoSize = true; this.lblDate.Location = new System.Drawing.Point(20, 20); this.lblDate.Text = "Date:";
            this.dtpDate.Location = new System.Drawing.Point(70, 16); this.dtpDate.Size = new System.Drawing.Size(150, 20);

            this.lblCategory.AutoSize = true; this.lblCategory.Location = new System.Drawing.Point(230, 20); this.lblCategory.Text = "Category:";
            this.cmbCategory.Location = new System.Drawing.Point(290, 16); this.cmbCategory.Size = new System.Drawing.Size(140, 21);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblDescription.AutoSize = true; this.lblDescription.Location = new System.Drawing.Point(20, 50); this.lblDescription.Text = "Description:";
            this.txtDescription.Location = new System.Drawing.Point(90, 47); this.txtDescription.Size = new System.Drawing.Size(340, 20);

            this.lblAmount.AutoSize = true; this.lblAmount.Location = new System.Drawing.Point(440, 20); this.lblAmount.Text = "Amount:";
            this.txtAmount.Location = new System.Drawing.Point(495, 16); this.txtAmount.Size = new System.Drawing.Size(90, 20);

            this.btnAdd.Location = new System.Drawing.Point(600, 14); this.btnAdd.Size = new System.Drawing.Size(80, 25); this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(690, 14); this.btnDelete.Size = new System.Drawing.Size(80, 25); this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Filter row
            this.lblFilter.AutoSize = true; this.lblFilter.Location = new System.Drawing.Point(20, 85); this.lblFilter.Text = "Filter:";
            this.cmbMonth.Location = new System.Drawing.Point(65, 82); this.cmbMonth.Size = new System.Drawing.Size(110, 21);
            this.cmbYear.Location = new System.Drawing.Point(180, 82); this.cmbYear.Size = new System.Drawing.Size(90, 21);

            this.btnFilter.Location = new System.Drawing.Point(280, 80); this.btnFilter.Size = new System.Drawing.Size(70, 25); this.btnFilter.Text = "Apply";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            this.btnReset.Location = new System.Drawing.Point(355, 80); this.btnReset.Size = new System.Drawing.Size(70, 25); this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // Grid
            this.dgvExpenses.Location = new System.Drawing.Point(20, 120);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.MultiSelect = false;
            this.dgvExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpenses.RowHeadersVisible = false;
            this.dgvExpenses.Size = new System.Drawing.Size(750, 330);

            // Total
            this.lblTotalCaption.AutoSize = true; this.lblTotalCaption.Location = new System.Drawing.Point(600, 85); this.lblTotalCaption.Text = "Total:";
            this.lblTotalValue.AutoSize = true; this.lblTotalValue.Location = new System.Drawing.Point(640, 85); this.lblTotalValue.Text = "$0.00";
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.lblDate); this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblCategory); this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblDescription); this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAmount); this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnAdd); this.Controls.Add(this.btnDelete);

            this.Controls.Add(this.lblFilter); this.Controls.Add(this.cmbMonth); this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnFilter); this.Controls.Add(this.btnReset);

            this.Controls.Add(this.dgvExpenses);
            this.Controls.Add(this.lblTotalCaption); this.Controls.Add(this.lblTotalValue);

            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
