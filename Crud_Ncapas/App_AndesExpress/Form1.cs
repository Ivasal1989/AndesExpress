using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using Datos;
using Negocio;

namespace App_AndesExpress
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		ProductoDAO objeto1 = new ProductoDAO();
		public void Limpiar()
		{
			txtCodigo.Text = "";
			txtDescripcion.Text = "";
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			Producto pro = new Producto();
			pro.descripcion = this.txtDescripcion.Text;
			objeto1.Add_producto("usp_Add_producto", pro);
			objeto1.List_producto("usp_List_producto", pro);
			this.dgListado.DataSource = objeto1.datos;
			this.dgListado.DataMember = "xxx";
			this.dgListado.Refresh();
			Limpiar();
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			Producto pro = new Producto();
			pro.codigo = this.txtCodigo.Text;
			pro.descripcion = this.txtDescripcion.Text;
			objeto1.Update_producto("Update_producto", pro);
			objeto1.List_producto("usp_List_producto", pro);
			this.dgListado.DataSource = objeto1.datos;
			this.dgListado.DataMember = "xxx";
			this.dgListado.Refresh();
			Limpiar();
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			Producto pro = new Producto();
			pro.codigo = this.txtCodigo.Text;
			objeto1.Delete_producto("Delete_producto", pro);
			objeto1.List_producto("usp_List_producto", pro);
			this.dgListado.DataSource = objeto1.datos;
			this.dgListado.DataMember = "xxx";
			this.dgListado.Refresh();
			Limpiar();
		}

		private void dgListado_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtCodigo.Text = dgListado.CurrentRow.Cells[0].Value.ToString();
			txtDescripcion.Text = dgListado.CurrentRow.Cells[1].Value.ToString();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Producto pro = new Producto();
			objeto1.List_producto("usp_List_producto", pro);
			this.dgListado.DataSource = objeto1.datos;
			this.dgListado.DataMember = "xxx";
		}
	}
}
