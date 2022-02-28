using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Clases {

	public static class CConexionDB {

		#region Atributos

		private static string cadenaConexion;

		#endregion Atributos

		//private static string StringFromAppConfig { get => ConfigurationManager.ConnectionStrings["cadena"].ConnectionString; }
		private static string CadenaConexion {
			get {
				if (cadenaConexion == null) cadenaConexion = $"Data Source={Database.CDatabase.RutaReal};Version=3;";
				return cadenaConexion;
			}
		}

		private static SQLiteConnection conexion;

		public static SQLiteConnection Conexion() {
			if (conexion == null) conexion = new SQLiteConnection(CadenaConexion);
			return conexion;
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