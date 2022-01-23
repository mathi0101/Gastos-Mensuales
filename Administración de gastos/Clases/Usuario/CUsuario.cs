﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_gastos.Clases {

	public class CUsuario {

		#region Propiedades

		public int Id { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public DateTime? Nacimiento { get; set; }
		public DateTime? FechaRegistro { get; set; }

		public string ClavePlana {
			get => Encriptacion.DesEncriptar(Password);
		}

		#endregion Propiedades

		#region Constructor

		public CUsuario() {
			Instanciar();
			Inicializar();
		}

		public CUsuario(string user) {
			Instanciar();
			Inicializar();
			User = user;
		}

		#region Inicializar e Instanciar

		private void Instanciar() {
			Nacimiento = null;
			FechaRegistro = null;
		}

		private void Inicializar() {
			Id = 0;
			User = String.Empty;
			Password = String.Empty;
			Nombre = String.Empty;
			Apellido = String.Empty;
		}

		#endregion Inicializar e Instanciar

		#endregion Constructor

		#region Persistencia

		public bool Agregar() {
			PUsuario pers = new PUsuario();

			return pers.Agregar(this);
		}

		public bool Eliminar() {
			PUsuario pers = new PUsuario();

			return pers.Eliminar(this);
		}

		public bool Modificar() {
			PUsuario pers = new PUsuario();

			return pers.Modificar(this);
		}

		public bool Recuperar() {
			PUsuario pers = new PUsuario();

			return pers.Recuperar(this);
		}

		public bool Existe() {
			PUsuario pers = new PUsuario();
			return pers.Existe(this);
		}

		public bool IniciaSesion() {
			PUsuario pers = new PUsuario();
			return pers.IniciaSesion(this);
		}

		#endregion Persistencia

		#region String

		public override string ToString() {
			return $"{User}: {Nombre} {Apellido}";
		}

		#endregion String
	}
}