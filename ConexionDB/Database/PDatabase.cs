using ConexionDB.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Database {

	public class PDatabase {

		#region Conexion

		private SQLiteConnection conexion;

		#endregion Conexion

		#region Constructor

		public PDatabase() {
			conexion = CConexionDB.Conexion();
		}

		#endregion Constructor

		#region Crear

		public void CrearBase() {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = Tablas()
			};
			cmd.ExecuteNonQuery();
		}

		#endregion Crear

		#region TestConnection

		internal bool ConnectionisOk() {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = "SELECT TIME('now');"
			};
			return cmd.ExecuteExists();
		}

		#endregion TestConnection

		#region Tablas

		private string Tablas() {
			return TablaUsuarios() +
					TablaTiposGastos() +
					TablaCategorias() +
					TablaGastos();
		}

		#region Usuarios

		private string TablaUsuarios() {
			return @"CREATE TABLE Usuarios(
					id    INTEGER NOT NULL UNIQUE,
					user  TEXT NOT NULL UNIQUE,
					password  TEXT NOT NULL,
					nombre    TEXT,
					apellido  TEXT,
					mail      TEXT,
					eliminado varchar(1),
					fecha_nacimiento  TEXT,
					fecha_registro    TEXT NOT NULL,
					ultimo_login      TEXT,
					PRIMARY KEY(id AUTOINCREMENT));";
		}

		#endregion Usuarios

		#region Gastos

		private string TablaTiposGastos() {
			return @"CREATE TABLE g_tipos(
					id    INTEGER NOT NULL UNIQUE,
					nombre varchar(50),
					descripcion varchar(100),
					fecha_creacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
					PRIMARY KEY(id AUTOINCREMENT));";
		}

		private string TablaCategorias() {
			return @"CREATE TABLE g_categorias(
					id    INTEGER NOT NULL UNIQUE,
					nombre varchar(50),
					descripcion varchar(100),
					fecha_creacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
					PRIMARY KEY(id AUTOINCREMENT));";
		}

		private string TablaGastos() {
			return @"CREATE TABLE Gastos(
					id            INTEGER NOT NULL UNIQUE,
					descripcion   varchar(100),
					usuario_id	  INTEGER NOT NULL,
					tipo_id		  INTEGER NOT NULL,
					categoria_id  INTEGER NOT NULL,
					monto_pesos   INTEGER NOT NULL,
					monto_dolares REAL NOT NULL,
					pago_inicial  DATETIME NOT NULL,
					pago_final	  DATETIME,
					fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
					PRIMARY KEY(id AUTOINCREMENT),
					FOREIGN KEY (tipo_id) REFERENCES g_tipos(id),
					FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
					FOREIGN KEY (categoria_id) REFERENCES g_categorias(id));";
		}

		#endregion Gastos

		#endregion Tablas
	}
}