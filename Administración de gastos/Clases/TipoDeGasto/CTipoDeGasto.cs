using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisGastos.Clases.TipoDeGasto {

	public class CTipoDeGasto {

		#region Propiedades

		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public DateTime fechaCreacion { get; set; }

		#endregion Propiedades

		#region Constructor

		public CTipoDeGasto() {
			Inicializar();
		}

		public void Inicializar() {
			Id = 0;
			Nombre = string.Empty;
			Descripcion = string.Empty;
			fechaCreacion = DateTime.Now;
		}

		#endregion Constructor

		#region Persistencia

		public bool Agregar() => new PTipoDeGasto().Agregar(this);

		public void Cargar(SQLiteDataReader dr) => new PTipoDeGasto().Cargar(this, dr);

		public bool Eliminar() => new PTipoDeGasto().Eliminar(this);

		public bool Existe() => new PTipoDeGasto().Existe(this);

		public bool Modificar() => new PTipoDeGasto().Modificar(this);

		public bool Recuperar() => new PTipoDeGasto().Recuperar(this);

		#endregion Persistencia

		#region Strings

		public override string ToString() => Id.ToString() + "-" + Nombre;

		#endregion Strings
	}
}