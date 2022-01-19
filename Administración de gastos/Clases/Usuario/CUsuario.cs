using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_gastos.Clases {

	public class Usuario {

		#region Propiedades

		public int Id { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public DateTime Nacimiento { get; set; }

		public string ClavePlana {
			private get => Encriptacion.DesEncriptar(Password);
			set { }
		}

		#endregion Propiedades

		#region Constructor

		public Usuario() {
		}

		#endregion Constructor
	}
}