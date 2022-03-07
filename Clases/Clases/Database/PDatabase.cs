using Clases.Clases.TipoDeGasto;
using ConexionDB.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Clases;

namespace Clases.Clases.Database {

	internal class PDatabase {

		#region Conexion

		private SQLiteConnection conexion;

		#endregion Conexion

		#region Constructor

		internal PDatabase() {
			conexion = CConexionDB.Conexion();
		}

		#endregion Constructor

		#region Crear

		internal void CrearBase() {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = Tablas()
			};
			cmd.ExecuteNonQuery();

			InicializarTablas();
		}

		#endregion Crear

		#region InicializarTablas

		internal void InicializarTablas() {
			if (Debugger.IsAttached) {
				new CUsuario() {
					Nombre = "Admin",
					Password
				}.Agregar();
			}
			CargarTiposGastos();
		}

		private void CargarTiposGastos() {
			CTipoDeGasto tipo = new CTipoDeGasto() {
				Nombre = "Gasto fijo",
				Descripcion = "Suscripciones, alquiler, etc."
			};
			CTipoDeGasto tipo1 = new CTipoDeGasto() {
				Nombre = "Gasto variable",
				Descripcion = "Transorte al trabajo, comida del mes casa/trabajo, nafta del auto, etc."
			};
			CTipoDeGasto tipo2 = new CTipoDeGasto() {
				Nombre = "Gasto esporádico",
				Descripcion = "Cena en restaurante, una cerveza en el super, una ida al cine, etc."
			};

			tipo.Agregar();
			tipo1.Agregar();
			tipo2.Agregar();
		}

		#endregion InicializarTablas

		#region TestConnection

		internal bool ConnectionisOk() {
			Command cmd = new Command() {
				Connection = conexion,
				CommandText = "SELECT TIME('now');"
			};
			return cmd.ExecuteCount() > 0;
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
					eliminado INTEGER(1),
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