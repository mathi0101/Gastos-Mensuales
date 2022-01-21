using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Database {

	public class PDatabase {

		#region Conexion

		private SQLiteConnection conexion = Conexion.sqlConnection;

		#endregion Conexion

		#region Constructor

		public PDatabase() {
		}

		#endregion Constructor

		#region Crear

		public bool CrearDB() {
			conexion.Open();

			SQLiteCommand command = new SQLiteCommand() {
				Connection = conexion,
				CommandText = "create table highscores (name varchar(20), score int)"
			};

			return command.ExecuteNonQuery() > 0;
		}

		#endregion Crear
	}
}