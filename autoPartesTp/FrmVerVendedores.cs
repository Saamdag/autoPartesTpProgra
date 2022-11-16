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
    public partial class FrmVerVendedores : Form
    {
        public FrmVerVendedores()
        {
            InitializeComponent();
        }
        private async void FrmVerVendedores_Load(object sender, EventArgs e)
        {
            await cargarVendedores();
        }



        private async Task cargarVendedores()
        {
            string url = "https://localhost:7035/VENDEDORES";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Vendedor>>(result);
            dataGridView1.Rows.Clear();
            foreach (Vendedor v in lst)
            {

                dataGridView1.Rows.Add(new object[] { v.idVendedor, v.nombre, v.apellido, v.telefono.ToString(), v.direccion, v.barrio.nombre });
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update
            if (dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                Vendedor v = new Vendedor();
                v.idVendedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                v.nombre = (string)dataGridView1.CurrentRow.Cells[1].Value.ToString();
                v.apellido = (string)dataGridView1.CurrentRow.Cells[2].Value;
                v.telefono = Convert.ToInt64(dataGridView1.CurrentRow.Cells[3].Value);
                v.direccion = (string)(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                v.barrio.nombre = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                FrmUpVendedor f = new FrmUpVendedor(v);
                f.ShowDialog();


                await cargarVendedores();
            }

            //Delete
            //if (dataGridView1.CurrentCell.ColumnIndex == 7)
            //{
            //    DialogResult result = MessageBox.Show("Desea eliminar el Vendedor?", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            //        IDataApi o = new DataApi();

            //        if (o.deleteVen(id))//servicio.CrearPresupuesto(nuevo)
            //        {
            //            MessageBox.Show("Vendedor Eliminada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        }
            //        else
            //        {
            //            MessageBox.Show("ERROR. No se pudo eliminar el Vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        await cargarVendedores();
                    
            //    }
            //}
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                await cargarVendedores();
            }
            else
            {
                string apellido = textBox1.Text;

                string url = $"https://localhost:7035/VENDEDORESAPE?apellido={apellido}";
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var lst = JsonConvert.DeserializeObject<List<Vendedor>>(result);
                dataGridView1.Rows.Clear();
                foreach (Vendedor v in lst)
                {
                    dataGridView1.Rows.Add(new object[] { v.idVendedor, v.nombre, v.apellido, v.telefono.ToString(), v.direccion, v.barrio.nombre });
                }


            }
        }
    }
}
