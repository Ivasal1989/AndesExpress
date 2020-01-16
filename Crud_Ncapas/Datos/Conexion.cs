using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
	public class Conexion
	{
		SqlConnection cn = new SqlConnection("server=ivasal;database=prueba;uid=sa;pwd=katetodd");

		public SqlConnection getcn
		{
			get { return cn; }
		}
	}
}
