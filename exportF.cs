using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using CashMap;
using System.Configuration;

namespace CashMap
{
    public partial class exportF : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

        public exportF()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;

        }




        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateDebut.Value.Date;
            DateTime endDate = dateFin.Value.Date;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",          // Set filter to only show PDF files
                Title = "Save Financial Report",     // Set dialog title
                DefaultExt = "xlsx",                  // Set default file extension
                FileName = "transactions.xlsx"    // Default file name
            };
            string filePath;
            // Show the dialog and check if the user selected a file and clicked 'Save'
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                 filePath = saveFileDialog.FileName;
            }
            else {
                return;
            }

                // Query to fetch data from Transactions table
            string query = @"SELECT id_transaction, montant, date_transaction, montant_budget, description, type 
                FROM Transactions
                WHERE date_transaction >= @StartDate AND date_transaction <= @EndDate";

            // Fetch data into a DataTable
            DataTable transactionsTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(transactionsTable);
                }
            }

            // Create a new Excel file using ClosedXML
            using (var workbook = new XLWorkbook())
            {
                // Add a worksheet to the workbook
                var worksheet = workbook.Worksheets.Add("Transactions");

                // Add headers
                worksheet.Cell(1, 1).Value = "ID Transaction";
                worksheet.Cell(1, 2).Value = "Montant";
                worksheet.Cell(1, 3).Value = "Date Transaction";
                worksheet.Cell(1, 4).Value = "Montant Budget";
                worksheet.Cell(1, 5).Value = "Description";
                worksheet.Cell(1, 6).Value = "Type";

                // Fill data from the DataTable
                for (int row = 0; row < transactionsTable.Rows.Count; row++)
                {
                    // ID Transaction (Integer)
                    var id = transactionsTable.Rows[row]["id_transaction"];
                    worksheet.Cell(row + 2, 1).Value = id == DBNull.Value ? 0 : Convert.ToInt32(id);

                    // Montant (Decimal) - Handle DBNull
                    var montant = transactionsTable.Rows[row]["montant"];
                    worksheet.Cell(row + 2, 2).Value = montant == DBNull.Value ? 0m : Convert.ToDecimal(montant);

                    // Date Transaction (DateTime) - Handle DBNull
                    var dateTransaction = transactionsTable.Rows[row]["date_transaction"];
                    worksheet.Cell(row + 2, 3).Value = dateTransaction == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dateTransaction);

                    // Montant Budget (Nullable Integer) - Handle DBNull
                    var montantBudget = transactionsTable.Rows[row]["montant_budget"];
                    worksheet.Cell(row + 2, 4).Value =Convert.ToDecimal(montantBudget);

                    // Description (String) - Handle DBNull
                    var description = transactionsTable.Rows[row]["description"];
                    worksheet.Cell(row + 2, 5).Value = description == DBNull.Value ? string.Empty : description.ToString();

                    // Type (String) - Handle DBNull
                    var type = transactionsTable.Rows[row]["type"];
                    worksheet.Cell(row + 2, 6).Value = type.ToString();
                }

                // Set the file path

                workbook.SaveAs(filePath);

                // Inform the user
                MessageBox.Show($"Excel file has been created at: {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",          // Set filter to only show PDF files
                Title = "Save Financial Report",     // Set dialog title
                DefaultExt = "pdf",                  // Set default file extension
                FileName = "financial_report.pdf"    // Default file name
            };

            // Show the dialog and check if the user selected a file and clicked 'Save'
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path from the dialog
                string filePath = saveFileDialog.FileName;

                // Call the method to generate the report
                DateTime startDate = dateDebut.Value;
                DateTime endDate = dateFin.Value;
                pdf a = new pdf();
                a.GenerateFinancialReport(startDate, endDate, filePath);

                MessageBox.Show($"Report generated and saved at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No file selected. Report generation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exportF_Load(object sender, EventArgs e)
        {
            date_init();
        }
        void date_init()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query_max = "SELECT MAX(date_transaction) FROM Transactions";
                    string query_min = "SELECT MIN(date_transaction) FROM Transactions";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query_max, connection))
                    {

                        // Execute the query and retrieve the date
                        object result = command.ExecuteScalar();

                        if (result != null && DateTime.TryParse(result.ToString(), out DateTime dbDate))
                        {
                            // Assign the retrieved date to the DateTimePicker

                            dateDebut.MaxDate = dbDate;
                            dateFin.MaxDate = dbDate;

                            dateFin.Value = dbDate;


                        }
                        else
                        {
                            MessageBox.Show("No valid date found in the database.");
                        }
                    }
                    using (SqlCommand command = new SqlCommand(query_min, connection))
                    {

                        // Execute the query and retrieve the date
                        object result = command.ExecuteScalar();

                        if (result != null && DateTime.TryParse(result.ToString(), out DateTime dbDate))
                        {
                            // Assign the retrieved date to the DateTimePicker
                            dateDebut.Value = dbDate;

                            dateDebut.MinDate = dbDate;
                            dateFin.MinDate = dbDate;
                        }
                        else
                        {
                            MessageBox.Show("No valid date found in the database.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        
        private void dateFin_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateDebutc = dateDebut.Value; // Assuming the DateTimePicker for start date is named dateDebut
            DateTime dateFinc = dateFin.Value; // Assuming the DateTimePicker for end date is named dateFin

            // Check if dateDebut > dateFin
            if (dateDebutc >= dateFinc)
            {
                MessageBox.Show("La date de début doit être antérieure ou égale à la date de fin.", "Plage de dates invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateFin.Value = dateDebutc.AddDays(1); // Reset dateFin to match dateDebut
                return;
            }

        }

        private void dateDebut_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateDebutc = dateDebut.Value; 
            DateTime dateFinc = dateFin.Value; 

            if (dateDebutc >= dateFinc)
            {
                MessageBox.Show("La date de début doit être antérieure ou égale à la date de fin.", "Plage de dates invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateDebut.Value = dateFinc.AddDays(-1); 
                return;
            }

        }
    }
}

