using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CashMap
{
    public class pdf
    {
        //private string connectionString = "Server=MEFD\\SQLEXPRESS;Database=CashMap;Integrated Security=True";
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

        public void GenerateFinancialReport(DateTime startDate, DateTime endDate, string filePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_transaction, date_transaction, montant, montant_budget, description, type FROM Transactions WHERE date_transaction BETWEEN @startDate AND @endDate ORDER BY date_transaction";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    da.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Create a new PDF document
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = "Rapport financier";

                    PdfPage page = pdf.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Define fonts
                    XFont titleFont = new XFont("Verdana", 20, XFontStyleEx.Bold);
                    XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
                    XFont contentFont = new XFont("Verdana", 10, XFontStyleEx.Regular);

                    // Draw title
                    gfx.DrawString("Rapport financier", titleFont, XBrushes.Black, new XRect(0, 20, page.Width, 40), XStringFormats.TopCenter);

                    // Draw date range
                    gfx.DrawString($"De: {startDate:dd/MM/yyyy} à: {endDate:dd/MM/yyyy}", contentFont, XBrushes.Black, new XRect(0, 60, page.Width, 20), XStringFormats.TopCenter);

                    // Define table dimensions
                    double startX = 40;
                    double startY = 100;
                    double[] columnWidths = { 50, 80, 200, 80, 80 }; // Adjusted column widths
                    double rowHeight = 20;

                    // Draw table header
                    double currentX = startX;
                    gfx.DrawRectangle(XPens.Black, currentX, startY, columnWidths.Sum(), rowHeight);

                    string[] headers = { "ID", "Date", "Description", "Debit (Dh)", "Credit (Dh)" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        gfx.DrawString(headers[i], headerFont, XBrushes.Black, new XRect(currentX, startY, columnWidths[i], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[i];
                    }

                    // Draw table rows
                    double currentY = startY + rowHeight;
                    decimal finalBalance = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        currentX = startX;

                        gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[0], rowHeight);
                        gfx.DrawString(row["id_transaction"].ToString(), contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[0], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[0];

                        gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[1], rowHeight);
                        gfx.DrawString(Convert.ToDateTime(row["date_transaction"]).ToString("dd/MM/yyyy"), contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[1], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[1];

                        gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[2], rowHeight);
                        gfx.DrawString(row["description"].ToString(), contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[2], rowHeight), XStringFormats.Center);
                        currentX += columnWidths[2];

                        decimal montant;
                        if (decimal.TryParse(row["montant"].ToString(), out montant))
                        {
                            if (row["type"].ToString().Equals("depense"))
                            {
                                gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[3], rowHeight);
                                gfx.DrawString($"{montant}", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[3], rowHeight), XStringFormats.Center);
                                currentX += columnWidths[3];

                                gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[4], rowHeight);
                                gfx.DrawString("", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[4], rowHeight), XStringFormats.Center);

                            }
                            else
                            {
                                gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[3], rowHeight);
                                gfx.DrawString("", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[3], rowHeight), XStringFormats.Center);
                                currentX += columnWidths[3];

                                gfx.DrawRectangle(XPens.Black, currentX, currentY, columnWidths[4], rowHeight);
                                gfx.DrawString($"{montant}", contentFont, XBrushes.Black, new XRect(currentX, currentY, columnWidths[4], rowHeight), XStringFormats.Center);
                            }
                        }

                        currentY += rowHeight;
                        finalBalance = Convert.ToDecimal(row["montant_budget"]);
                    }

                    // Calculate and display capital and final balance
                    decimal totalCapital = dt.AsEnumerable().Sum(r => r.Field<decimal>("montant"));

                    gfx.DrawString($"Capital: {totalCapital} Dh", headerFont, XBrushes.Black, new XRect(startX, currentY + 20, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Solde final: {finalBalance} Dh", headerFont, XBrushes.Black, new XRect(startX, currentY + 40, page.Width, 20), XStringFormats.TopLeft);

                    // Save the PDF
                    pdf.Save(filePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
