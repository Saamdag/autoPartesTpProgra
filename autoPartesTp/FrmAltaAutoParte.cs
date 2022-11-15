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
    public partial class FrmAltaAutoParte : Form
    {
        AutoParte ap;
        public FrmAltaAutoParte()
        {
            InitializeComponent();
            ap =  new AutoParte();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

         await guardarAutoparte();
        }

        private async Task guardarAutoparte()
        {
            ap.precio = txtPrecio.Value; 
            ap.tipoProduccion = (tipoProduccion)cboTipoProd.SelectedItem;
            ap.fechaFabricacion = dtPicker.Value;
            ap.descripcion = txtDesc.Text;
            ap.Marca = (Marca)cboMarcas.SelectedItem;
            ap.Modelo = (Modelo)cboModelo.SelectedItem;
            ap.activo = 0;
            if (rbtnActivo.Checked)
                ap.activo = 1;


            string bodyContent = JsonConvert.SerializeObject(ap);

            
            string url = "https://localhost:7035/ADDAP";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
            {
                MessageBox.Show("Auto Parte registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la AutoParte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void FrmAltaAutoParte_Load(object sender, EventArgs e)
        {
            await cargarCombo<Marca>(cboMarcas, "ControllerMarca", "nombre", "id");
            await cargarCombo<Modelo>(cboModelo, "ControllerModelo", "nombre", "id");
            await cargarCombo<tipoProduccion>(cboTipoProd, "ControllerTipo", "tipo", "id");

            

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





        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
