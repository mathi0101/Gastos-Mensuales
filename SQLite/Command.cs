using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite {

	public class Command {

		#region Propiedades

		public SQLiteConnection ActiveConnection { get; set; }
		public string CommandText { get; set; }

		#endregion Propiedades

		#region Contructor

		public Command() {
		}

		#endregion Contructor
	}
}