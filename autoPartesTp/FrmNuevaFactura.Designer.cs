namespace autoPartesTp
{
    partial class FrmNuevaFactura
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
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboArticulo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericBonificacion = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBonificacion)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(78, 11);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(246, 23);
            this.cboCliente.TabIndex = 0;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Location = new System.Drawing.Point(78, 83);
            this.dtpFechaFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(246, 23);
            this.dtpFechaFactura.TabIndex = 2;
            this.dtpFechaFactura.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cboVendedor
            // 
            this.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(78, 46);
            this.cboVendedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(246, 23);
            this.cboVendedor.TabIndex = 3;
            this.cboVendedor.SelectedIndexChanged += new System.EventHandler(this.cboVendedor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vendedor";
            // 
            // cboArticulo
            // 
            this.cboArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticulo.FormattingEnabled = true;
            this.cboArticulo.Location = new System.Drawing.Point(98, 18);
            this.cboArticulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboArticulo.Name = "cboArticulo";
            this.cboArticulo.Size = new System.Drawing.Size(249, 23);
            this.cboArticulo.TabIndex = 6;
            this.cboArticulo.SelectedIndexChanged += new System.EventHandler(this.cboArticulo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Articulo";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(98, 53);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(248, 23);
            this.nudCantidad.TabIndex = 8;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Bonificacion";
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblFactura.Location = new System.Drawing.Point(35, 17);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(148, 30);
            this.lblFactura.TabIndex = 12;
            this.lblFactura.Text = "Factura Nro: ";
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.AllowUserToOrderColumns = true;
            this.dgvDetalleFactura.AllowUserToResizeColumns = false;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colPrecio,
            this.colCantidad,
            this.Column1,
            this.Column2});
            this.dgvDetalleFactura.Location = new System.Drawing.Point(424, 48);
            this.dgvDetalleFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.RowHeadersWidth = 51;
            this.dgvDetalleFactura.RowTemplate.Height = 29;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(561, 255);
            this.dgvDetalleFactura.TabIndex = 13;
            this.dgvDetalleFactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleFactura_CellContentClick);
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Importe";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Eliminar";
            this.Column2.Name = "Column2";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(761, 321);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(32, 15);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(265, 87);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(82, 22);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericBonificacion
            // 
            this.numericBonificacion.Location = new System.Drawing.Point(98, 83);
            this.numericBonificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericBonificacion.Name = "numericBonificacion";
            this.numericBonificacion.Size = new System.Drawing.Size(56, 23);
            this.numericBonificacion.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "%";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboCliente);
            this.panel1.Controls.Add(this.dtpFechaFactura);
            this.panel1.Controls.Add(this.cboVendedor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(61, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 145);
            this.panel1.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboArticulo);
            this.panel2.Controls.Add(this.numericBonificacion);
            this.panel2.Controls.Add(this.nudCantidad);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(60, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 142);
            this.panel2.TabIndex = 24;
            // 
            // FrmNuevaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvDetalleFactura);
            this.Controls.Add(this.lblFactura);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmNuevaFactura";
            this.Text = "FrmNuevaFactura";
            this.Load += new System.EventHandler(this.FrmNuevaFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBonificacion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboCliente;
        private Label label1;
        private DateTimePicker dtpFechaFactura;
        private ComboBox cboVendedor;
        private Label label2;
        private Label label3;
        private ComboBox cboArticulo;
        private Label label4;
        private NumericUpDown nudCantidad;
        private Label label5;
        private Label label6;
        private Label lblFactura;
        private DataGridView dgvDetalleFactura;
        private Label lblTotal;
        private Label lblAhorro;
        private Label lblSubTotal;
        private Button btnAgregar;
        private Button button1;
        private NumericUpDown numericBonificacion;
        private Label label7;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewButtonColumn Column2;
        private Panel panel1;
        private Button button2;
        private Panel panel2;
    }
}