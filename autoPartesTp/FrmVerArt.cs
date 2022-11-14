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
    public partial class FrmVerArt : Form
    {
        public FrmVerArt()
        {
            InitializeComponent();
        }

        private async void FrmVerArt_Load(object sender, EventArgs e)
        {
            await cargarProductosAsync();
        }

        private async Task cargarProductosAsync()
        {

            string url = "https://localhost:7035/AUTOPARTES";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<AutoParte>>(result);
            dataGridView1.Rows.Clear();
            foreach (AutoParte ap in lst)
            {
                string act = "";
                if (ap.activo == 1)
                    act = "Activo";
                else
                    act = "No disponible";

                dataGridView1.Rows.Add(new object[] { ap.idArticulo, ap.descripcion, ap.fechaFabricacion, ap.tipoProduccion.tipo, act, ap.precio, ap.Marca.nombre, ap.Modelo.nombre });
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await buscarProd();
        }

        private async Task buscarProd()
        {
            string url = "";
            if (textBox1.Text.ToString() == "")
            {

                await cargarProductosAsync();
            }
            else
            {
                bool bol;

                if (cboEstado.Text == "")
                {
                    url = $"https://localhost:7035/AUTOPARTESNOM?nombre={textBox1.Text}&activo=null ";
                }
                else
                {
                    bol = false;
                    if (cboEstado.Text == "Activo")
                    {
                        bol = true;
                    }
                    url = $"https://localhost:7035/AUTOPARTESNOM?nombre={textBox1.Text}&activo={bol.ToString()}";

                }
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var lst = JsonConvert.DeserializeObject<List<AutoParte>>(result);

                List<AutoParte> ap = lst;

                dataGridView1.Rows.Clear();
                foreach (var aup in ap)
                {

                    string act = "";
                    if (aup.activo == 1)
                        act = "Activo";
                    else
                        act = "No disponible";

                    dataGridView1.Rows.Add(new object[] { aup.idArticulo, aup.descripcion, aup.fechaFabricacion, aup.tipoProduccion.tipo, act, aup.precio, aup.Marca.nombre, aup.Modelo.nombre });
                }
            }
        }
    }
}
