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
    public partial class FrmUpCliente : Form
    {
        private Cliente nuevo;
        public FrmUpCliente(Cliente c)
        {
            InitializeComponent();
            nuevo = c;
        }

        private async void FrmUpCliente_Load(object sender, EventArgs e)
        {
            await cargarCombo<Barrio>(cboBarrio, "BARRIOS", "nombre", "id");
            await cargarCombo<Provincia>(cboProv, "PROVINCIAS", "nombre", "id");
            await cargarCombo<Ciudad>(cboCiudad, "CIUDADES", "nombre", "id");
            await cargarCombo<TipoCliente>(cboTipoCliente, "ControllerTipoClie", "tipoCliente", "idTipo");

            cargarCliente();
            
        }

        private void cargarCliente()
        {
            
            cboTipoCliente.Text = nuevo.tipoCliente.tipoCliente;
            txtApellido.Text = nuevo.apellido;
            txtNombre.Text = nuevo.nombre;
            txtDireccion.Text = nuevo.direccion;
            cboBarrio.Text = nuevo.barrio.nombre;
            txtTelefono.Text = nuevo.telefono.ToString();
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            

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
           await updateCliente();
        }

        private async Task updateCliente()
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


            string url = "https://localhost:7035/UPCLI";
            var result = await ClientSingleton.GetInstance().PutAsync(url, bodyContent);

            if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
            {
                MessageBox.Show("Cliente Actualizada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo actualizar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
