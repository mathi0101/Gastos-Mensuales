
namespace Administración_de_gastos.Forms.Inicio_Programa {
	partial class FormSplashScreen {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelslide = new System.Windows.Forms.Panel();
			this.label = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("NSimSun", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(100, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(252, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = "Loading";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.CadetBlue;
			this.panel1.Controls.Add(this.panelslide);
			this.panel1.Location = new System.Drawing.Point(54, 160);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(337, 14);
			this.panel1.TabIndex = 1;
			// 
			// panelslide
			// 
			this.panelslide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.panelslide.Location = new System.Drawing.Point(263, 0);
			this.panelslide.Name = "panelslide";
			this.panelslide.Size = new System.Drawing.Size(74, 14);
			this.panelslide.TabIndex = 1;
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.Transparent;
			this.label.Location = new System.Drawing.Point(54, 177);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(337, 14);
			this.label.TabIndex = 2;
			this.label.Text = "progreso";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer
			// 
			this.timer.Interval = 10;
			this.timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// FormSplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::Administración_de_gastos.Properties.Resources.Loading_Screen;
			this.ClientSize = new System.Drawing.Size(450, 235);
			this.Controls.Add(this.label);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSplashScreen";
			this.Opacity = 0.75D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormCargar";
			this.UseWaitCursor = true;
			this.Load += new System.EventHandler(this.FormSplashScreen_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panelslide;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label label;
	}
}