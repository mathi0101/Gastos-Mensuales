using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Clases {

	public static class CFuncionesBD {

		public static string StringToBD(string texto) {
			if (texto == "") {
				return "NULL";
			} else {
				return $"'{texto}'";
			}
		}

		public static string DataTimeNullableToBD(DateTime? dt) {
			if (dt == null) {
				return "NULL";
			} else {
				return $"'{dt.ToString()}'";
			}
		}

		public static string DataTimeToBD(DateTime dt) {
			return $"'{dt.ToString()}'";
		}

		public static string FechaToBD(DateTime? dt) {
			if (dt == null) {
				return "NULL";
			}
			return $"'{((DateTime)dt).ToString("dd-MM-yyyy")}'";
		}

		public static string FechaYHoraToBD(DateTime? dt) {
			if (dt == null) {
				return "NULL";
			}
			return $"'{((DateTime)dt).ToString("dd-MM-yyyy HH:mm:ss")}'";
		}
	}
}