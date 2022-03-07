using ConexionDB.Clases;
using MisGastos.Clases.TipoDeGasto;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_gastos.Clases.TipoDeGasto {

	public class LTipoDeGasto {

		#region Atributos

		private SQLiteConnection conexion = CConexionDB.Conexion();

		#endregion Atributos

		#region Buscar

		public List<CTipoDeGasto> BuscarCodigo(int codigo, List<CTipoDeGasto> lista) => lista.Where(x => x.Id == codigo).ToList();

		public List<CTipoDeGasto> BuscarNombre(string nombre, List<CTipoDeGasto> lista) => lista.Where(x => x.Nombre.Trim() == nombre.Trim()).ToList();

		#endregion Buscar

		#region Recuperar

		public List<CTipoDeGasto> RecuperarTodos() {
			PTipoDeGasto pers = new PTipoDeGasto();
			Command cmd = new Command {
				Connection = conexion,
				CommandText = "SELECT " + "\n" + pers.Campos() + "\n" +
							  "FROM " + "\n" + pers.Tabla() + "\n" +
							  "ORDER BY " + pers.Orden()
			};
			return cmd.ExecuteSelectList<CTipoDeGasto>(pers.Cargar);
		}

		#endregion Recuperar
	}
}