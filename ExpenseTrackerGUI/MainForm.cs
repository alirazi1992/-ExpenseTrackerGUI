using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace ExpenseTrackerGUI
{
    public partial class MainForm : Form
    {
        private readonly string _dbPath;
        private readonly string _connStr;

        public MainForm()
        {
            InitializeComponent();
            _dbPath = Path.Combine(AppContext.BaseDirectory, "expenses.db");
            _connStr = "Data Source=" + _dbPath;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Seed category & filter choices
            cmbCategory.Items.AddRange(new object[] { "Food", "Transport", "Bills", "Shopping", "Health", "Entertainment", "Other" });
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;

            cmbMonth.Items.Add("All months");
            foreach (var m in Enumerable.Range(1, 12))
                cmbMonth.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m));
            cmbMonth.SelectedIndex = 0;

            cmbYear.Items.Add("All years");
            int yearNow = DateTime.Now.Year;
            for (int y = yearNow - 5; y <= yearNow + 1; y++) cmbYear.Items.Add(y.ToString());
            cmbYear.SelectedItem = yearNow.ToString();

            EnsureDatabase();
            LoadGrid(); // no filter by default
        }

        // Create DB + table if missing
        private void EnsureDatabase()
        {
            if (!File.Exists(_dbPath))
                using (File.Create(_dbPath)) { }

            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();
                const string sql = @"
CREATE TABLE IF NOT EXISTS Expenses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Date TEXT NOT NULL,          -- store ISO date string (yyyy-MM-dd)
    Category TEXT NOT NULL,
    Description TEXT NOT NULL,
    Amount REAL NOT NULL
);";
                using (var cmd = new SqliteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        // Load grid with optional month/year filtering
        private void LoadGrid(int? month = null, int? year = null)
        {
            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();

                string sql = "SELECT Id, Date, Category, Description, Amount FROM Expenses";
                if (month.HasValue && year.HasValue)
                    sql += " WHERE strftime('%m', Date) = $m AND strftime('%Y', Date) = $y";
                else if (year.HasValue)
                    sql += " WHERE strftime('%Y', Date) = $y";
                sql += " ORDER BY Date DESC, Id DESC";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    if (month.HasValue)
                        cmd.Parameters.AddWithValue("$m", month.Value.ToString("00"));
                    if (year.HasValue)
                        cmd.Parameters.AddWithValue("$y", year.Value.ToString());

                    using (var reader = cmd.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        dgvExpenses.DataSource = table;
                    }
                }

                // Compute total
                using (var cmdTotal = new SqliteCommand("SELECT SUM(Amount) FROM (" + (month.HasValue || year.HasValue ? sql.Replace("SELECT Id, Date, Category, Description, Amount FROM Expenses", "SELECT Amount FROM Expenses") : "SELECT Amount FROM Expenses") + ")", conn))
                {
                    if (month.HasValue)
                        cmdTotal.Parameters.AddWithValue("$m", month.Value.ToString("00"));
                    if (year.HasValue)
                        cmdTotal.Parameters.AddWithValue("$y", year.Value.ToString());

                    object sumObj = cmdTotal.ExecuteScalar();
                    decimal total = 0m;
                    if (sumObj != DBNull.Value && sumObj != null)
                        total = Convert.ToDecimal(sumObj);
                    lblTotalValue.Text = total.ToString("C2");
                }
            }

            // Optional: nice formats
            if (dgvExpenses.Columns.Contains("Date"))
                dgvExpenses.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            if (dgvExpenses.Columns.Contains("Amount"))
                dgvExpenses.Columns["Amount"].DefaultCellStyle.Format = "C2";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // validate
            string category = Convert.ToString(cmbCategory.SelectedItem ?? "Other");
            string description = (txtDescription.Text ?? "").Trim();
            string amountText = (txtAmount.Text ?? "").Trim();

            if (description.Length == 0) { MessageBox.Show("Description is required."); return; }
            if (amountText.Length == 0) { MessageBox.Show("Amount is required."); return; }

            decimal amount;
            if (!decimal.TryParse(amountText, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
            {
                // allow local decimal with comma/dot
                if (!decimal.TryParse(amountText, NumberStyles.Number, CultureInfo.CurrentCulture, out amount))
                {
                    MessageBox.Show("Invalid amount."); return;
                }
            }

            var dateIso = dtpDate.Value.ToString("yyyy-MM-dd");

            try
            {
                using (var conn = new SqliteConnection(_connStr))
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand(
                        "INSERT INTO Expenses (Date, Category, Description, Amount) VALUES ($d,$c,$desc,$a)", conn))
                    {
                        cmd.Parameters.AddWithValue("$d", dateIso);
                        cmd.Parameters.AddWithValue("$c", category);
                        cmd.Parameters.AddWithValue("$desc", description);
                        cmd.Parameters.AddWithValue("$a", amount);
                        cmd.ExecuteNonQuery();
                    }
                }

                // clear inputs
                txtDescription.Clear();
                txtAmount.Clear();

                // refresh with current filter
                ApplyFilterFromUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.CurrentRow == null || dgvExpenses.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            var rowView = dgvExpenses.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) { MessageBox.Show("Invalid selection."); return; }
            int id = Convert.ToInt32(rowView.Row["Id"]);

            if (MessageBox.Show("Delete selected expense?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqliteConnection(_connStr))
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand("DELETE FROM Expenses WHERE Id=$id", conn))
                    {
                        cmd.Parameters.AddWithValue("$id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                ApplyFilterFromUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterFromUI();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbMonth.SelectedIndex = 0; // All months
            cmbYear.SelectedItem = DateTime.Now.Year.ToString();
            LoadGrid();
        }

        private void ApplyFilterFromUI()
        {
            int? month = null;
            int? year = null;

            if (cmbMonth.SelectedIndex > 0) month = cmbMonth.SelectedIndex; // 1..12
            if (cmbYear.SelectedIndex > 0)
            {
                int y; if (int.TryParse(Convert.ToString(cmbYear.SelectedItem), out y)) year = y;
            }

            LoadGrid(month, year);
        }
    }
}
