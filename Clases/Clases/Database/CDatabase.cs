using ConexionDB.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Clases.Database {

	public static class CDatabase {

		#region Conectar

		public static bool TryConectar() {
			try {
				CConexionDB.OpenConnection();
			} catch (InvalidOperationException) {
				// Ya estaba abierta
			}
			PDatabase pers = new PDatabase();
			return pers.ConnectionisOk();
		}

		#endregion Conectar

		#region Test

		public static bool ConnectionisOK() {
			PDatabase pers = new PDatabase();
			return pers.ConnectionisOk();
		}

		#endregion Test

		#region DML

		public static bool CrearBase() {
			if (!Directory.Exists(CConexionDB.RutaDeCarpeta)) {
				Directory.CreateDirectory(CConexionDB.RutaDeCarpeta);
			}
			SQLiteConnection.CreateFile(CConexionDB.RutaReal);
			PDatabase pers = new PDatabase();

			bool salida = TryConectar();
			try {
				pers.CrearBase();
				//pers.InicializarTablas();
			} catch (SQLiteException ex) {
				throw ex;
				BorrarBase(true);
				salida = false;
			}
			return salida;
		}

		public static bool BorrarBase(bool forzar = false) {
			try {
				if (forzar) CConexionDB.CloseConnection();
				File.Delete(CConexionDB.RutaReal);
				Console.WriteLine($"Se ha borrado la base de datos ubicada en <{CConexionDB.RutaReal}> ");
			} catch (IOException) {
				// El programa sigue utilizando la base
			}
			return !Existe();
		}

		public static bool BorrarBaseYCarpeta() {
			bool salida = true;
			try {
				if (BorrarBase()) {
					Directory.Delete(CConexionDB.RutaDeCarpeta);
					Console.WriteLine($"Se ha borrado la carpeta ubicada en <{CConexionDB.RutaDeCarpeta}> ");
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

		public static bool Existe() => File.Exists(CConexionDB.RutaReal);

		public static long Peso() => new FileInfo(CConexionDB.RutaReal).Length;

		public static double PesoKB() => Peso() / 1024;

		public static double PesoMB() => PesoKB() / 1024;

		#endregion Públicas
	}
}