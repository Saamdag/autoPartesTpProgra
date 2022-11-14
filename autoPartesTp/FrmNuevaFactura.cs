using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using autoPartesTp.Http;
using Ddl.Dominio;
using Newtonsoft.Json;

namespace autoPartesTp
{
    public partial class FrmNuevaFactura : Form
    {
        

        Factura nuevo;
        public FrmNuevaFactura()
        {
            InitializeComponent();
           nuevo= new Factura();
        }


        private async void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            //cargarClientesAsync();
            //cargarVendedoresAsync();
            //   cargarArticuloAsync();
            await cargarCombo<AutoParte>(cboArticulo, "AUTOPARTES", "descripcion", "idArticulo");

            await cargarCombo<Cliente>(cboCliente, "CLIENTES", "nombre", "idCliente");

            await cargarCombo<Vendedor>(cboVendedor, "VENDEDORES", "nombre", "idVendedor");



        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void cboArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DetalleFactura dt = new DetalleFactura();
            AutoParte ap = (AutoParte)cboArticulo.SelectedItem;
            dt.cantidad = (int)nudCantidad.Value;
            dt.AutoParte = ap;
            dt.bonificacion = 0;
            dt.descuento = 0;
            if (numericBonificacion.Value > 0)
            {
                dt.bonificacion = 1;
                dt.descuento =Convert.ToInt32(numericBonificacion.Value);

            }

            nuevo.AgregarDetalle(dt);


            
            dgvDetalleFactura.Rows.Add(new object[] { ap.descripcion.ToString(), ap.precio,dt.cantidad });
            actualizarCampoTotales();
            

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        //------------Methods -------------------
        private async void cargarVendedoresAsync()
        {
            string url = "https://localhost:7035/VENDEDORES";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Vendedor>>(result);
            cboVendedor.DataSource = lst;
            cboVendedor.DisplayMember = "apellido";
            cboVendedor.ValueMember = "idVendedor";
            cboVendedor.SelectedIndex = -1;
        }

        private async Task cargarCombo<T>(ComboBox cbo,string controller,string display,string value)
        {
            string url = $"https://localhost:7035/{controller}";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<T>>(result);
            cbo.DataSource = lst;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }






        private void actualizarCampoTotales()
        {
            decimal sub =0;
            Factura fac = new Factura();
            foreach(DetalleFactura DT in nuevo.detalleFactura)
            {
                sub += DT.subTotal();
            }


            //lblSubTotal.Text = $"Subtotal : {sub}";
            //dt.descuento = dt.calcularAhorro(Convert.ToDecimal(txtBonificacion.Text));
            //lblAhorro.Text = $"Ahorro : {dt.descuento}";
            //lblFactura.Text = $"Total : {fac.total(dt.descuento)}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cargarCombo<Cliente>(cboArticulo, "CLIENTES", "idCliente", "nombre");
            //cargarCombo<AutoParte>(cboArticulo, "AUTOPARTES", "Id", "Descripcion");

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //guardar factura
            nuevo.cliente = (Cliente)cboCliente.SelectedItem;
            nuevo.vendedor = (Vendedor)cboVendedor.SelectedItem;
            nuevo.fechaFactura = dtpFechaFactura.Value;

            string bodyContent = JsonConvert.SerializeObject(nuevo);

            string url = "http://localhost:7035/ADDFAC";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
            {
                MessageBox.Show("Factura registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
