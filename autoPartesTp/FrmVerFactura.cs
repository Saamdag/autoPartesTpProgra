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
    public partial class FrmVerFactura : Form
    {
        public FrmVerFactura()
        {
            InitializeComponent();
        }

        private async void FrmVerFactura_Load(object sender, EventArgs e)
        {
            //cargarCombos
            await cargarFacturas();
        }

        private async Task cargarFacturas()
        {
            string url = "https://localhost:7035/GFACTURAS";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Factura>>(result);
            dataGridView1.Rows.Clear();
            foreach (Factura f in lst)
            {

                dataGridView1.Rows.Add(new object[] { f.idFactura, f.fechaFactura, f.cliente.nombre, f.vendedor.nombre});
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                int nroFact = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                FrmVerDetalle frmDetalle = new FrmVerDetalle(nroFact);
                frmDetalle.ShowDialog();
                
            }
        }

        private async void btnFech_Click(object sender, EventArgs e)
        {

        }

        private async void btnEntreFechas_Click(object sender, EventArgs e)
        {
            await buscarEntre();
        }

        private async Task buscarEntre()
        {
            //cargarFact con filtro entre fechas
            DateTime desde = dateTimePicker1.Value;
            DateTime hasta = dateTimePicker2.Value;
            //string url = $"https://localhost:7035/FACTURASENTRE?desde={desde.Day}%2F{desde.Month}%2F{desde.Year}&hasta={hasta.Day}%2F{hasta.Month}%2F{hasta.Year}";
            string url = $"https://localhost:7035/FACTURASENTRE?desde={desde.Date.ToString("O")}&hasta={hasta.Date.ToString("O")}";

            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Factura>>(result);
            dataGridView1.Rows.Clear();
            foreach (Factura f in lst)
            {
                dataGridView1.Rows.Add(new object[] { f.idFactura, f.fechaFactura, f.cliente.nombre, f.vendedor.nombre });
            }
        }
    }
    
}
