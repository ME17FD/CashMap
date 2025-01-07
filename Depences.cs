using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashMap
{
    public partial class Depences : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

        public Depences()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;

        }

        private void LoadDataIntoGridView()
        {
            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            try
            {
                // Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define the SQL query to retrieve data
                    string query = "SELECT id_transaction, montant, date_transaction, description FROM Transactions WHERE type = 'depense';";

                    // Create a SqlDataAdapter to retrieve data
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable with the data from the database
                        dataAdapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during data retrieval
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Depences_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss"; // Custom format to include date and time
            dateTimePicker1.ShowUpDown = true;
            date_init();

        }


        void date_init()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query_max = "SELECT MAX(date_transaction) FROM Transactions";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query_max, connection))
                    {

                        // Execute the query and retrieve the date
                        object result = command.ExecuteScalar();

                        if (result != null && DateTime.TryParse(result.ToString(), out DateTime dbDate))
                        {
                            // Assign the retrieved date to the DateTimePicker

                            dateTimePicker1.MinDate = dbDate;
                            dateTimePicker1.Value = dbDate;

                        }
                        
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }


        private void ajouterB_Click(object sender, EventArgs e)
        {
            DateTime dateTransaction = dateTimePicker1.Value;

            // Validate the montant input
            if (!decimal.TryParse(montantT.Text, out decimal montant) || montant <= 0)
            {
                MessageBox.Show("Invalid amount. Please enter a positive number for the montant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string motif = motifT.Text;
            string type = "depense"; // Since the type is fixed as "depense"

            // Query to check the maximum date in the Transactions table
            string maxDateQuery = "SELECT ISNULL(MAX(date_transaction), '1900-01-01') FROM Transactions";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check the maximum date
                    using (SqlCommand cmdMaxDate = new SqlCommand(maxDateQuery, conn))
                    {
                        DateTime maxDate = (DateTime)cmdMaxDate.ExecuteScalar();

                        // Compare the selected date with the maximum date
                        if (dateTransaction <= maxDate)
                        {
                            MessageBox.Show($"The transaction date must be after the most recent transaction date: {maxDate}.",
                                            "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string current_b_q = "SELECT TOP 1 montant_budget from Transactions order by id_transaction DESC";

                    decimal current_balance;
                    using (SqlCommand cmdMaxDate = new SqlCommand(current_b_q, conn))
                    {
                         object res = cmdMaxDate.ExecuteScalar();
                        if (res != DBNull.Value || res!=null)
                        {
                            current_balance = Convert.ToDecimal(res);
                        }
                        else
                        {
                            current_balance = 0;
                        }
                    }

                        // Insert query
                        string query = "INSERT INTO Transactions (montant, date_transaction, montant_budget, description, type) " +
                                   "VALUES (@montant, @date_transaction, " +
                                   "@balance, @motif, @type)";

                    // Execute the insert
                    using (SqlCommand cmdInsert = new SqlCommand(query, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@montant", montant);
                        cmdInsert.Parameters.AddWithValue("@date_transaction", dateTransaction);
                        cmdInsert.Parameters.AddWithValue("@motif", motif);
                        cmdInsert.Parameters.AddWithValue("@type", type);
                        cmdInsert.Parameters.AddWithValue("@balance", current_balance-montant);

                        cmdInsert.ExecuteNonQuery();
                    }

                    // Refresh the grid view and reset the form
                    LoadDataIntoGridView();
                    date_init();
                    MessageBox.Show("Transaction successfully added.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
