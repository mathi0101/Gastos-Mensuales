using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Encrypt;

namespace Usuario.Clases {

	public class CUsuario {

		#region Propiedades

		public int Id { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Mail { get; set; }
		public DateTime? Nacimiento { get; set; }
		public DateTime? FechaRegistro { get; set; }
		public DateTime? UltimoLogin { get; set; }

		public string NombreCompleto { get => Nombre + " " + Apellido; }

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

		public void Instanciar() {
			Nacimiento = null;
			FechaRegistro = null;
			UltimoLogin = null;
		}

		public void Inicializar() {
			Id = 0;
			User = String.Empty;
			Password = String.Empty;
			Nombre = String.Empty;
			Apellido = String.Empty;
			Mail = String.Empty;
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
			var obj = this;
			if (pers.Recuperar(ref obj)) {
				Cargar(obj);
				return true;
			}
			return false;
		}

		public bool Existe() {
			PUsuario pers = new PUsuario();
			return pers.Existe(this);
		}

		public bool IniciaSesion() {
			PUsuario pers = new PUsuario();
			return pers.IniciaSesion(this);
		}

		public bool ModificarUltimoLogin(DateTime nuevoLogin) {
			this.UltimoLogin = nuevoLogin;
			PUsuario pers = new PUsuario();
			return pers.ModificarUltimoLogin(this);
		}

		public bool RecuperarUltimoUsuarioLogueado() {
			PUsuario pers = new PUsuario();
			return pers.RecuperarUltimoUsuarioLogueado(this);
		}

		#endregion Persistencia

		#region Cargar

		public void Cargar(CUsuario obj) {
			Instanciar();
			Inicializar();

			Id = obj.Id;
			User = obj.User;
			Password = obj.Password;
			Nombre = obj.Nombre;
			Apellido = obj.Apellido;
			Mail = obj.Mail;

			Nacimiento = obj.Nacimiento;
			FechaRegistro = obj.FechaRegistro;
		}

		#endregion Cargar

		#region String

		public override string ToString() {
			return $"{Id}: {User}";
		}

		#endregion String

		#region Publicos

		public string ClavePlana() {
			return Encriptacion.DesEncriptar(Password);
		}

		#endregion Publicos
	}
}