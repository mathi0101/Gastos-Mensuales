using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ConexionDB;

namespace Administración_de_gastos.Clases {

	public class PUsuario {

		#region Atributos

		private SQLiteConnection conexion = Conexion.conexion;

		private readonly Dictionary<string, int> col = new Dictionary<string, int>() {{ "id", 0 },
																			{ "user",1 },
																			{ "password",2 },
																			{ "nombre",3 },
																			{ "apellido",4 },
																			{ "fecha_nacimiento",5 },
																			{ "fecha_registro",6 } };

		#endregion Atributos

		#region Constructor

		public PUsuario() {
		}

		#endregion Constructor

		#region ABE

		public bool Agregar(CUsuario obj) {
			SQLiteCommand cmd = new SQLiteCommand() {
				Connection = conexion,
				CommandText = $"INSERT INTO {Tabla()} ({CamposAgregar()}) VALUES ({AgregarValores(obj)})"
			};

			return cmd.ExecuteNonQuery() > 0;
		}

		public bool Modificar(CUsuario obj) {
			bool respuesta = true;

			//using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
			//	conexion.Open();

			//	string query = "UPDATE users SET username= @nombre, password= @contraseña WHERE id= @id";

			//	SQLiteCommand cmd = new SQLiteCommand(query, conexion);
			//	cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
			//	cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.User));
			//	cmd.Parameters.Add(new SQLiteParameter("@contraseña", obj.Password));

			//	cmd.CommandType = System.Data.CommandType.Text;

			//	if (cmd.ExecuteNonQuery() < 1) {
			//		respuesta = false;
			//	}
			//}
			return respuesta;
		}

		public bool Eliminar(CUsuario obj) {
			bool respuesta = true;

			//using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
			//	conexion.Open();

			//	string query = "DELETE FROM users WHERE id = @id";

			//	SQLiteCommand cmd = new SQLiteCommand(query, conexion);
			//	cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));

			//	cmd.CommandType = System.Data.CommandType.Text;

			//	if (cmd.ExecuteNonQuery() < 1) {
			//		respuesta = false;
			//	}
			//}
			return respuesta;
		}

		public bool Existe(CUsuario obj) {
			SQLiteCommand cmd = new SQLiteCommand() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)}"
			};
			var registros = cmd.ExecuteNonQuery();
			return registros > 0;
		}

		#endregion ABE

		#region Inicio Sesion

		internal bool IniciaSesion(CUsuario obj) {
			SQLiteCommand cmd = new SQLiteCommand() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)} AND {CndPass(obj)}"
			};
			return cmd.ExecuteNonQuery() > 0;
		}

		#endregion Inicio Sesion

		#region Recuperar

		public bool Recuperar(CUsuario obj) {
			SQLiteCommand cmd = new SQLiteCommand() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)}"
			};
			return Cargar(obj, cmd.ExecuteReader());
			return false;
		}

		#endregion Recuperar

		#region Cargar

		private bool Cargar(CUsuario obj, SQLiteDataReader dr) {
			bool salida = false;
			if (dr.Read()) {
				if (!dr.IsDBNull(col["id"])) {
					obj.Id = dr.GetInt32(col["id"]);
				}
				if (!dr.IsDBNull(col["user"])) {
					obj.User = dr.GetString(col["user"]);
				}
				if (!dr.IsDBNull(col["password"])) {
					obj.Password = dr.GetString(col["password"]);
				}
				if (!dr.IsDBNull(col["nombre"])) {
					obj.Nombre = dr.GetString(col["nombre"]);
				}
				if (!dr.IsDBNull(col["apellido"])) {
					obj.Apellido = dr.GetString(col["apellido"]);
				}
				if (!dr.IsDBNull(col["fecha_nacimiento"])) {
					obj.Nacimiento = DateTime.Parse(dr.GetString(col["fecha_nacimiento"]));
				}
				if (!dr.IsDBNull(col["fecha_registro"])) {
					obj.FechaRegistro = DateTime.Parse(dr.GetString(col["fecha_registro"]));
				}
				salida = true;
			}
			return salida;
		}

		#endregion Cargar

		#region Campos

		private string CamposAgregar() {
			string campos = "user, " +
							"password, " +
							"nombre, " +
							"apellido, " +
							"fecha_nacimiento, " +
							"fecha_registro";
			return campos;
		}

		private string Campos() {
			string campos = "id AS us_id, " +
							"user AS us_user, " +
							"password AS us_password, " +
							"nombre AS us_nombre, " +
							"apellido AS us_apellido, " +
							"fecha_nacimiento AS us_nacimiento, " +
							"fecha_registro AS us_registro";
			return campos;
		}

		#endregion Campos

		#region Valores

		private string AgregarValores(CUsuario obj) {
			string values = $"{FuncionesBD.ToBD(obj.User)}, " +
							$"{FuncionesBD.ToBD(obj.Password)}, " +
							$"{FuncionesBD.ToBD(obj.Nombre)}, " +
							$"{FuncionesBD.ToBD(obj.Apellido)}, " +
							$"{FuncionesBD.ToBD(obj.Nacimiento)}, " +
							$"{FuncionesBD.ToBD(obj.FechaRegistro)} ";
			return values;
		}

		#endregion Valores

		#region Variables

		private string AgregarVariables(CUsuario obj) {
			string values = $"user= {FuncionesBD.ToBD(obj.User)}, " +
							$"password= {FuncionesBD.ToBD(obj.Password)}, " +
							$"nombre= {FuncionesBD.ToBD(obj.Nombre)}, " +
							$"apellido= {FuncionesBD.ToBD(obj.Apellido)}, " +
							$"fecha_nacimiento= {FuncionesBD.ToBD(obj.Nacimiento)}, " +
							$"fecha_registro= {FuncionesBD.ToBD(obj.FechaRegistro)} ";
			return values;
		}

		#endregion Variables

		#region Condiciones

		private string CndUser(CUsuario obj) => $"user= {FuncionesBD.ToBD(obj.User)}";

		private object CndPass(CUsuario obj) => $"password= {FuncionesBD.ToBD(obj.Password)}";

		#endregion Condiciones

		#region Tablas

		private string Tabla() {
			return "Usuarios";
		}

		#endregion Tablas
	}
}