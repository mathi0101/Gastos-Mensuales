using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Clases {

	public class Command {

		#region Propiedades publicas

		public SQLiteConnection Connection;
		public string CommandText;

		#endregion Propiedades publicas

		#region Constructor

		public Command() {
		}

		//private SQLiteCommand GetCmd() {
		//	SQLiteCommand cmd = new SQLiteCommand() {
		//		Connection = this.Connection,
		//		CommandText = this.CommandText
		//	};
		//	return cmd;
		//}

		#endregion Constructor

		#region Privadas

		private int _ExecuteNonQuery() {
			return new SQLiteCommand() {
				Connection = this.Connection,
				CommandText = this.CommandText
			}.ExecuteNonQuery();
		}

		private object _ExecuteScalar() {
			return new SQLiteCommand() {
				Connection = this.Connection,
				CommandText = this.CommandText
			}.ExecuteScalar();
		}

		private SQLiteDataReader _ExecuteReader() {
			return new SQLiteCommand() {
				Connection = this.Connection,
				CommandText = this.CommandText
			}.ExecuteReader();
		}

		#endregion Privadas

		#region Publicas

		/// <summary>
		/// Ejecuta el comando y devuelve el numero de filas insertadas/modificadas afectadas por el
		/// </summary>
		/// <returns>El numero de filas insertadas/modificadas afectadas por el</returns>
		public int ExecuteNonQuery() {
			return _ExecuteNonQuery();
		}

		/// <summary>
		/// Ejecuta el comando y devuelve true/false dependiendo de si se ha encontrado un elemento que cumpla las condiciones de la consulta
		/// </summary>
		/// <returns>Devuelve true/false dependiendo de si se ha encontrado un elemento que cumpla las condiciones de la consulta</returns>
		public bool ExecuteExists() {
			return Convert.ToInt32(_ExecuteScalar()) > 0;
		}

		public int ExecuteCount() {
			SQLiteDataReader dr = _ExecuteReader();
			int rows = 0;
			while (dr.Read()) {
				rows++;
			}
			return rows;
		}

		/// <summary>
		/// Toma un tipo de clase como parámetro y devuelve esa clase con el objeto cargado por el método <paramref name="cargar"/>
		/// </summary>
		/// <typeparam name="T">Una clase donde se van a ingresar los datos</typeparam>
		/// <param name="cargar">Método que carga el objeto</param>
		/// <returns>bool Dependiendo si cargó el objeto o no</returns>
		public bool ExecuteSelect<T>(T obj, Action<T, SQLiteDataReader> cargar) where T : class, new() {
			SQLiteDataReader dr = _ExecuteReader();
			if (dr.Read()) {
				cargar?.Invoke(obj, dr);
			}
			return dr.HasRows;
		}

		/// <summary>
		/// Toma un tipo de clase como parámetro y devuelve una lista de objetos de la clase <typeparamref name="T"/> con el objeto cargado por el método <paramref name="cargar"/>
		/// </summary>
		/// <typeparam name="T">Una clase donde se van a ingresar los datos</typeparam>
		/// <param name="cargar"></param>
		/// <returns>Devuelve la lista con los objetos cargados dentro</returns>
		public List<T> ExecuteSelectList<T>(Action<T, SQLiteDataReader> cargar1) where T : class, new() {
			List<T> result = new List<T>();
			T obj;
			SQLiteDataReader dr = _ExecuteReader();

			while (dr.Read()) {
				obj = new T();
				cargar1?.Invoke(obj, dr);
				result.Add(obj);
			}

			return result;
		}

		#endregion Publicas
	}
}