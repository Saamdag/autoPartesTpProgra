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
    public partial class FrmVerDetalle : Form
    {
        int idFact;
        public FrmVerDetalle(int id)
        {
            InitializeComponent();
            idFact = id;
        }

        private async void FrmVerDetalle_Load(object sender, EventArgs e)
        {
          await cargarDetalle(idFact);
        }


        private async Task cargarDetalle(int idFact)
        {


            string url = $"https://localhost:7035/DETALLE?id={idFact}";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<DetalleFactura>>(result);
            dataGridView1.Rows.Clear();
            foreach (DetalleFactura dt in lst)
            {
                dataGridView1.Rows.Add(new object[] { dt.idDetalleNro,dt.AutoParte.descripcion,dt.cantidad,dt.bonificacion,dt.descuento });
            }
        }
    }
}
