namespace CashMap
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.Accueil = new System.Windows.Forms.ToolStripMenuItem();
            this.Acceuil = new System.Windows.Forms.ToolStripMenuItem();
            this.Depences = new System.Windows.Forms.ToolStripMenuItem();
            this.Gestion = new System.Windows.Forms.ToolStripMenuItem();
            this.Solde_V = new System.Windows.Forms.Label();
            this.sold = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.dateDebut = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NRevenus = new System.Windows.Forms.Label();
            this.NDepenses = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.Accueil,
            this.Acceuil,
            this.Depences,
            this.Gestion});
            this.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Margin = new System.Windows.Forms.Padding(15);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(185, 604);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Transcity", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(168, 47);
            this.toolStripTextBox1.Text = "CashMap";
            this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Accueil
            // 
            this.Accueil.AutoSize = false;
            this.Accueil.Image = ((System.Drawing.Image)(resources.GetObject("Accueil.Image")));
            this.Accueil.Name = "Accueil";
            this.Accueil.Size = new System.Drawing.Size(177, 44);
            this.Accueil.Text = "Accueil";
            this.Accueil.Click += new System.EventHandler(this.Accueil_Click);
            // 
            // Acceuil
            // 
            this.Acceuil.AutoSize = false;
            this.Acceuil.Image = ((System.Drawing.Image)(resources.GetObject("Acceuil.Image")));
            this.Acceuil.Name = "Acceuil";
            this.Acceuil.Size = new System.Drawing.Size(177, 44);
            this.Acceuil.Text = "Revenus";
            this.Acceuil.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Depences
            // 
            this.Depences.AutoSize = false;
            this.Depences.Image = ((System.Drawing.Image)(resources.GetObject("Depences.Image")));
            this.Depences.Name = "Depences";
            this.Depences.Size = new System.Drawing.Size(177, 44);
            this.Depences.Text = "Depences";
            this.Depences.Click += new System.EventHandler(this.Depences_Click);
            // 
            // Gestion
            // 
            this.Gestion.AutoSize = false;
            this.Gestion.Image = ((System.Drawing.Image)(resources.GetObject("Gestion.Image")));
            this.Gestion.Name = "Gestion";
            this.Gestion.Size = new System.Drawing.Size(177, 28);
            this.Gestion.Text = "Export";
            this.Gestion.Click += new System.EventHandler(this.Gestion_Click);
            // 
            // Solde_V
            // 
            this.Solde_V.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Solde_V.AutoSize = true;
            this.Solde_V.BackColor = System.Drawing.SystemColors.Control;
            this.Solde_V.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solde_V.Location = new System.Drawing.Point(1107, 109);
            this.Solde_V.Name = "Solde_V";
            this.Solde_V.Size = new System.Drawing.Size(37, 16);
            this.Solde_V.TabIndex = 22;
            this.Solde_V.Text = "0 DH";
            // 
            // sold
            // 
            this.sold.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sold.AutoSize = true;
            this.sold.BackColor = System.Drawing.SystemColors.Control;
            this.sold.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.sold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sold.Location = new System.Drawing.Point(979, 107);
            this.sold.Name = "sold";
            this.sold.Size = new System.Drawing.Size(127, 20);
            this.sold.TabIndex = 21;
            this.sold.Text = "Solde Actuel :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "à";
            // 
            // dateFin
            // 
            this.dateFin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateFin.Location = new System.Drawing.Point(667, 528);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(200, 22);
            this.dateFin.TabIndex = 18;
            this.dateFin.ValueChanged += new System.EventHandler(this.dateFin_ValueChanged);
            // 
            // dateDebut
            // 
            this.dateDebut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateDebut.Location = new System.Drawing.Point(361, 528);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Size = new System.Drawing.Size(200, 22);
            this.dateDebut.TabIndex = 17;
            this.dateDebut.ValueChanged += new System.EventHandler(this.dateDebut_ValueChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea3.AxisX.Crossing = 1.7976931348623157E+308D;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.IsStartedFromZero = false;
            chartArea3.AxisX.MajorGrid.Interval = 0D;
            chartArea3.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisX.Title = "Date";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea3.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(186, 62);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Budget";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(790, 454);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1011, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(979, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Nombre de revenus : ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(979, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Nombre de revenus : ";
            // 
            // NRevenus
            // 
            this.NRevenus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NRevenus.AutoSize = true;
            this.NRevenus.BackColor = System.Drawing.SystemColors.Control;
            this.NRevenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NRevenus.Location = new System.Drawing.Point(1189, 189);
            this.NRevenus.Name = "NRevenus";
            this.NRevenus.Size = new System.Drawing.Size(37, 16);
            this.NRevenus.TabIndex = 29;
            this.NRevenus.Text = "0 DH";
            // 
            // NDepenses
            // 
            this.NDepenses.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NDepenses.AutoSize = true;
            this.NDepenses.BackColor = System.Drawing.SystemColors.Control;
            this.NDepenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NDepenses.Location = new System.Drawing.Point(1189, 257);
            this.NDepenses.Name = "NDepenses";
            this.NDepenses.Size = new System.Drawing.Size(37, 16);
            this.NDepenses.TabIndex = 30;
            this.NDepenses.Text = "0 DH";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 604);
            this.Controls.Add(this.NDepenses);
            this.Controls.Add(this.NRevenus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Solde_V);
            this.Controls.Add(this.sold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFin);
            this.Controls.Add(this.dateDebut);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "CashMap";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Acceuil;
        private System.Windows.Forms.ToolStripMenuItem Accueil;
        private System.Windows.Forms.ToolStripMenuItem Depences;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private DataSet1TableAdapters.lignecommandeTableAdapter lignecommandeTableAdapter1;
        private System.Windows.Forms.ToolStripMenuItem Gestion;
        private System.Windows.Forms.Label Solde_V;
        private System.Windows.Forms.Label sold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.DateTimePicker dateDebut;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label NRevenus;
        private System.Windows.Forms.Label NDepenses;
    }
}

