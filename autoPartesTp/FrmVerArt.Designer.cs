﻿namespace autoPartesTp
{
    partial class FrmVerArt
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
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDesc,
            this.colFecha,
            this.colTipoProd,
            this.colActivo,
            this.colPreci,
            this.colMarca,
            this.colModelo});
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(744, 320);
            this.dataGridView1.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "Descripcion";
            this.colDesc.Name = "colDesc";
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha Fabricacion";
            this.colFecha.Name = "colFecha";
            // 
            // colTipoProd
            // 
            this.colTipoProd.HeaderText = "Tipo Produccion";
            this.colTipoProd.Name = "colTipoProd";
            // 
            // colActivo
            // 
            this.colActivo.HeaderText = "Estado";
            this.colActivo.Name = "colActivo";
            // 
            // colPreci
            // 
            this.colPreci.HeaderText = "Precio";
            this.colPreci.Name = "colPreci";
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            // 
            // colModelo
            // 
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.Name = "colModelo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Activo",
            "No Activo"});
            this.cboEstado.Location = new System.Drawing.Point(248, 55);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 23);
            this.cboEstado.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Estado";
            // 
            // FrmVerArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmVerArt";
            this.Text = "FrmVerArt";
            this.Load += new System.EventHandler(this.FrmVerArt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTipoProd;
        private DataGridViewTextBoxColumn colActivo;
        private DataGridViewTextBoxColumn colPreci;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colModelo;
        private ComboBox cboEstado;
        private Label label2;
    }
}