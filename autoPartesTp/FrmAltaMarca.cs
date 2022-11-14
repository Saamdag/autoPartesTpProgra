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
    public partial class FrmAltaMarca : Form
    {
        public FrmAltaMarca()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await guardarMarca();
        }

        private async Task guardarMarca()
        {
            Marca m = new Marca();
            m.nombre = textBox1.Text;

            string bodyContent = JsonConvert.SerializeObject(m);


            string url = "http://localhost:7035/ADDMARCA";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
            {
                MessageBox.Show("Marca registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la Marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
