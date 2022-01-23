using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_gastos.Clases {

	public class LUsuario {

		public List<CUsuario> Read2List() {
			List<CUsuario> lista = new List<CUsuario>();

			//using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
			//	conexion.Open();
			//	string query = "SELECT * FROM users";
			//	SQLiteCommand cmd = new SQLiteCommand(query, conexion);
			//	cmd.CommandType = System.Data.CommandType.Text;

			//	using (SQLiteDataReader dr = cmd.ExecuteReader()) {
			//		while (dr.Read()) {
			//			int id = int.Parse(dr["id"].ToString());
			//			string nombre = dr["username"].ToString();
			//			string contra = dr["password"].ToString();

			//			CUsuario user = new CUsuario();
			//			user.Id = id;
			//			user.Nombre = nombre;
			//			user.Password = contra;
			//			lista.Add(user);
			//		}
			//	}
			//	return lista;
			//}
			return lista;
		}
	}
}