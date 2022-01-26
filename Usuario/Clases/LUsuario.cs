using ConexionDB;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Clases {

	public class LUsuario {

		public List<CUsuario> RecuperarTodos() {
			PUsuario pers = new PUsuario();
			Command cmd = new Command() {
				Connection = Conexion.conexion,
				CommandText = $"SELECT {pers.Campos()} " +
							  $"FROM {pers.Tabla()} " +
							  $"ORDER BY {pers.Orden()}"
			};
			return cmd.ExecuteSelectList<CUsuario>(pers.Cargar);
		}
	}
}