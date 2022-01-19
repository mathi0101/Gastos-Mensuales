using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB {

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
		public static string RutaDeAcceso {
			get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora, Nombre);
		}

		#endregion Propiedades

		#region Públicas

		public static bool Existe() => File.Exists(RutaDeAcceso);

		public static long Peso() => new FileInfo(RutaDeAcceso).Length;

		public static double PesoKB() => Peso() / 1024;

		public static double PesoMB() => PesoKB() / 1024;

		#endregion Públicas
	}
}