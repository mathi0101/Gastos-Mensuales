using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ConexionDB;
using System.Data.SQLite;

namespace Usuario.Clases {

	public class PUsuario {

		#region Atributos

		private SQLiteConnection conexion = Conexion.conexion;

		private readonly Dictionary<string, int> col = new Dictionary<string, int>() {{ "id", 0 },
																			{ "user",1 },
																			{ "password",2 },
																			{ "nombre",3 },
																			{ "apellido",4 },
																			{ "mail",5},
																			{ "fecha_nacimiento",6 },
																			{ "fecha_registro",7 },
																			{ "ultimo_login",8} };

		#endregion Atributos

		#region Constructor

		public PUsuario() {
		}

		#endregion Constructor

		#region DML

		public bool Agregar(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"INSERT INTO {Tabla()} ({CamposAgregar()}) VALUES ({AgregarValores(obj)})"
			};

			return cmd.ExecuteNonQuery() > 0;
		}

		public bool Modificar(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"UPDATE {Tabla()} " +
							  $"SET {ModificarVariables(obj)} " +
							  $"WHERE {CndUser(obj)}"
			};

			return cmd.ExecuteNonQuery() > 0;
		}

		public bool Eliminar(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"DELETE FROM {Tabla()} WHERE {CndUser(obj)}"
			};

			return cmd.ExecuteNonQuery() > 0;
		}

		#endregion DML

		//Base a objecto

		#region Recuperar

		public bool Existe(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)}"
			};
			//var registros = Convert.ToInt32(cmd.ExecuteScalar());
			return cmd.ExecuteExists();
		}

		public bool Recuperar(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)}"
			};
			var result = cmd.ExecuteSelect<CUsuario>(Cargar);
			obj = result != null ? (CUsuario)result : obj;
			return result != null;
		}

		public bool Recuperar(ref CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)}"
			};
			var result = cmd.ExecuteSelect<CUsuario>(Cargar);
			obj = result != null ? (CUsuario)result : obj;
			return result != null;
		}

		#endregion Recuperar

		#region Cargar

		public void Cargar(CUsuario obj, SQLiteDataReader dr) {
			obj.Inicializar();
			obj.Instanciar();
			if (dr.HasRows) {
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
				if (!dr.IsDBNull(col["mail"])) {
					obj.Mail = dr.GetString(col["mail"]);
				}
				if (!dr.IsDBNull(col["fecha_nacimiento"])) {
					obj.Nacimiento = DateTime.Parse(dr.GetString(col["fecha_nacimiento"]));
				}
				if (!dr.IsDBNull(col["fecha_registro"])) {
					obj.FechaRegistro = DateTime.Parse(dr.GetString(col["fecha_registro"]));
				}
				if (!dr.IsDBNull(col["ultimo_login"])) {
					obj.FechaRegistro = DateTime.Parse(dr.GetString(col["ultimo_login"]));
				}
			}
			return null;
		}

		#endregion Cargar

		// BASE DE DATOS

		#region Campos

		private string CamposAgregar() {
			string campos = "user, " +
							"password, " +
							"nombre, " +
							"apellido, " +
							"mail," +
							"fecha_nacimiento, " +
							"fecha_registro, " +
							"ultimo_login ";
			return campos;
		}

		public string Campos() {
			string campos = "id AS us_id, " +
							"user AS us_user, " +
							"password AS us_password, " +
							"nombre AS us_nombre, " +
							"apellido AS us_apellido, " +
							"mail AS us_mail, " +
							"fecha_nacimiento AS us_nacimiento, " +
							"fecha_registro AS us_registro, " +
							"ultimo_login AS us_ultlogin";
			return campos;
		}

		#endregion Campos

		//Objeto a base

		#region Valores

		private string AgregarValores(CUsuario obj) {
			string values = $"{FuncionesBD.StringToBD(obj.User)}, " +
							$"{FuncionesBD.StringToBD(obj.Password)}, " +
							$"{FuncionesBD.StringToBD(obj.Nombre)}, " +
							$"{FuncionesBD.StringToBD(obj.Apellido)}, " +
							$"{FuncionesBD.StringToBD(obj.Mail)}, " +
							$"{FuncionesBD.FechaToBD(obj.Nacimiento)}, " +
							$"{FuncionesBD.FechaYHoraToBD(obj.FechaRegistro)}," +
							$"{FuncionesBD.FechaYHoraToBD(obj.UltimoLogin)} ";
			return values;
		}

		#endregion Valores

		#region Variables

		private string ModificarVariables(CUsuario obj) {
			string values = $"user= {FuncionesBD.StringToBD(obj.User)}, " +
							$"password= {FuncionesBD.StringToBD(obj.Password)}, " +
							$"nombre= {FuncionesBD.StringToBD(obj.Nombre)}, " +
							$"apellido= {FuncionesBD.StringToBD(obj.Apellido)}, " +
							$"mail= {FuncionesBD.StringToBD(obj.Mail)}, " +
							$"fecha_nacimiento= {FuncionesBD.DataTimeNullableToBD(obj.Nacimiento)}, " +
							$"fecha_registro= {FuncionesBD.DataTimeNullableToBD(obj.FechaRegistro)}," +
							$"ultimo_login= {FuncionesBD.DataTimeNullableToBD(obj.UltimoLogin)} ";
			return values;
		}

		private string ModificarVariableLogin(CUsuario obj) {
			string values = $"ultimo_login= {FuncionesBD.FechaYHoraToBD(obj.UltimoLogin)} ";
			return values;
		}

		#endregion Variables

		#region Condiciones

		private object CndId(CUsuario obj) => $"id= {obj.Id}";

		private string CndUser(CUsuario obj) => $"user= {FuncionesBD.StringToBD(obj.User)}";

		private object CndPass(CUsuario obj) => $"password= {FuncionesBD.StringToBD(obj.Password)}";

		#endregion Condiciones

		// table

		#region Tablas

		public string Tabla() {
			return "Usuarios";
		}

		#endregion Tablas

		#region Orden

		public string Orden() {
			return " id ";
		}

		#endregion Orden

		#region Adicionales

		public bool IniciaSesion(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"SELECT {Campos()} " +
							  $"FROM {Tabla()} " +
							  $"WHERE {CndUser(obj)} AND {CndPass(obj)}"
			};
			return cmd.ExecuteExists();
		}

		public bool ModificarUltimoLogin(CUsuario obj) {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = $"UPDATE {Tabla()} " +
							  $"SET {ModificarVariableLogin(obj)} " +
							  $"WHERE {CndUser(obj)}"
			};

			return cmd.ExecuteNonQuery() > 0;
		}

		#endregion Adicionales
	}
}