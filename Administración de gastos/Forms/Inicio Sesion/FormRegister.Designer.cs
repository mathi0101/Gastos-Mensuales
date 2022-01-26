
namespace Administración_de_gastos.Forms.Inicio_Sesion
{
    partial class FormRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tbUser = new System.Windows.Forms.TextBox();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.tbMail = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblPass = new System.Windows.Forms.Label();
			this.tbPass = new System.Windows.Forms.TextBox();
			this.lblPass2 = new System.Windows.Forms.Label();
			this.dtpBirth = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbPass2 = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbUser
			// 
			this.tbUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbUser.Location = new System.Drawing.Point(143, 29);
			this.tbUser.MaxLength = 10;
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size(168, 20);
			this.tbUser.TabIndex = 0;
			this.tbUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUser_KeyPress);
			this.tbUser.Validating += new System.ComponentModel.CancelEventHandler(this.tbUser_Validating);
			// 
			// tbLastName
			// 
			this.tbLastName.Location = new System.Drawing.Point(143, 48);
			this.tbLastName.MaxLength = 15;
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(98, 20);
			this.tbLastName.TabIndex = 1;
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(143, 22);
			this.tbName.MaxLength = 15;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(98, 20);
			this.tbName.TabIndex = 0;
			// 
			// tbMail
			// 
			this.tbMail.Location = new System.Drawing.Point(143, 100);
			this.tbMail.MaxLength = 30;
			this.tbMail.Name = "tbMail";
			this.tbMail.Size = new System.Drawing.Size(168, 20);
			this.tbMail.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nombre de Usuario*";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(82, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Apellido";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(66, 77);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Nacimiento";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(90, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "E-Mail";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(78, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Nombre*";
			// 
			// lblPass
			// 
			this.lblPass.AutoSize = true;
			this.lblPass.Location = new System.Drawing.Point(62, 58);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new System.Drawing.Size(64, 13);
			this.lblPass.TabIndex = 2;
			this.lblPass.Text = "Contraseña:";
			// 
			// tbPass
			// 
			this.tbPass.Location = new System.Drawing.Point(143, 55);
			this.tbPass.MaxLength = 8;
			this.tbPass.Name = "tbPass";
			this.tbPass.PasswordChar = '*';
			this.tbPass.Size = new System.Drawing.Size(168, 20);
			this.tbPass.TabIndex = 1;
			this.tbPass.UseSystemPasswordChar = true;
			this.tbPass.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
			this.tbPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPass_KeyPress);
			// 
			// lblPass2
			// 
			this.lblPass2.AutoSize = true;
			this.lblPass2.Location = new System.Drawing.Point(17, 84);
			this.lblPass2.Name = "lblPass2";
			this.lblPass2.Size = new System.Drawing.Size(109, 13);
			this.lblPass2.TabIndex = 2;
			this.lblPass2.Text = "Repita la Contraseña:";
			// 
			// dtpBirth
			// 
			this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpBirth.Location = new System.Drawing.Point(143, 74);
			this.dtpBirth.Name = "dtpBirth";
			this.dtpBirth.Size = new System.Drawing.Size(98, 20);
			this.dtpBirth.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbLastName);
			this.groupBox1.Controls.Add(this.dtpBirth);
			this.groupBox1.Controls.Add(this.tbMail);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(24, 159);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(339, 132);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos Personales";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblPass2);
			this.groupBox2.Controls.Add(this.tbUser);
			this.groupBox2.Controls.Add(this.tbPass2);
			this.groupBox2.Controls.Add(this.tbPass);
			this.groupBox2.Controls.Add(this.lblPass);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(24, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(339, 125);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Inicio de Sesión";
			// 
			// tbPass2
			// 
			this.tbPass2.Location = new System.Drawing.Point(143, 81);
			this.tbPass2.MaxLength = 8;
			this.tbPass2.Name = "tbPass2";
			this.tbPass2.PasswordChar = '*';
			this.tbPass2.Size = new System.Drawing.Size(168, 20);
			this.tbPass2.TabIndex = 2;
			this.tbPass2.UseSystemPasswordChar = true;
			this.tbPass2.TextChanged += new System.EventHandler(this.tbPass2_TextChanged);
			this.tbPass2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPass2_KeyPress);
			this.tbPass2.Validating += new System.ComponentModel.CancelEventHandler(this.tbPass2_Validating);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(287, 306);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAceptar.Location = new System.Drawing.Point(197, 306);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 2;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// FormRegister
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(374, 341);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "FormRegister";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registro de usuario";
			this.Load += new System.EventHandler(this.FormRegister_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TextBox tbUser;
		private System.Windows.Forms.TextBox tbLastName;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbMail;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblPass;
		private System.Windows.Forms.TextBox tbPass;
		private System.Windows.Forms.Label lblPass2;
		private System.Windows.Forms.DateTimePicker dtpBirth;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.TextBox tbPass2;
	}
}