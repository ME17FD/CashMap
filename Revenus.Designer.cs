namespace CashMap
{
    partial class Revenus
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
            this.components = new System.ComponentModel.Container();
            this.cashMapDataSet = new CashMap.CashMapDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new CashMap.CashMapDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager = new CashMap.CashMapDataSetTableAdapters.TableAdapterManager();
            this.ajouterB = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.sold = new System.Windows.Forms.Label();
            this.motifT = new System.Windows.Forms.TextBox();
            this.montantT = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cashMapDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cashMapDataSet
            // 
            this.cashMapDataSet.DataSetName = "CashMapDataSet";
            this.cashMapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "Transactions";
            this.transactionsBindingSource.DataSource = this.cashMapDataSet;
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager.UpdateOrder = CashMap.CashMapDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ajouterB
            // 
            this.ajouterB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ajouterB.Location = new System.Drawing.Point(846, 549);
            this.ajouterB.Name = "ajouterB";
            this.ajouterB.Size = new System.Drawing.Size(97, 24);
            this.ajouterB.TabIndex = 31;
            this.ajouterB.Text = "Ajouter";
            this.ajouterB.UseVisualStyleBackColor = true;
            this.ajouterB.Click += new System.EventHandler(this.ajouterB_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePicker1.Location = new System.Drawing.Point(622, 551);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "motif";
            // 
            // sold
            // 
            this.sold.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sold.AutoSize = true;
            this.sold.BackColor = System.Drawing.SystemColors.Control;
            this.sold.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.sold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sold.Location = new System.Drawing.Point(98, 549);
            this.sold.Name = "sold";
            this.sold.Size = new System.Drawing.Size(76, 20);
            this.sold.TabIndex = 28;
            this.sold.Text = "montant";
            // 
            // motifT
            // 
            this.motifT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.motifT.Location = new System.Drawing.Point(384, 549);
            this.motifT.Name = "motifT";
            this.motifT.Size = new System.Drawing.Size(215, 22);
            this.motifT.TabIndex = 27;
            // 
            // montantT
            // 
            this.montantT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.montantT.Location = new System.Drawing.Point(194, 549);
            this.montantT.Name = "montantT";
            this.montantT.Size = new System.Drawing.Size(86, 22);
            this.montantT.TabIndex = 26;
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
            this.dataGridView1.Location = new System.Drawing.Point(102, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(899, 503);
            this.dataGridView1.TabIndex = 32;
            // 
            // Revenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 585);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ajouterB);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sold);
            this.Controls.Add(this.motifT);
            this.Controls.Add(this.montantT);
            this.Name = "Revenus";
            this.Text = "Revenus";
            this.Load += new System.EventHandler(this.Revenus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cashMapDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CashMapDataSet cashMapDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private CashMapDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private CashMapDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button ajouterB;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sold;
        private System.Windows.Forms.TextBox motifT;
        private System.Windows.Forms.TextBox montantT;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}