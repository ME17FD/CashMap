namespace CashMap
{
    partial class Depences
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.montantT = new System.Windows.Forms.TextBox();
            this.motifT = new System.Windows.Forms.TextBox();
            this.sold = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ajouterB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(158, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(899, 503);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // montantT
            // 
            this.montantT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.montantT.Location = new System.Drawing.Point(281, 549);
            this.montantT.Name = "montantT";
            this.montantT.Size = new System.Drawing.Size(87, 22);
            this.montantT.TabIndex = 3;
            // 
            // motifT
            // 
            this.motifT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.motifT.Location = new System.Drawing.Point(452, 549);
            this.motifT.Name = "motifT";
            this.motifT.Size = new System.Drawing.Size(235, 22);
            this.motifT.TabIndex = 4;
            // 
            // sold
            // 
            this.sold.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sold.AutoSize = true;
            this.sold.BackColor = System.Drawing.SystemColors.Control;
            this.sold.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.sold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sold.Location = new System.Drawing.Point(186, 549);
            this.sold.Name = "sold";
            this.sold.Size = new System.Drawing.Size(76, 20);
            this.sold.TabIndex = 22;
            this.sold.Text = "montant";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(381, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "motif";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePicker1.Location = new System.Drawing.Point(710, 551);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // ajouterB
            // 
            this.ajouterB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ajouterB.Location = new System.Drawing.Point(935, 549);
            this.ajouterB.Name = "ajouterB";
            this.ajouterB.Size = new System.Drawing.Size(97, 24);
            this.ajouterB.TabIndex = 25;
            this.ajouterB.Text = "Ajouter";
            this.ajouterB.UseVisualStyleBackColor = true;
            this.ajouterB.Click += new System.EventHandler(this.ajouterB_Click);
            // 
            // Depences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 596);
            this.Controls.Add(this.ajouterB);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sold);
            this.Controls.Add(this.motifT);
            this.Controls.Add(this.montantT);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Depences";
            this.Text = "Depenses";
            this.Load += new System.EventHandler(this.Depences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox montantT;
        private System.Windows.Forms.TextBox motifT;
        private System.Windows.Forms.Label sold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button ajouterB;
    }
}