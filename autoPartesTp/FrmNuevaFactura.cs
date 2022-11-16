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
            nuevo = new Factura();
        }


        private async void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            await numFactura();
            panel2.Enabled = false;
            dtpFechaFactura.Value = DateTime.Now;
            dtpFechaFactura.Enabled = false;

            //cargarClientesAsync();
            //cargarVendedoresAsync();
            //   cargarArticuloAsync();
            await cargarCombo<AutoParte>(cboArticulo, "AUTOPARTES", "descripcion", "idArticulo");

            await cargarCombo<Cliente>(cboCliente, "CLIENTES", "nombre", "idCliente");

            await cargarCombo<Vendedor>(cboVendedor, "VENDEDORES", "nombre", "idVendedor");





        }








        private async Task numFactura()
        {
            string url = "https://localhost:7035/PROXID";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<int>(result);
            int proxNum = lst;
            lblFactura.Text = $"Factura Nro: {proxNum}.";
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
            if (validacionesDos())
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
                    dt.descuento = Convert.ToInt32(numericBonificacion.Value);
                }

                nuevo.AgregarDetalle(dt);

                dgvDetalleFactura.Rows.Add(new object[] { ap.descripcion.ToString(), ap.precio, dt.cantidad, dt.subTotal().ToString() });
                actualizarCampoTotales();
            }


        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        //------------Methods -------------------

        private async Task cargarCombo<T>(ComboBox cbo, string controller, string display, string value)
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
            lblTotal.Text = $"Total: {nuevo.total()}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cargarCombo<Cliente>(cboArticulo, "CLIENTES", "idCliente", "nombre");
            //cargarCombo<AutoParte>(cboArticulo, "AUTOPARTES", "Id", "Descripcion");

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (validacionTres())
            {
                //guardar factura
                nuevo.cliente = (Cliente)cboCliente.SelectedItem;
                nuevo.vendedor = (Vendedor)cboVendedor.SelectedItem;
                nuevo.fechaFactura = dtpFechaFactura.Value;

                string bodyContent = JsonConvert.SerializeObject(nuevo);

                string url = "https://localhost:7035/ADDFAC";
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

        private void dgvDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleFactura.CurrentCell.ColumnIndex == 4)
            {
                dgvDetalleFactura.Rows.RemoveAt(e.RowIndex);
                nuevo.QuitarDetalle(e.RowIndex);
                actualizarCampoTotales();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (validacionUno())
            {
                button2.Enabled = false;
                panel1.Enabled = false;
                panel2.Enabled = true;
            }

        }

        private bool validacionUno()
        {
            if (cboCliente.Text == String.Empty)
            {
                MessageBox.Show("Incompleto", "Debe seleccionar un Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboVendedor.Text == String.Empty)
            {
                MessageBox.Show("Incompleto", "Debe seleccionar un Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }


        private bool validacionesDos()
        {
            bool ok = true;
            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                if (row.Cells[0].Value.ToString() == cboArticulo.Text)
                {
                    ok = false;
                    MessageBox.Show("Articulo: " + cboArticulo.Text + " ya se encuentra en el detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return ok;
                }
            }
            return ok;
        }

        private bool validacionTres()
        {
            bool ok = true;
            if(dgvDetalleFactura.Rows.Count == 0)
            {
                ok = false;
                MessageBox.Show("Debe seleccionar al menos un Articulo!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ok;
            }
            return ok;
        }
    }
}
