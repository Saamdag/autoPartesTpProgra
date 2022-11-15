using autoPartesTp.Http;
using Ddl.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoPartesTp
{
    public partial class FrmUpAutoParte : Form
    {
        private AutoParte autoParte;
        public FrmUpAutoParte(AutoParte ap)
        {
            InitializeComponent();
            autoParte = ap;
        }

        private async void FrmUpAutoParte_Load(object sender, EventArgs e)
        {
            await cargarCombo<Marca>(cboMarcas, "ControllerMarca", "nombre", "id");
            await cargarCombo<Modelo>(cboModelo, "ControllerModelo", "nombre", "id");
            await cargarCombo<tipoProduccion>(cboTipoProd, "ControllerTipo", "tipo", "id");

            cargarautoParte();

            txtDesc.Enabled = false;
        }

        private void cargarautoParte()
        {
            txtDesc.Text = autoParte.descripcion.ToString();
            cboTipoProd.Text = autoParte.tipoProduccion.tipo;
            cboMarcas.Text = autoParte.Marca.nombre;
            cboModelo.Text = autoParte.Modelo.nombre;
            txtPrecio.Value = autoParte.precio;
            if (autoParte.activo == 1)
            {
                rbtnActivo.Checked = true;
                rbtnNoActivo.Checked = false;
            }
            else
            {
                rbtnNoActivo.Checked = true;
                rbtnActivo.Checked = false;
            }

        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            updateAutoParte();

        }

        private async void updateAutoParte()
        {
            autoParte.precio = txtPrecio.Value;
            autoParte.tipoProduccion = (tipoProduccion)cboTipoProd.SelectedItem;
            autoParte.fechaFabricacion = dtPicker.Value;
            autoParte.Marca = (Marca)cboMarcas.SelectedItem;
            autoParte.Modelo = (Modelo)cboModelo.SelectedItem;
            autoParte.activo = 0;
            if (rbtnActivo.Checked)
                autoParte.activo = 1;

            string bodyContent = JsonConvert.SerializeObject(autoParte);


            string url = "https://localhost:7035/UPAP";
            var result = await ClientSingleton.GetInstance().PutAsync(url, bodyContent);

            if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
            {
                MessageBox.Show("AutoParte Actualizada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo actualizar la AutoParte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
