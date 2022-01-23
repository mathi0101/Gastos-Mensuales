using ConexionDB;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_gastos.Clases {

	public class LUsuario {
		private SQLiteConnection conexion = Conexion.conexion;

		public List<CUsuario> RecuperarTodos() {
			List<CUsuario> lista = new List<CUsuario>();

			PUsuario pers = new PUsuario();
			SQLiteCommand cmd = new SQLiteCommand() {
				Connection = conexion,
				CommandText = $"SELECT {pers.Campos()} " +
							 $"FROM {pers.Tabla()}"
			};
			var dr = cmd.ExecuteReader();
			var obj = new CUsuario();
			while (pers.Cargar(obj, dr)) {
				lista.Add(obj);
				obj = new CUsuario();
			}
			return lista;
		}
	}
}