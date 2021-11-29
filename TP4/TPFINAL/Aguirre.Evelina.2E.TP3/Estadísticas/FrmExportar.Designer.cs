
namespace UserInterfaz
{
    partial class FrmExportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExportar));
            this.lnklbCerrar = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pgbXmlConsultaActual = new System.Windows.Forms.ProgressBar();
            this.pgbXmlTodosLosRegistros = new System.Windows.Forms.ProgressBar();
            this.pgbJsonTodosLosRegistros = new System.Windows.Forms.ProgressBar();
            this.pgbJsonConsultaActual = new System.Windows.Forms.ProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lnklbCerrar
            // 
            this.lnklbCerrar.AutoSize = true;
            this.lnklbCerrar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnklbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("lnklbCerrar.Image")));
            this.lnklbCerrar.LinkColor = System.Drawing.Color.Black;
            this.lnklbCerrar.Location = new System.Drawing.Point(456, -4);
            this.lnklbCerrar.Name = "lnklbCerrar";
            this.lnklbCerrar.Size = new System.Drawing.Size(37, 30);
            this.lnklbCerrar.TabIndex = 4;
            this.lnklbCerrar.TabStop = true;
            this.lnklbCerrar.Text = "    ";
            this.lnklbCerrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbCerrar_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 22);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exportar Conulta Actual";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExportarXmlConsultaActual_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 22);
            this.button2.TabIndex = 7;
            this.button2.Text = "Exportar todas las encuestas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnExportarXmlTodasLasConsultas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox1.Location = new System.Drawing.Point(27, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 95);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 217);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 22);
            this.button3.TabIndex = 11;
            this.button3.Text = "Exportar todas las encuestas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(41, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(187, 22);
            this.button4.TabIndex = 10;
            this.button4.Text = "Exportar Conulta Actual";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox2.Location = new System.Drawing.Point(27, 161);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(442, 95);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Formato .xml :";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(27, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Formato Json :";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // pgbXmlConsultaActual
            // 
            this.pgbXmlConsultaActual.Location = new System.Drawing.Point(238, 51);
            this.pgbXmlConsultaActual.Name = "pgbXmlConsultaActual";
            this.pgbXmlConsultaActual.Size = new System.Drawing.Size(219, 10);
            this.pgbXmlConsultaActual.TabIndex = 15;
            // 
            // pgbXmlTodosLosRegistros
            // 
            this.pgbXmlTodosLosRegistros.Location = new System.Drawing.Point(238, 91);
            this.pgbXmlTodosLosRegistros.Name = "pgbXmlTodosLosRegistros";
            this.pgbXmlTodosLosRegistros.Size = new System.Drawing.Size(219, 10);
            this.pgbXmlTodosLosRegistros.TabIndex = 16;
            // 
            // pgbJsonTodosLosRegistros
            // 
            this.pgbJsonTodosLosRegistros.Location = new System.Drawing.Point(238, 221);
            this.pgbJsonTodosLosRegistros.Name = "pgbJsonTodosLosRegistros";
            this.pgbJsonTodosLosRegistros.Size = new System.Drawing.Size(219, 10);
            this.pgbJsonTodosLosRegistros.TabIndex = 18;
            // 
            // pgbJsonConsultaActual
            // 
            this.pgbJsonConsultaActual.Location = new System.Drawing.Point(238, 181);
            this.pgbJsonConsultaActual.Name = "pgbJsonConsultaActual";
            this.pgbJsonConsultaActual.Size = new System.Drawing.Size(219, 10);
            this.pgbJsonConsultaActual.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(133, 267);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Cancelar ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnCancelarOperacion_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(27, 267);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "Guardar todos";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(369, 267);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 23);
            this.button7.TabIndex = 21;
            this.button7.Text = "Aceptar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // FrmExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(490, 302);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pgbJsonTodosLosRegistros);
            this.Controls.Add(this.pgbJsonConsultaActual);
            this.Controls.Add(this.pgbXmlTodosLosRegistros);
            this.Controls.Add(this.pgbXmlConsultaActual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lnklbCerrar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmExportar";
            this.Load += new System.EventHandler(this.FrmExportar_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmExportar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmExportar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmExportar_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel lnklbCerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pgbXmlConsultaActual;
        private System.Windows.Forms.ProgressBar pgbXmlTodosLosRegistros;
        private System.Windows.Forms.ProgressBar pgbJsonTodosLosRegistros;
        private System.Windows.Forms.ProgressBar pgbJsonConsultaActual;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}