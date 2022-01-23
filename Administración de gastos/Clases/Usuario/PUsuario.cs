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

		#endregion Atributos

		#region Constructor

		public PUsuario() {
		}

		#endregion Constructor

		#region ABE

		public bool Agregar(CUsuario obj) {
			bool respuesta = true;

			SQLiteCommand cmd = new SQLiteCommand() {
				Connection = conexion,
				CommandText = $"INSERT INTO {Tabla()} ({CamposBase()}) VALUES (@nombre, @contraseña)"
			};

			cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.User));
			cmd.Parameters.Add(new SQLiteParameter("@contraseña", obj.Password));

			cmd.CommandType = System.Data.CommandType.Text;

			if (cmd.ExecuteNonQuery() < 1) {
				respuesta = false;
			}
			return respuesta;
		}

		public bool Modificar(CUsuario obj) {
			bool respuesta = true;

			using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
				conexion.Open();

				string query = "UPDATE users SET username= @nombre, password= @contraseña WHERE id= @id";

				SQLiteCommand cmd = new SQLiteCommand(query, conexion);
				cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
				cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.User));
				cmd.Parameters.Add(new SQLiteParameter("@contraseña", obj.Password));

				cmd.CommandType = System.Data.CommandType.Text;

				if (cmd.ExecuteNonQuery() < 1) {
					respuesta = false;
				}
			}
			return respuesta;
		}

		public bool Eliminar(CUsuario obj) {
			bool respuesta = true;

			using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
				conexion.Open();

				string query = "DELETE FROM users WHERE id = @id";

				SQLiteCommand cmd = new SQLiteCommand(query, conexion);
				cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));

				cmd.CommandType = System.Data.CommandType.Text;

				if (cmd.ExecuteNonQuery() < 1) {
					respuesta = false;
				}
			}
			return respuesta;
		}

		#endregion ABE

		#region Recuperar

		public bool Recuperar(string username) {
			using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
				conexion.Open();

				string query = "SELECT * FROM users WHERE username= @user";

				SQLiteCommand cmd = new SQLiteCommand(query, conexion);
				cmd.Parameters.Add(new SQLiteParameter("@user", username));

				using (SQLiteDataReader dr = cmd.ExecuteReader()) {
					if (dr.Read()) {
						int id = int.Parse(dr["id"].ToString());
						string user = dr["username"].ToString();
						string contra = dr["password"].ToString();
						string nombre = dr["name"].ToString();
						string apellido = dr["lastname"].ToString();

						DateTime nacimiento = DateTime.Parse(dr["birthDate"].ToString());

						CUsuario NewUser = new CUsuario() { Id = id, Nombre = nombre, Password = contra };
						return NewUser;
					} else {
						return null;
					}
				}
			}
		}

		#endregion Recuperar

		#region Campos

		private string CamposBase() {
			string campos = "user AS us_user, " +
							"password AS us_password, " +
							"nombre AS us_nombre, " +
							"apellido AS us_apellido, " +
							"fecha_nacimiento AS us_nacimiento, " +
							"fecha_registro AS us_registro";
			return campos;
		}

		#endregion Campos

		#region Variables

		private string AgregarVariables(CUsuario obj) {
			string values = $"user= {obj.User}, " +
							$"password= {obj.Password}, " +
							$"nombre= {obj.Nombre}, " +
							$"apellido= {obj.Apellido}, " +
							$"fecha_nacimiento= {obj.Nacimiento}, " +
							$"fecha_registro= {obj.fecha}";
		}

		#endregion Variables

		#region Tablas

		private string Tabla() {
			return "Usuarios";
		}

		#endregion Tablas
	}
}