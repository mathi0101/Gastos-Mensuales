using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administración_de_gastos.Clases;
using ConexionDB.Database;

namespace Administración_de_gastos {

	public partial class FormLogin : Form {

		#region Formulario

		public FormLogin() {
			InitializeComponent();
		}

		private void FormLogin_Load(object sender, EventArgs e) {
			List<CUsuario> users = new LUsuario().RecuperarTodos();
			var x = new AutoCompleteStringCollection();
			x.AddRange(users.Select(u => u.User).ToArray());
			txtUser.AutoCompleteCustomSource = x;
		}

		private void FormLogin_FormClosing(object sender, FormClosingEventArgs e) {
			//Database.BorrarBase(true);
			//Application.Exit();
		}

		#endregion Formulario

		#region Eventos

		private void btnLogin_Click(object sender, EventArgs e) {
			Login();
		}

		private void btnNewUser_Click(object sender, EventArgs e) {
			Register();
		}

		private void txtUser_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar)
			   & !char.IsDigit(e.KeyChar) & !char.IsLetter(e.KeyChar)
			   & e.KeyChar != '-' & e.KeyChar != '_' & e.KeyChar != '!'
			   & e.KeyChar != '¡' & e.KeyChar != '?') {
				e.Handled = true;
				return;
			}
			e.Handled = false;
			return;
		}

		private void txtPassword_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar)
			   & !char.IsDigit(e.KeyChar) & !char.IsLetter(e.KeyChar)
			   & e.KeyChar != '-' & e.KeyChar != '_' & e.KeyChar != '!'
			   & e.KeyChar != '¡' & e.KeyChar != '?') {
				e.Handled = true;
				return;
			}
			e.Handled = false;
			return;
		}

		#endregion Eventos

		#region Privadas

		private void LimpiarCampos() {
			txtUser.Text = "";
			txtPassword.Text = "";
		}

		private void Login() {
			if (txtPassword.Text.Length == 0) {
				MessageBox.Show("Tu contraseña debe contener al menos 1 caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPassword.Focus();
				return;
			}
			CUsuario user = new CUsuario() {
				User = txtUser.Text,
				Password = Encriptacion.Encriptar(txtPassword.Text)
			};
			if (user.Existe()) {
				if (user.IniciaSesion()) {
					MessageBox.Show("Has iniciado sesión correctamente!\nBienvenido", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
				} else {
					MessageBox.Show("Contraseña Incorrecta", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPassword.Focus();
				}
			} else {
				MessageBox.Show("Este usuario no existe\nCrea tu usuario con el botón Registrar!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				btnNewUser.Focus();
			}
		}

		private void Register() {
			string user = txtUser.Text;
			string pass = txtPassword.Text;

			CUsuario obj = new CUsuario(user);

			if (obj.Existe()) {
				MessageBox.Show("Este usuario ya se encuentra registrado.\nInicia sesión o elige otro usuario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				LimpiarCampos();
				return;
			} else {
				if (user != "") {
					if (pass.Length >= 1) {
						string contraEncriptada = Encriptacion.Encriptar(pass);
						CUsuario objs = new CUsuario();
						objs.User = user;
						objs.Password = contraEncriptada;
						objs.FechaRegistro = DateTime.Now;
						if (objs.Agregar()) {
							MessageBox.Show("Tu cuenta ha sido añadida con éxito.\nYa puedes acceder a la aplicación", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
							LimpiarCampos();
						} else {
							MessageBox.Show("No se ha podido agregar tu usuario a la base de datos.\nVerifica tus datos y vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else {
						MessageBox.Show("Tu contraseña debe contener al menos 1 caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtPassword.Focus();
					}
				} else {
					MessageBox.Show("Debes completar los campos vacíos para poder crear tu cuenta.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtUser.Focus();
				}
			}
		}

		#endregion Privadas
	}
}