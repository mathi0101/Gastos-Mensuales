using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
		public static string RutaReal {
			get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora, Nombre);
		}

		public static string RutaDeCarpeta {
			get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CarpetaContenedora);
		}

		#endregion Propiedades

		#region Crear

		public static bool CrearBase() {
			Directory.CreateDirectory(RutaDeCarpeta);
			SQLiteConnection.CreateFile(RutaReal);

			using (SQLiteConnection conexion = Conexion.sqlConnection) {
				conexion.Open();

				string sql = "create table highscores (name varchar(20), score int)";

				SQLiteCommand command = new SQLiteCommand(sql, conexion);
				int respuesta = command.ExecuteNonQuery();

				sql = "insert into highscores (name, score) values ('Me', 9001)";

				command = new SQLiteCommand(sql, conexion);
				respuesta = command.ExecuteNonQuery();

				return respuesta > 0;
			}
		}

		#endregion Crear

		#region Públicas

		public static bool Existe() => File.Exists(RutaReal);

		public static long Peso() => new FileInfo(RutaReal).Length;

		public static double PesoKB() => Peso() / 1024;

		public static double PesoMB() => PesoKB() / 1024;

		#endregion Públicas
	}
}