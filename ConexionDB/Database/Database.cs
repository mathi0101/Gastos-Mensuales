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
			if (!Directory.Exists(RutaDeCarpeta)) {
				Directory.CreateDirectory(RutaDeCarpeta);
			}
			SQLiteConnection.CreateFile(RutaReal);

			Conexion.conexion.Open(); // Abrimos conexion despues de crear la base
			PDatabase pers = new PDatabase();

			bool salida = true; ;
			try {
				pers.CrearBase();
			} catch (Exception ex) {
				salida = false;
				throw ex;
			}
			return salida;
		}

		public static bool BorrarBase(bool forzar = false) {
			bool salida = true;
			try {
				if (forzar) {
					Conexion.conexion.Close();
				}
				File.Delete(RutaReal);
				Console.WriteLine($"Se ha borrado la base de datos ubicada en <{RutaReal}> ");
			} catch (Exception ex) {
				salida = false;
				throw ex;
			}
			return salida;
		}

		public static bool BorrarBaseYCarpeta() {
			bool salida = true;
			try {
				if (BorrarBase()) {
					Directory.Delete(RutaDeCarpeta);
					Console.WriteLine($"Se ha borrado la carpeta ubicada en <{RutaDeCarpeta}> ");
				} else {
					salida = false;
				}
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