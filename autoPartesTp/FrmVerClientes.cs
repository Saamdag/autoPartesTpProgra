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
    public partial class FrmVerClientes : Form
    {
        public FrmVerClientes()
        {
            InitializeComponent();
        }

        private async void FrmVerClientes_Load(object sender, EventArgs e)
        {
            await cargarClientes();
        }

        private async Task cargarClientes()
        {
            string url = "https://localhost:7035/CLIENTES";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(result);
            dataGridView1.Rows.Clear();
            foreach (Cliente c in lst)
            {

                dataGridView1.Rows.Add(new object[] {c.idCliente,c.nombre,c.apellido,c.telefono.ToString(),c.tipoCliente.tipoCliente,c.direccion,c.barrio.nombre});
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update
            if (dataGridView1.CurrentCell.ColumnIndex == 7)
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                cliente.nombre = (string)dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cliente.apellido = (string)dataGridView1.CurrentRow.Cells[2].Value;
                cliente.telefono= Convert.ToInt64(dataGridView1.CurrentRow.Cells[3].Value);
                cliente.tipoCliente.tipoCliente = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                cliente.direccion= (string)(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                cliente.barrio.nombre = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                FrmUpCliente f = new FrmUpCliente(cliente);
                f.ShowDialog();

                
                await cargarClientes();
            }

            //Delete
            if (dataGridView1.CurrentCell.ColumnIndex == 8)
            {
                //DialogResult result = MessageBox.Show("Desea eliminar el Cliente?", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                //    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                //    //string url = $"https://localhost:7035/UPAP?id={id}";
                //    //var r = await ClientSingleton.GetInstance().DeleteAsync(url);

                //    //if (r.Equals("true"))//servicio.CrearPresupuesto(nuevo)
                //    //{
                //    //    MessageBox.Show("AutoParte Eliminada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //    this.Dispose();
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("ERROR. No se pudo eliminar la AutoParte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //}
                //    IDataApi o = new DataApi();
                //    o.deleteAp(id);

                //    await cargarClientes();
                //}
            }
        }
    }
}
