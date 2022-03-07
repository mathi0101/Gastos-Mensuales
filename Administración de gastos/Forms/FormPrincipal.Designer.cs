
namespace MisGastos.Forms.Programa_Principal {
	partial class FormPrincipal {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusFechaHora = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.informaciónPersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gestiónDeTarjetasBancariasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1Second = new System.Windows.Forms.Timer(this.components);
			this.ingresosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusUsuario,
            this.toolStripStatusFechaHora});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.statusStrip1.Location = new System.Drawing.Point(0, 581);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1228, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusUsuario
			// 
			this.toolStripStatusUsuario.Name = "toolStripStatusUsuario";
			this.toolStripStatusUsuario.Size = new System.Drawing.Size(47, 17);
			this.toolStripStatusUsuario.Text = "Usuario";
			// 
			// toolStripStatusFechaHora
			// 
			this.toolStripStatusFechaHora.Name = "toolStripStatusFechaHora";
			this.toolStripStatusFechaHora.Size = new System.Drawing.Size(113, 17);
			this.toolStripStatusFechaHora.Text = "Fecha y Hora Actual";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónPersonalToolStripMenuItem,
            this.ingresosToolStripMenuItem,
            this.gastosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(1228, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// informaciónPersonalToolStripMenuItem
			// 
			this.informaciónPersonalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeTarjetasBancariasToolStripMenuItem});
			this.informaciónPersonalToolStripMenuItem.Name = "informaciónPersonalToolStripMenuItem";
			this.informaciónPersonalToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.informaciónPersonalToolStripMenuItem.Text = "Personal";
			// 
			// gestiónDeTarjetasBancariasToolStripMenuItem
			// 
			this.gestiónDeTarjetasBancariasToolStripMenuItem.Name = "gestiónDeTarjetasBancariasToolStripMenuItem";
			this.gestiónDeTarjetasBancariasToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			this.gestiónDeTarjetasBancariasToolStripMenuItem.Text = "Gestión de tarjetas bancarias";
			this.gestiónDeTarjetasBancariasToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeTarjetasBancariasToolStripMenuItem_Click);
			// 
			// ingresosToolStripMenuItem
			// 
			this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
			this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.ingresosToolStripMenuItem.Text = "Ingresos";
			// 
			// gastosToolStripMenuItem
			// 
			this.gastosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosToolStripMenuItem1});
			this.gastosToolStripMenuItem.Name = "gastosToolStripMenuItem";
			this.gastosToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.gastosToolStripMenuItem.Text = "Gastos";
			// 
			// timer1Second
			// 
			this.timer1Second.Enabled = true;
			this.timer1Second.Interval = 1000;
			this.timer1Second.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ingresosToolStripMenuItem1
			// 
			this.ingresosToolStripMenuItem1.Name = "ingresosToolStripMenuItem1";
			this.ingresosToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.ingresosToolStripMenuItem1.Text = "Nuevo Ingreso";
			this.ingresosToolStripMenuItem1.Click += new System.EventHandler(this.ingresosToolStripMenuItem1_Click);
			// 
			// FormPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1228, 603);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormPrincipal";
			this.Text = "Gestión de gastos";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FormPrincipal_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUsuario;
		private System.Windows.Forms.ToolStripMenuItem informaciónPersonalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gastosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gestiónDeTarjetasBancariasToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusFechaHora;
		private System.Windows.Forms.Timer timer1Second;
		private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem1;
	}
}