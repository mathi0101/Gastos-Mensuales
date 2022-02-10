using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Clases;

namespace Administración_de_gastos.Clases.Login {

	public static class CLogin {
		public static int UserID = -1;

		public static CUsuario UsuarioLogged() {
			if (UserID != -1) {
				var user = new CUsuario() { Id = UserID };
				user.Recuperar();
				return user;
			} else {
				throw new Exception("No hay usuario logueado");
			}
		}
	}
}