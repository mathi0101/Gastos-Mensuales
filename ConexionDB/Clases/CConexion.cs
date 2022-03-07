using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Clases {

	public static class CConexionDB {

		#region Constantes

		/// <summary>
		/// Nombre de la base de datos.
		/// </summary>
		public static string Nombre = "database.db";

		/// <summary>
		/// Nombre de la carpeta alojada en AppData
		/// </summary>
		public static string CarpetaContenedora = "MisGastos";

		private static SQLiteConnection conexion;

		#endregion Constantes

		#region Propiedades

		public static string RutaDeCarpeta {
			get => Debugger.IsAttached ? CarpetaContenedora : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora);
		}

		/// <summary>
		/// Ruta exacta de la base de datos
		/// </summary>
		public static string RutaReal {
			get => Path.Combine(RutaDeCarpeta, Nombre);
		}

		#endregion Propiedades

		public static SQLiteConnection Conexion() {
			if (conexion == null) conexion = new SQLiteConnection($"Data Source={RutaReal};Version=3;");
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