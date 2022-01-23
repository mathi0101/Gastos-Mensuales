using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB {

	public class Conexion {
		public static string StringConexion { get => ConfigurationManager.ConnectionStrings["cadena"].ConnectionString; }

		public static SQLiteConnection conexion = new SQLiteConnection(StringConexion);
	}
}