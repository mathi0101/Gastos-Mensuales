using ConexionDB.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Database {

	public class PDatabase {

		#region Conexion

		private SQLiteConnection conexion;

		#endregion Conexion

		#region Constructor

		public PDatabase() {
			conexion = CConexionDB.Conexion();
		}

		#endregion Constructor

		#region Crear

		public void CrearBase() {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = Tablas()
			};
			cmd.ExecuteNonQuery();
		}

		#endregion Crear

		#region TestConnection

		internal bool ConnectionisOk() {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = "SELECT TIME('now');"
			};
			return cmd.ExecuteCount() > 0;
		}

		#endregion TestConnection

		#region Tablas

		private string Tablas() {
			return TablaUsuarios();
		}

		private string TablaUsuarios() {
			return @"CREATE TABLE Usuarios(
					id    INTEGER NOT NULL UNIQUE,
					user  TEXT NOT NULL UNIQUE,
					password  TEXT NOT NULL,
					nombre    TEXT,
					apellido  TEXT,
					mail      TEXT,
					fecha_nacimiento  TEXT,
					fecha_registro    TEXT NOT NULL,
					ultimo_login      TEXT,
					PRIMARY KEY(id AUTOINCREMENT)) ";
		}

		#endregion Tablas
	}
}