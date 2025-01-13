using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;

namespace CashMap
{
    public partial class Home : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseU"].ConnectionString;
        public Home()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;

            chart1.MouseMove += chart1_MouseMove;

        }
        private void update()
        {
            FillChart();

            date_init();
            Solde_V.Text = latest_sold() + " DH";
            NRevenus.Text = ntype("revenu");
            NDepenses.Text = ntype("depense");
        }
        private void updatec(object sender, FormClosedEventArgs e)
        {
            update();
        }

        private string ntype(string type)
        {
            int latestBalance = 0;

            string query = @"
            SELECT COUNT(*)
            FROM Transactions WHERE type = @type;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@type", type);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        // If a result was returned, convert it to decimal
                        if (result != DBNull.Value)
                        {
                            latestBalance = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return latestBalance.ToString();
        }
        private void FillChart()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataTable dt = new DataTable(); 
            conn.Open();
            SqlDataAdapter da=new SqlDataAdapter("SELECT montant_budget,date_transaction FROM Transactions",conn);
            da.Fill(dt);
            chart1.DataSource = dt;
            conn.Close();

            chart1.Series["Budget"].XValueMember = "date_transaction";
            chart1.Series["Budget"].YValueMembers = "montant_budget";

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
                        
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        public decimal latest_sold()
        {
            decimal latestBalance = 0;

            string query = @"
            SELECT TOP 1 montant_budget
            FROM Transactions
            ORDER BY id_transaction DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        // If a result was returned, convert it to decimal
                        if (result != DBNull.Value)
                        {
                            latestBalance = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return latestBalance;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureDatabaseExists();

            update();


        }

        private void EnsureDatabaseExists()
        {
            // Connection string to the SQL Server instance (not a specific database)

            string databaseName = "CashMap"; // Name of the database to check/create

            // SQL to check for the database and create it if it doesn't exist
            string createDatabaseQuery = $@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{databaseName}')
                BEGIN
                    CREATE DATABASE [{databaseName}]
                END";
            string createTableQuery = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transactions')
                BEGIN
                    CREATE TABLE Transactions (
                        id_transaction INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
                        montant DECIMAL(10, 2) NOT NULL,
                        date_transaction DATETIME NOT NULL,
                        montant_budget INT,
                        description VARCHAR(100),
                        type CHAR(7) NOT NULL CHECK (type IN ('depense', 'revenu')) 
                    )
                END";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur base de données: {ex.Message}");
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Revenus revenus = new Revenus();
            revenus.FormClosed += updatec;

            revenus.ShowDialog();
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            update();

        }

        private void Depences_Click(object sender, EventArgs e)
        {
            Depences dp = new Depences();
            dp.FormClosed += updatec;
            dp.ShowDialog();       }


        private void dateFin_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateDebutc = dateDebut.Value; 
            DateTime dateFinc = dateFin.Value; 

            // Check if dateDebut > dateFin
            if (dateDebutc >= dateFinc)
            {
                MessageBox.Show("La date de début doit être antérieure à la date de fin.", "Plage de dates invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateFin.Value = dateDebutc.AddDays(1); // Reset dateFin to match dateDebut
                return;
            }

            LoadChartDataByDate(dateDebutc, dateFinc);
        }

        private void dateDebut_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateDebutc = dateDebut.Value; 
            DateTime dateFinc = dateFin.Value; 

            // Check if dateDebut > dateFin
            if (dateDebutc >= dateFinc)
            {
                MessageBox.Show("La date de début doit être antérieure à la date de fin.", "Plage de dates invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateDebut.Value = dateFinc.AddDays(-1); 
                return;
            }

            LoadChartDataByDate(dateDebutc, dateFinc);
        }



        private void LoadChartDataByDate(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT montant_budget, date_transaction 
                FROM Transactions 
                WHERE date_transaction BETWEEN @startDate AND @endDate";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    da.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    da.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    chart1.DataSource = dt;
                    chart1.Series["Budget"].XValueMember = "date_transaction";
                    chart1.Series["Budget"].YValueMembers = "montant_budget";
                    chart1.DataBind();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}");
                }
            }
        }



        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the chart area
            var chartArea = chart1.ChartAreas[0];

            try
            {
                // Translate the cursor's pixel position to the chart's data coordinates
                double xValue = chartArea.AxisX.PixelPositionToValue(e.X);

                // Find the Y-range for the current series
                var series = chart1.Series[0]; // Assuming a single series
                double yMin = series.Points.Min(p => p.YValues[0]);
                double yMax = series.Points.Max(p => p.YValues[0]);

                // Ensure the vertical line annotation exists
                if (!chart1.Annotations.Any(a => a.Name == "CursorLine"))
                {
                    // Create a new vertical line annotation if it doesn't exist
                    var lineAnnotation = new VerticalLineAnnotation
                    {
                        Name = "CursorLine",
                        AxisX = chartArea.AxisX,
                        AxisY = chartArea.AxisY,
                        ClipToChartArea = chartArea.Name,
                        LineColor = Color.Red,
                        LineWidth = 1,
                        LineDashStyle = ChartDashStyle.Dash // Make the line dotted
                    };
                    chart1.Annotations.Add(lineAnnotation);
                }

                // Update the position of the vertical line annotation
                var annotation = (VerticalLineAnnotation)chart1.Annotations["CursorLine"];
                annotation.X = xValue; // Set the X position of the line

                // Find the nearest point to the current X value
                var nearestPoint = series.Points.OrderBy(p => Math.Abs(p.XValue - xValue)).FirstOrDefault();

                if (nearestPoint != null)
                {
                    // Set the starting Y position and dynamically calculate the height based on the nearest point
                    double nearestYValue = nearestPoint.YValues[0];  // Get the Y value of the nearest point
                    annotation.Y = nearestYValue;  // Set the Y position at the Y value of the nearest point
                    annotation.Height = yMax - yMin; // Keep the height constant based on the Y range

                    if (!chart1.Annotations.Any(a => a.Name == "CursorText"))
                    {
                        var textAnnotationn = new TextAnnotation
                        {
                            AxisX = chartArea.AxisX,
                            AxisY = chartArea.AxisY,
                            Name = "CursorText",
                            ForeColor = Color.Red,
                            Font = new Font("Arial", 10),
                            Alignment = ContentAlignment.MiddleCenter, // Align text to the center
                            AnchorAlignment = ContentAlignment.BottomCenter // Anchor at the bottom of the text
                        };
                        chart1.Annotations.Add(textAnnotationn);
                    }

                    // Update the text annotation to display the Y value next to the line
                    var textAnnotation = (TextAnnotation)chart1.Annotations["CursorText"];
                    textAnnotation.Text = $"{nearestPoint.YValues[0]:F2} DH"; // Format the Y value
                    textAnnotation.X = xValue + 0.1; // Position the text slightly to the right of the line
                    textAnnotation.Y = nearestYValue;

                }
            }
            catch
            {
                // Handle cases where the mouse is outside the chart area
                chart1.Annotations.Clear();
            }
        }

        private void Gestion_Click(object sender, EventArgs e)
        {
            exportF ee = new exportF();
            ee.ShowDialog();
        }
    }

}

