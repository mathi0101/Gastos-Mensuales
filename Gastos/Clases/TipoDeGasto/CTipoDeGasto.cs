using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Clases.TipoDeGasto {

	public class CTipoDeGasto {

		#region Propiedades

		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public DateTime? fechaCreacion { get; set; }

		#endregion Propiedades

		#region Constructor

		public CTipoDeGasto() {
			Inicializar();
		}

		private void Inicializar() {
			Id = 0;
			Nombre = string.Empty;
			Descripcion = string.Empty;
			fechaCreacion = null;
		}

		#endregion Constructor

		#region Persistencia

		public bool Agregar() {
			return new PTipoDeGasto().Agregar();
		}

		#endregion Persistencia
	}
}