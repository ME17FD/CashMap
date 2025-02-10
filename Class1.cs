using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CashMap
{
    public class pdf
    {
        //private string connectionString = "Server=MEFD\\SQLEXPRESS;Database=CashMap;Integrated Security=True";
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

        public void GenerateFinancialReportGraphs(DateTime startDate, DateTime endDate, string filePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query for financial report
                    string reportQuery = "SELECT id_transaction, date_transaction, montant, montant_budget, description, type FROM Transactions WHERE date_transaction BETWEEN @startDate AND @endDate ORDER BY date_transaction";
                    SqlDataAdapter reportDa = new SqlDataAdapter(reportQuery, conn);
                    reportDa.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    reportDa.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                    DataTable reportDt = new DataTable();
                    reportDa.Fill(reportDt);

                    // Query for graphs
                    string graphQuery = "SELECT date_transaction, montant_budget AS total FROM Transactions WHERE date_transaction BETWEEN @startDate AND @endDate ORDER BY date_transaction";
                    SqlDataAdapter graphDa = new SqlDataAdapter(graphQuery, conn);
                    graphDa.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    graphDa.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                    DataTable graphDt = new DataTable();
                    graphDa.Fill(graphDt);

                    // Create a new PDF document
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = "Rapport financier";

                    // Page 1: Financial Report
                    PdfPage reportPage = pdf.AddPage();
                    XGraphics reportGfx = XGraphics.FromPdfPage(reportPage);

                    // Define fonts
                    XFont titleFont = new XFont("Verdana", 20, XFontStyleEx.Bold);
                    XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
                    XFont contentFont = new XFont("Verdana", 10, XFontStyleEx.Regular);

                    // Draw title
                    reportGfx.DrawString("Rapport financier", titleFont, XBrushes.Black, new XRect(0, 20, reportPage.Width, 40), XStringFormats.TopCenter);

                    // Draw date range
                    reportGfx.DrawString($"De: {startDate:dd/MM/yyyy} à: {endDate:dd/MM/yyyy}", contentFont, XBrushes.Black, new XRect(0, 60, reportPage.Width, 20), XStringFormats.TopCenter);

                    // Define table dimensions
                    double startX = 40;
                    double startY = 100;
                    double[] columnWidths = { 50, 80, 200, 80, 80 }; // Adjusted column widths
                    double rowHeight = 20;

                    // Draw table header
                    double currentX = startX;
                    reportGfx.DrawRectangle(XPens.Black, currentX, startY, columnWidths.Sum(), rowHeight);

                    string[] headers = { "ID", "Date", "Description", "Debit (Dh)", "Credit (Dh)" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        reportGfx.DrawString(headers[i], headerFont, XBrushes.Black, new XRect(currentX, startY, columnWidths[i], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[i];
                    }

                    // Draw table rows
                    double currentY = startY + rowHeight;
                    decimal finalBalance = 0;

                    foreach (DataRow row in reportDt.Rows)
                    {
                        currentX = startX;

                        reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[0], rowHeight);
                        reportGfx.DrawString(row["id_transaction"].ToString(), contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[0], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[0];

                        reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[1], rowHeight);
                        reportGfx.DrawString(Convert.ToDateTime(row["date_transaction"]).ToString("dd/MM/yyyy"), contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[1], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[1];

                        reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[2], rowHeight);
                        reportGfx.DrawString(row["description"].ToString(), contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[2], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[2];

                        decimal montant;
                        if (decimal.TryParse(row["montant"].ToString(), out montant))
                        {
                            if (row["type"].ToString().Equals("depense"))
                            {
                                reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[3], rowHeight);
                                reportGfx.DrawString($"{montant}", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[3], rowHeight), XStringFormats.Center);
                                currentX += columnWidths[3];

                                reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[4], rowHeight);
                                reportGfx.DrawString("-", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[4], rowHeight), XStringFormats.Center);
                            }
                            else
                            {
                                reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[3], rowHeight);
                                reportGfx.DrawString("-", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[3], rowHeight), XStringFormats.Center);
                                currentX += columnWidths[3];

                                reportGfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[4], rowHeight);
                                reportGfx.DrawString($"{montant}", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[4], rowHeight), XStringFormats.Center);
                            }
                        }

                        currentY += rowHeight;
                        finalBalance = Convert.ToDecimal(row["montant_budget"]);
                    }

                    // Calculate and display capital and final balance
                    reportGfx.DrawString($"Solde final: {finalBalance} Dh", headerFont, XBrushes.Black, new XRect(startX, currentY + 40, reportPage.Width, 20), XStringFormats.TopLeft);

                    // Page 2: Graphs
                    PdfPage graphPage = pdf.AddPage();
                    XGraphics graphGfx = XGraphics.FromPdfPage(graphPage);

                    // Generate Graphs
                    Bitmap budgetGraph = GenerateBudgetGraph(graphDt);
                    Bitmap changesGraph = GenerateBudgetChangesGraph(graphDt);
                    Bitmap changesGraph2 = GenerateBudgetChangesGraph2(graphDt);

                    // Convert Bitmap to XImage
                    XImage budgetImg = ConvertBitmapToXImage(budgetGraph);
                    XImage changesImg1 = ConvertBitmapToXImage(changesGraph);
                    XImage changesImg2 = ConvertBitmapToXImage(changesGraph2);

                    // Draw graphs on the second page
                    graphGfx.DrawImage(budgetImg, 50, 20, 500, 200);
                    graphGfx.DrawImage(changesImg1, 50, 220, 500, 200);
                    graphGfx.DrawImage(changesImg2, 50, 420, 500, 200);

                    // Save the PDF
                    pdf.Save(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Bitmap GenerateBudgetGraph(DataTable dt)
        {
            Chart chart = new Chart();
            chart.Width = 480;  // Half of the PDF width
            chart.Height = 300;

            ChartArea chartArea = new ChartArea("Budget Over Time");
            chartArea.BackColor = Color.FromArgb(192, 255, 192);
            chartArea.AxisX.Title = "Date";
            chartArea.AxisX.TitleFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Format = "dd/MM";
            chartArea.AxisX.MajorGrid.LineColor = Color.Silver;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisY.MajorGrid.LineColor = Color.Silver;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart.ChartAreas.Add(chartArea);

            Series budgetSeries = new Series("Budget");
            budgetSeries.ChartType = SeriesChartType.Line;
            budgetSeries.BorderWidth = 3;
            budgetSeries.XValueType = ChartValueType.Date;
            budgetSeries.YValueType = ChartValueType.Double;
            budgetSeries.Color = Color.Blue;
            budgetSeries.ChartArea = "Budget Over Time";

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["date_transaction"]);
                double total = Convert.ToDouble(row["total"]);
                budgetSeries.Points.AddXY(date, total);
            }

            chart.Series.Add(budgetSeries);

            Bitmap bmp = new Bitmap(480, 300);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, 480, 300));

            return bmp;
        }

        private Bitmap GenerateBudgetChangesGraph2(DataTable dt)
        {
            Chart chart = new Chart();
            chart.Size = new Size(600, 300);
            chart.BackColor = Color.White;

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Date";
            chartArea.AxisY.Title = "Change in Budget";
            chart.ChartAreas.Add(chartArea);

            Series seriesPositive = new Series("Increase");
            seriesPositive.ChartType = SeriesChartType.Column;
            seriesPositive.Color = Color.Green;  // ✅ Positive changes in Green

            Series seriesNegative = new Series("Decrease");
            seriesNegative.ChartType = SeriesChartType.Column;
            seriesNegative.Color = Color.Red;  // ❌ Negative changes in Red

            decimal previousBudget = 0;
            bool firstEntry = true;

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["date_transaction"]);
                decimal budget = Convert.ToDecimal(row["total"]);

                if (!firstEntry)
                {
                    decimal change = budget - previousBudget;
                    if (change >= 0)
                        seriesPositive.Points.AddXY(date, change);  // ✅ Green bar for increase
                    else
                        seriesNegative.Points.AddXY(date, Math.Abs(change));  // ❌ Red bar for decrease
                }

                previousBudget = budget;
                firstEntry = false;
            }

            chart.Series.Add(seriesPositive);
            chart.Series.Add(seriesNegative);

            Bitmap bitmap = new Bitmap(600, 300);
            chart.DrawToBitmap(bitmap, new Rectangle(0, 0, 600, 300));
            return bitmap;
        }
        private Bitmap GenerateBudgetChangesGraph(DataTable dt)
        {
            Chart chart = new Chart();
            chart.Width = 480;  // Half of the PDF width
            chart.Height = 300;

            ChartArea chartArea = new ChartArea("Budget Changes");
            chartArea.BackColor = Color.FromArgb(192, 255, 192);
            chartArea.AxisX.Title = "Date";
            chartArea.AxisX.TitleFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Format = "dd/MM";
            chartArea.AxisX.MajorGrid.LineColor = Color.Silver;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisY.MajorGrid.LineColor = Color.Silver;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart.ChartAreas.Add(chartArea);

            Series changesSeries = new Series("Budget Changes");
            changesSeries.ChartType = SeriesChartType.Column;  // Bar chart
            changesSeries.BorderWidth = 2;
            changesSeries.XValueType = ChartValueType.Date;
            changesSeries.YValueType = ChartValueType.Double;
            changesSeries.ChartArea = "Budget Changes";

            double previousBudget = 0;
            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["date_transaction"]);
                double total = Convert.ToDouble(row["total"]);

                if (previousBudget != 0)
                {
                    double change = total - previousBudget;
                    int pointIndex = changesSeries.Points.AddXY(date, change); // AddXY returns the index of the added point

                    // Access the DataPoint using the index and set its color
                    if (change >= 0)
                    {
                        changesSeries.Points[pointIndex].Color = Color.Green;  // Positive change in green
                    }
                    else
                    {
                        changesSeries.Points[pointIndex].Color = Color.Red;    // Negative change in red
                    }
                }
                previousBudget = total;
            }

            chart.Series.Add(changesSeries);

            Bitmap bmp = new Bitmap(480, 300);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, 480, 300));

            return bmp;
        }



        private XImage ConvertBitmapToXImage(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap), "Bitmap cannot be null");
            }

            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);  // Ensure it's saved as PNG
                stream.Position = 0;  // Reset stream position
                return XImage.FromStream(stream);
            }
        }


    }
}
