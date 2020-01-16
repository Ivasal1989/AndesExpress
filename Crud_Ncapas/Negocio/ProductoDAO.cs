using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocio
{
	public class ProductoDAO
	{
		Conexion cn = new Conexion();
		public DataSet datos;
		public void List_producto(string cadenaSql, Producto obj)
		{
			try { 
			SqlDataAdapter adaptador = new SqlDataAdapter(cadenaSql, cn.getcn);
			datos = new DataSet();
			adaptador.Fill(datos, "xxx");
			SqlCommand cmd = new SqlCommand(cadenaSql, cn.getcn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.ExecuteNonQuery();
			}
			catch (Exception) { }
		}
		public void Add_producto(string cadenaSql, Producto obj)
		{
			cn.getcn.Open();
			try
			{
				SqlCommand cmd = new SqlCommand(cadenaSql, cn.getcn);
				cmd.CommandType = CommandType.StoredProcedure;
				//cmd.Parameters.AddWithValue("", obj.codigo);
				cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
				cmd.ExecuteNonQuery();			
			}
			catch (Exception) { }
			finally
			{
				cn.getcn.Close();
			}
		}
		public void Update_producto(string cadenaSql, Producto obj)
		{
			cn.getcn.Open();
			try
			{
				SqlCommand cmd = new SqlCommand(cadenaSql, cn.getcn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@codigo", obj.codigo);
				cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
				cmd.ExecuteNonQuery();
			}
			catch (Exception) { }
			finally
			{
				cn.getcn.Close();
			}
		}
		public void Delete_producto(string cadenaSql, Producto obj)
		{
			cn.getcn.Open();
			try
			{
				SqlCommand cmd = new SqlCommand(cadenaSql, cn.getcn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@codigo", obj.codigo);
				cmd.ExecuteNonQuery();
			}
			catch (Exception) { }
			finally
			{
				cn.getcn.Close();
			}
		}
	}
}
