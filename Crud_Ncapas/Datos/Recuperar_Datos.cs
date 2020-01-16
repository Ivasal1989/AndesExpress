using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
	public class Recuperar_Datos
	{
		Conexion cn = new Conexion();
		public DataSet datos;

		public void mostrarDatos(string cadenaSql)
		{
			try
			{
				SqlDataAdapter adaptador = new SqlDataAdapter(cadenaSql, cn.getcn);
				datos = new DataSet();
				adaptador.Fill(datos, "xxx");
			}
			catch (Exception) { }
		}
	}
}
