using Ddl.Datos;
using Ddl.Datos.interfaces;
using Ddl.Datos.implementacion;
using System.Data;

namespace autoPartesTp
{
    public partial class Form1 : Form
    {
        private IDAO dao;
        public Form1()
        {
            InitializeComponent();
            dao = new DAO();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ver Articulos
            FrmVerArt frmVer = new FrmVerArt();
            frmVer.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaAutoParte frmAltaAutoParte = new FrmAltaAutoParte();
            frmAltaAutoParte.ShowDialog();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaFactura frmNuevaFactura = new FrmNuevaFactura();
            frmNuevaFactura.ShowDialog();
        }

        private void verToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmVerFactura frm = new FrmVerFactura();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAltaMarca f = new FrmAltaMarca();
            f.ShowDialog();
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmAltaVendedor frmAlta = new FrmAltaVendedor();
            frmAlta.ShowDialog();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAltaCliente cl = new FrmAltaCliente();
            cl.ShowDialog();
        }

        private void verToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVerClientes vcl = new FrmVerClientes();
            vcl.ShowDialog();
        }
    }
}