using autoPartesTp.Http;
using Ddl.Dominio;
using Ddl.fachada;
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
                if (cboEstado.Text == "Activo")
                {
                    url = $"https://localhost:7035/AUTOPARTESNOM?nombre=null&activo=true";
                }
                if (cboEstado.Text == "No Activo")
                {
                    url = $"https://localhost:7035/AUTOPARTESNOM?nombre=null&activo=false";
                }
                if (cboEstado.Text == ""|| cboEstado.Text == "-")
                {
                    url = "https://localhost:7035/AUTOPARTES";
                }
            }
            else
            {
                bool bol;

                if (cboEstado.Text == "" || cboEstado.Text == "-")
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
        

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update
            if (dataGridView1.CurrentCell.ColumnIndex == 8)
            {
                AutoParte auto = new AutoParte();
                auto.idArticulo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                auto.descripcion = (string)dataGridView1.CurrentRow.Cells[1].Value.ToString();
                auto.fechaFabricacion = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
                auto.tipoProduccion.tipo = (string)dataGridView1.CurrentRow.Cells[3].Value.ToString();
                auto.activo = 0;
                if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Activo")
                    auto.activo = 1;
                auto.precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                auto.Marca.nombre = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                auto.Modelo.nombre = dataGridView1.CurrentRow.Cells[7].Value.ToString();

                FrmUpAutoParte frmUpAutoParte = new FrmUpAutoParte(auto);
                frmUpAutoParte.ShowDialog();
                await cargarProductosAsync();
            }

            //Delete
            if (dataGridView1.CurrentCell.ColumnIndex == 9)
            {
                DialogResult result = MessageBox.Show("Desea eliminar el art?", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                    //string url = $"https://localhost:7035/UPAP?id={id}";
                    //var r = await ClientSingleton.GetInstance().DeleteAsync(url);

                    //if (r.Equals("true"))//servicio.CrearPresupuesto(nuevo)
                    //{
                    //    MessageBox.Show("AutoParte Eliminada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.Dispose();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("ERROR. No se pudo eliminar la AutoParte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    IDataApi o = new DataApi();
                    o.deleteAp(id);
                    
                    await cargarProductosAsync();
                }
            }
            
        }
    }
}
