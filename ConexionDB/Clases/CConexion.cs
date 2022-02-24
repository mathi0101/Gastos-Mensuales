using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Clases {

	public static class CConexionDB {
		//private static string StringFromAppConfig { get => ConfigurationManager.ConnectionStrings["cadena"].ConnectionString; }

		private static string StringCreate { get => $"Data Source={Database.CDatabase.RutaReal};Version=3;"; }
		private static SQLiteConnection conexion;

		public static SQLiteConnection Conexion() {
			if (conexion != null) {
				return conexion;
			} else {
				conexion = new SQLiteConnection(StringCreate);
				return conexion;
			}
		}

		public static void OpenConnection() {
			Conexion().Open();
		}

		public static void CloseConnection() {
			Conexion().Close();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}