using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Database {

	public class PDatabase {

		#region Conexion

		private SQLiteConnection conexion = Conexion.conexion;

		#endregion Conexion

		#region Constructor

		public PDatabase() {
		}

		#endregion Constructor

		#region Crear

		public void CrearBase() {
			string sql = "create table highscores (name varchar(20), score int)";

			SQLiteCommand command = new SQLiteCommand() {
				Connection = conexion,
				CommandText = @"CREATE TABLE Usuarios(
									id    INTEGER NOT NULL UNIQUE,
									user  TEXT NOT NULL UNIQUE,
									password  TEXT NOT NULL,
									nombre    TEXT,
									apellido  TEXT,
									fecha_nacimiento  TEXT,
									fecha_registro    TEXT NOT NULL,
									PRIMARY KEY(id AUTOINCREMENT)
								)"
			};
			command.ExecuteNonQuery();
		}

		#endregion Crear
	}
}