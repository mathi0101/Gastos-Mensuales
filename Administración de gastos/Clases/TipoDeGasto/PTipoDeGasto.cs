using ConexionDB.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisGastos.Clases.TipoDeGasto {

	internal class PTipoDeGasto {
		private SQLiteConnection conexion = CConexionDB.Conexion();

		internal PTipoDeGasto() {
		}

		#region Campos

		public string CmpExiste() => " g_tipos.id AS Id ";

		public string Campos() =>
			" g_tipos.id AS g_tipos_Id," +
			" g_tipos.nombre AS g_tipos_Nombre," +
			" g_tipos.escripcion AS g_tipos_Descripcion," +
			" g_tipos.fecha_creacion AS g_tipos_Fecha_creacion ";

		#endregion Campos

		#region Cargar

		public void Cargar(CTipoDeGasto obj, SQLiteDataReader dr) {
			obj.Inicializar();

			if (dr.HasRows) {
				obj.Id = dr.GetInt32(0);
				if (!dr.IsDBNull(1)) obj.Nombre = dr.GetString(1);
				if (!dr.IsDBNull(2)) obj.Descripcion = dr.GetString(2);
				if (!dr.IsDBNull(3)) obj.fechaCreacion = dr.GetDateTime(3);
			}
		}

		#endregion Cargar

		#region Recuperar

		public bool Existe(CTipoDeGasto obj) {
			Command cmd = new Command {
				Connection = conexion,
				CommandText = "SELECT " + "\n" + CmpExiste() + "\n" +
							  "FROM " + "\n" + Tabla() + "\n" +
							  "WHERE " + Condicion(obj)
			};
			return cmd.ExecuteExist();
		}

		public bool Recuperar(CTipoDeGasto obj) {
			Command cmd = new Command {
				Connection = conexion,
				CommandText = "SELECT " + "\n" + Campos() + "\n" +
							  "FROM " + "\n" + Tabla() + "\n" +
							  "WHERE " + Condicion(obj)
			};
			return cmd.ExecuteSelect(obj, Cargar);
		}

		#endregion Recuperar

		#region Condiciones

		public string Condicion(CTipoDeGasto obj) => " g_tipos.id = " + obj.Id + " ";

		#endregion Condiciones

		#region DML

		public bool Agregar(CTipoDeGasto obj) {
			Command cmd = new Command {
				Connection = conexion,
				CommandText = "INSERT INTO " + "\n" + Tabla() + "\n" +
							  "(" + AgregarVariables() + ")" + "\n" +
							  " VALUES " + "\n" +
							  "(" + AgregarValores(obj) + ")"
			};
			return cmd.ExecuteNonQuery();
		}

		public bool Eliminar(CTipoDeGasto obj) {
			Command cmd = new Command {
				Connection = conexion,
				CommandText = "DELETE FROM " + "\n" + Tabla() + "\n" +
							  "WHERE " + Condicion(obj)
			};
			return cmd.ExecuteNonQuery();
		}

		public bool Modificar(CTipoDeGasto obj) {
			Command cmd = new Command {
				Connection = conexion,
				CommandText = "UPDATE " + "\n" + Tabla() + "\n" +
							  "SET " + "\n" + ModificarValores(obj) + "\n" +
							  "WHERE " + Condicion(obj)
			};
			return cmd.ExecuteNonQuery();
		}

		#endregion DML

		#region Edición

		public string AgregarValores(CTipoDeGasto obj) =>
			obj.Id + ", " +
			CFuncionesBD.StringToBD(obj.Nombre) + ", " +
			CFuncionesBD.StringToBD(obj.Descripcion) + ", " +
			CFuncionesBD.DataTimeToBD(obj.fechaCreacion);

		public string AgregarVariables() =>
			"id, " +
			"nombre, " +
			"descripcion, " +
			"fecha_creacion ";

		public string ModificarValores(CTipoDeGasto obj) =>
		   " id= " + obj.Id + ", " +
		   " nombre= " + CFuncionesBD.StringToBD(obj.Nombre) + ", " +
		   " descripcion= " + CFuncionesBD.StringToBD(obj.Descripcion) + ", " +
		   " fecha_creacion= " + CFuncionesBD.DataTimeToBD(obj.fechaCreacion);

		#endregion Edición

		#region Orden

		public string Orden() => " g_tipos.id ";

		#endregion Orden

		#region Tablas

		public string Tabla() => " g_tipos ";

		#endregion Tablas
	}
}