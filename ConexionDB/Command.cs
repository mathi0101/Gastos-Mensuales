using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB {

	public class Command {

		#region Propiedades privadas

		private SQLiteCommand cmd;

		#endregion Propiedades privadas

		#region Propiedades publicas

		public SQLiteConnection Connection { get; set; }
		public string CommandText { get; set; }

		#endregion Propiedades publicas

		#region Constructor

		public Command() {
		}

		private void GetCmd() {
			cmd = new SQLiteCommand() {
				Connection = this.Connection,
				CommandText = this.CommandText
			};
		}

		#endregion Constructor

		#region Execute

		/// <summary>
		/// Ejecuta el comando y devuelve el numero de filas insertadas/modificadas afectadas por el
		/// </summary>
		/// <returns>El numero de filas insertadas/modificadas afectadas por el</returns>
		public int ExecuteNonQuery() {
			GetCmd(); return cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Ejecuta el comando y devuelve true/false dependiendo de si se ha encontrado un elemento que cumpla las condiciones de la consulta
		/// </summary>
		/// <returns>Devuelve true/false dependiendo de si se ha encontrado un elemento que cumpla las condiciones de la consulta</returns>
		public bool ExecuteExists() {
			GetCmd(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
		}

		/// <summary>
		/// Toma un tipo de clase como parámetro y devuelve esa clase con el objeto cargado por el método <paramref name="cargar"/>
		/// </summary>
		/// <typeparam name="T">Una clase donde se van a ingresar los datos</typeparam>
		/// <param name="cargar">Método que carga el objeto</param>
		/// <returns>bool Dependiendo si cargó el objeto o no</returns>
		public object ExecuteSelect<T>(Func<T, SQLiteDataReader, object> cargar) where T : class, new() {
			GetCmd();
			SQLiteDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows) {
				T obj = new T();
				cargar(obj, dr);
				return obj;
			}
			return null;
		}

		/// <summary>
		/// Toma un tipo de clase como parámetro y devuelve una lista de objetos de la clase <typeparamref name="T"/> con el objeto cargado por el método <paramref name="cargar"/>
		/// </summary>
		/// <typeparam name="T">Una clase donde se van a ingresar los datos</typeparam>
		/// <param name="cargar"></param>
		/// <returns>Devuelve la lista con los objetos cargados dentro</returns>
		public List<T> ExecuteSelectList<T>(Func<T, SQLiteDataReader, object> cargar) where T : class, new() {
			GetCmd();
			SQLiteDataReader dr = cmd.ExecuteReader();
			List<T> lista = new List<T>();
			int i = 0;
			do {
				i++;
				T obj = new T();
				cargar(obj, dr);
				if (dr.StepCount == i) lista.Add(obj);
			} while (dr.StepCount == i);

			return lista;
		}

		#endregion Execute
	}
}