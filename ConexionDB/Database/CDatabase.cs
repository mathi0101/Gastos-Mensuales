using ConexionDB.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Database {

	public static class CDatabase {

		#region Constantes

		/// <summary>
		/// Nombre de la base de datos.
		/// </summary>
		public static readonly string Nombre = "database.db";

		/// <summary>
		/// Nombre de la carpeta alojada en AppData
		/// </summary>
		public static readonly string CarpetaContenedora = "GastosUserData";

		#endregion Constantes

		#region Propiedades

		/// <summary>
		/// Ruta exacta de la base de datos
		/// </summary>
		public static string RutaReal {
			get => Path.Combine(RutaDeCarpeta, Nombre);
		}

		public static string RutaDeCarpeta {
			get => Debugger.IsAttached ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), CarpetaContenedora) : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora);
		}

		#endregion Propiedades

		#region Conectar / Cerrar

		public static bool TryConectar() {
			try {
				CConexionDB.Conexion().Open();
			} catch (InvalidOperationException) {
				// Ya estaba abierta
			}
			PDatabase pers = new PDatabase();
			return pers.ConnectionisOk();
		}

		public static void Cerrar() {
			CConexionDB.CloseConnection();
		}

		#endregion Conectar / Cerrar

		#region Test

		public static bool ConnectionisOK() {
			PDatabase pers = new PDatabase();
			return pers.ConnectionisOk();
		}

		#endregion Test

		#region DML

		public static bool CrearBase() {
			if (!Directory.Exists(RutaDeCarpeta)) {
				Directory.CreateDirectory(RutaDeCarpeta);
			}
			SQLiteConnection.CreateFile(RutaReal);
			PDatabase pers = new PDatabase();

			bool salida = TryConectar();
			try {
				pers.CrearBase();
			} catch (Exception ex) {
				salida = false;
			}
			return salida;
		}

		public static bool BorrarBase(bool forzar = false) {
			try {
				CConexionDB.CloseConnection();
				File.Delete(RutaReal);
				Console.WriteLine($"Se ha borrado la base de datos ubicada en <{RutaReal}> ");
			} catch (IOException ex) {
			}
			return !Existe();
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

		#endregion DML

		#region Públicas

		public static bool Existe() => File.Exists(RutaReal);

		public static long Peso() => new FileInfo(RutaReal).Length;

		public static double PesoKB() => Peso() / 1024;

		public static double PesoMB() => PesoKB() / 1024;

		#endregion Públicas
	}
}