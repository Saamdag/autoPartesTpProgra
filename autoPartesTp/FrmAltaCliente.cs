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
    public partial class FrmAltaCliente : Form
    {
        private Cliente nuevo;
        public FrmAltaCliente()
        {
            InitializeComponent();
            nuevo=new Cliente();
        }

        private async void FrmAltaCliente_Load(object sender, EventArgs e)
        {
            await cargarCombo<Barrio>(cboBarrio, "BARRIOS", "nombre", "id");
            await cargarCombo<TipoCliente>(cboTipoCliente, "ControllerTipoClie", "tipoCliente", "idTipo");
            await cargarCombo<Provincia>(cboProv, "PROVINCIAS", "nombre", "id");
            await cargarCombo<Ciudad>(cboCiudad, "CIUDADES", "nombre", "id");
        }

        private async Task guardarCliente()
        {
            nuevo.nombre = txtNombre.Text;
            nuevo.apellido = txtApellido.Text;
            nuevo.direccion = txtDireccion.Text;
            nuevo.telefono = Convert.ToInt64(txtTelefono.Text);
            nuevo.barrio = (Barrio)cboBarrio.SelectedItem;
            nuevo.provincia = (Provincia)cboProv.SelectedItem;
            nuevo.ciudad = (Ciudad)cboCiudad.SelectedItem;
            nuevo.tipoCliente = (TipoCliente)cboTipoCliente.SelectedItem;



            string bodyContent = JsonConvert.SerializeObject(nuevo);


            string url = "https://localhost:7035/ADDCLI";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
            {
                MessageBox.Show("Cliente registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await guardarCliente();
        }
    }
}
