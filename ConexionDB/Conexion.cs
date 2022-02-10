using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB {

	public static class CConexionDB {
		//private static string StringFromAppConfig { get => ConfigurationManager.ConnectionStrings["cadena"].ConnectionString; }

		private static string StringCreate { get => $"Data Source={Database.Database.RutaReal};Version=3;"; }

		public static SQLiteConnection Conexion() => new SQLiteConnection(StringCreate);
	}
}