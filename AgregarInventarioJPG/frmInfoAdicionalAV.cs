using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AgregarInventarioJPG
{
	public class frmInfoAdicionalAV : Form
	{
		private IContainer components = null;

		private Label lblCaducidadAV;

		private Label lblObsAV;

		private DateTimePicker dptFechaCaducidad;

		private TextBox txtObsAV;

		private Button btnGuardaInfoAddAV;

		private TextBox txtInstrucciones;

		public frmInfoAdicionalAV()
		{
			this.InitializeComponent();
		}

		private void btnGuardaInfoAddAV_Click(object sender, EventArgs e)
		{
			conectaBD _conectaBD = new conectaBD();
			// _conectaBD.UpdateAV(frmInfoComputadora.idAVAlt, this.dptFechaCaducidad.Text, this.txtObsAV.Text);
			_conectaBD.CloseConnection();
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void frmInfoAdicionalAV_Load(object sender, EventArgs e)
		{
			this.txtInstrucciones.Text = "Ha seleccionado registrar un antivirus de la lista, por favor seleccione la fecha de caducidad; por default se establece 15 dias despues de la fecha de registro. Para modificar estos valores puede volver a registrar el equipo con esta aplicacion o a traves de la pagina www.nscco.com.mx.";
			this.dptFechaCaducidad.Value = this.dptFechaCaducidad.Value.AddDays(15);
			this.dptFechaCaducidad.Format = DateTimePickerFormat.Custom;
			this.dptFechaCaducidad.CustomFormat = "yyyy-MM-dd";
		}

		private void InitializeComponent()
		{
			this.lblCaducidadAV = new Label();
			this.lblObsAV = new Label();
			this.dptFechaCaducidad = new DateTimePicker();
			this.txtObsAV = new TextBox();
			this.btnGuardaInfoAddAV = new Button();
			this.txtInstrucciones = new TextBox();
			base.SuspendLayout();
			this.lblCaducidadAV.AutoSize = true;
			this.lblCaducidadAV.Location = new Point(13, 126);
			this.lblCaducidadAV.Name = "lblCaducidadAV";
			this.lblCaducidadAV.Size = new System.Drawing.Size(106, 13);
			this.lblCaducidadAV.TabIndex = 0;
			this.lblCaducidadAV.Text = "Fecha de Caducidad";
			this.lblObsAV.AutoSize = true;
			this.lblObsAV.Location = new Point(13, 151);
			this.lblObsAV.Name = "lblObsAV";
			this.lblObsAV.Size = new System.Drawing.Size(78, 13);
			this.lblObsAV.TabIndex = 1;
			this.lblObsAV.Text = "Observaciones";
			this.dptFechaCaducidad.Location = new Point(132, 119);
			this.dptFechaCaducidad.Name = "dptFechaCaducidad";
			this.dptFechaCaducidad.Size = new System.Drawing.Size(200, 20);
			this.dptFechaCaducidad.TabIndex = 2;
			this.txtObsAV.Location = new Point(132, 143);
			this.txtObsAV.Name = "txtObsAV";
			this.txtObsAV.Size = new System.Drawing.Size(200, 20);
			this.txtObsAV.TabIndex = 3;
			this.btnGuardaInfoAddAV.Location = new Point(131, 170);
			this.btnGuardaInfoAddAV.Name = "btnGuardaInfoAddAV";
			this.btnGuardaInfoAddAV.Size = new System.Drawing.Size(75, 23);
			this.btnGuardaInfoAddAV.TabIndex = 4;
			this.btnGuardaInfoAddAV.Text = "Guardar";
			this.btnGuardaInfoAddAV.UseVisualStyleBackColor = true;
			this.btnGuardaInfoAddAV.Click += new EventHandler(this.btnGuardaInfoAddAV_Click);
			this.txtInstrucciones.Location = new Point(13, 13);
			this.txtInstrucciones.Margin = new System.Windows.Forms.Padding(0);
			this.txtInstrucciones.Multiline = true;
			this.txtInstrucciones.Name = "txtInstrucciones";
			this.txtInstrucciones.ReadOnly = true;
			this.txtInstrucciones.Size = new System.Drawing.Size(0x13f, 86);
			this.txtInstrucciones.TabIndex = 5;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(0x15d, 209);
			base.Controls.Add(this.txtInstrucciones);
			base.Controls.Add(this.btnGuardaInfoAddAV);
			base.Controls.Add(this.txtObsAV);
			base.Controls.Add(this.dptFechaCaducidad);
			base.Controls.Add(this.lblObsAV);
			base.Controls.Add(this.lblCaducidadAV);
			base.Name = "frmInfoAdicionalAV";
			this.Text = "Info adicional de AV";
			base.Load += new EventHandler(this.frmInfoAdicionalAV_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}