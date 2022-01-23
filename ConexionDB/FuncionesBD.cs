using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB {

	public static class FuncionesBD {

		public static object ToBD(string texto) {
			if (texto == "") {
				return "NULL";
			} else {
				return $"'{texto}'";
			}
		}

		public static object ToBD(DateTime? dt) {
			if (dt == null) {
				return "NULL";
			} else {
				return $"'{dt.ToString()}'";
			}
		}
	}
}