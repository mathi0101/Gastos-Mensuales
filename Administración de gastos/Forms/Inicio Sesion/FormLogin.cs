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

namespace Administración_de_gastos {

	public partial class FormLogin : Form {

		#region Formulario

		public FormLogin() {
			InitializeComponent();
		}

		private void FormLogin_Load(object sender, EventArgs e) {
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
			string user = txtUser.Text;
			string pass = txtPassword.Text;
		}

		private void Register() {
			string user = txtUser.Text;
			string pass = txtPassword.Text;

			Usuario obj = PUsuario.FindUser(user);

			if (obj != null) {
				Console.WriteLine(obj.Nacimiento);
				MessageBox.Show("Ya hay un usuario registrado con el mismo nombre de usuario.\nPrueba con otro", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				LimpiarCampos();
				return;
			}

			if (user != "") {
				if (pass.Length >= 8) {
					//string passEncrypted = Encriptacion.Encrypt(pass, "password", 256);
					string contraEncriptada = Encriptacion.Encriptar(pass);
					Usuario objs = new Usuario();
					objs.User = user;
					objs.Password = contraEncriptada;
					if (PUsuario.Create(objs)) {
						MessageBox.Show("Tu cuenta ha sido añadida con éxito.\nYa puedes acceder a la aplicación", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LimpiarCampos();
					} else {
						MessageBox.Show("No se ha podido agregar tu usuario a la base de datos.\nVerifica tus datos y vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else {
					MessageBox.Show("Tu contraseña debe contener al menos 8 caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtPassword.Focus();
				}
			} else {
				MessageBox.Show("Debes completar los campos vacíos para poder crear tu cuenta.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtUser.Focus();
			}
		}

		#endregion Privadas
	}
}