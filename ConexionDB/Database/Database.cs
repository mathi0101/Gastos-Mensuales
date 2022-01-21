using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Database {

	public static class Database {

		#region Propiedades

		/// <summary>
		/// Nombre de la base de datos.
		/// </summary>
		public static readonly string Nombre = "database.db";

		/// <summary>
		/// Nombre de la carpeta alojada en AppData
		/// </summary>
		public static readonly string CarpetaContenedora = "GastosUserData";

		/// <summary>
		/// Ruta exacta de la base de datos
		/// </summary>
		public static string RutaReal {
			get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora, Nombre);
		}

		public static string RutaDeCarpeta {
			get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora);
		}

		#endregion Propiedades

		#region Generales

		public static bool CrearBase() {
			Directory.CreateDirectory(RutaDeCarpeta);
			SQLiteConnection.CreateFile(RutaReal);

			return respuesta > 0;
		}

		public static bool BorrarBase() {
			bool salida;
			try {
				File.Delete(RutaReal);
				Directory.Delete(RutaDeCarpeta);
				salida = true;
			} catch (Exception) {
				salida = false;
			}
			return salida;
		}

		#endregion Generales

		#region Públicas

		public static bool Existe() => File.Exists(RutaReal);

		public static long Peso() => new FileInfo(RutaReal).Length;

		public static double PesoKB() => Peso() / 1024;

		public static double PesoMB() => PesoKB() / 1024;

		#endregion Públicas
	}
}