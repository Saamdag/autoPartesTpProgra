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
    public partial class FrmAltaModelo : Form
    {
        public FrmAltaModelo()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           await guardarModelo();
        }

        private async Task guardarModelo()
        {
                Modelo m = new Modelo();
                m.nombre = textBox1.Text;

                string bodyContent = JsonConvert.SerializeObject(m);


                string url = "https://localhost:7035/ADDMODELO";
                var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

                if (result.Equals("true"))//servicio.CrearPresupuesto(nuevo)
                {
                    MessageBox.Show("Modelo registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("ERROR. No se pudo registrar el Modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}
