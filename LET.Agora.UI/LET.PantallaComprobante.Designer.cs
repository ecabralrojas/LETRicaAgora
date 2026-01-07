namespace LET.Agora.UI
{
    partial class frmPantallaComprobante
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
            panelTop = new Panel();
            btnBuscarRNC = new Button();
            btnClear = new Button();
            txtRazonSocial = new TextBox();
            label2 = new Label();
            lblComprobanteFiscales = new Label();
            txtRNC = new TextBox();
            lvComprobantes = new ListView();
            Tipo = new ColumnHeader();
            Descripcion = new ColumnHeader();
            ID = new ColumnHeader();
            NCFPrefix = new ColumnHeader();
            NCFSecuenciaInicial = new ColumnHeader();
            NCFSecuenciaFinal = new ColumnHeader();
            NCFFechaVencimiento = new ColumnHeader();
            NCFSecuenciaActual = new ColumnHeader();
            Status = new ColumnHeader();
            Serie = new ColumnHeader();
            AvisoComprobantes = new ColumnHeader();
            TieneDisponible = new ColumnHeader();
            MensajeComprobantes = new ColumnHeader();
            AvisoVencimiento = new ColumnHeader();
            TienenVencimiento = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            lblMensaje = new Label();
            btnAsignar = new Button();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(48, 54, 110);
            panelTop.Controls.Add(btnBuscarRNC);
            panelTop.Controls.Add(btnClear);
            panelTop.Controls.Add(txtRazonSocial);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(lblComprobanteFiscales);
            panelTop.Controls.Add(txtRNC);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(895, 117);
            panelTop.TabIndex = 3;
            // 
            // btnBuscarRNC
            // 
            btnBuscarRNC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBuscarRNC.Location = new Point(570, 42);
            btnBuscarRNC.Name = "btnBuscarRNC";
            btnBuscarRNC.Size = new Size(141, 59);
            btnBuscarRNC.TabIndex = 18;
            btnBuscarRNC.Text = "BUSCAR RNC";
            btnBuscarRNC.UseVisualStyleBackColor = true;
            btnBuscarRNC.Click += btnBuscarRNC_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(728, 42);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(139, 59);
            btnClear.TabIndex = 17;
            btnClear.Text = "CLR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRazonSocial.Location = new Point(23, 72);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.PlaceholderText = "RAZON SOCIAL";
            txtRazonSocial.Size = new Size(513, 29);
            txtRazonSocial.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(2697, 13);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 1;
            label2.Text = "CLIENTE:";
            // 
            // lblComprobanteFiscales
            // 
            lblComprobanteFiscales.AutoSize = true;
            lblComprobanteFiscales.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblComprobanteFiscales.ForeColor = SystemColors.ButtonFace;
            lblComprobanteFiscales.Location = new Point(17, 3);
            lblComprobanteFiscales.Name = "lblComprobanteFiscales";
            lblComprobanteFiscales.Size = new Size(443, 25);
            lblComprobanteFiscales.TabIndex = 0;
            lblComprobanteFiscales.Text = "SELECCIONE  EL TIPO DE COMPROBANTE FISCAL";
            // 
            // txtRNC
            // 
            txtRNC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRNC.Location = new Point(23, 37);
            txtRNC.Name = "txtRNC";
            txtRNC.PlaceholderText = "DIGITE RNC";
            txtRNC.Size = new Size(233, 29);
            txtRNC.TabIndex = 5;
            // 
            // lvComprobantes
            // 
            lvComprobantes.Columns.AddRange(new ColumnHeader[] { Tipo, Descripcion, ID, NCFPrefix, NCFSecuenciaInicial, NCFSecuenciaFinal, NCFFechaVencimiento, NCFSecuenciaActual, Status, Serie, AvisoComprobantes, TieneDisponible, MensajeComprobantes, AvisoVencimiento, TienenVencimiento });
            lvComprobantes.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lvComprobantes.FullRowSelect = true;
            lvComprobantes.GridLines = true;
            lvComprobantes.Location = new Point(158, 156);
            lvComprobantes.Name = "lvComprobantes";
            lvComprobantes.Size = new Size(595, 255);
            lvComprobantes.TabIndex = 4;
            lvComprobantes.UseCompatibleStateImageBehavior = false;
            lvComprobantes.View = View.Details;
            lvComprobantes.SelectedIndexChanged += lvComprobantes_SelectedIndexChanged;
            // 
            // Tipo
            // 
            Tipo.Text = "TIPO";
            Tipo.Width = 100;
            // 
            // Descripcion
            // 
            Descripcion.Text = "DESCRIPCION";
            Descripcion.Width = 1000;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 0;
            // 
            // NCFPrefix
            // 
            NCFPrefix.Text = "NCFPrefix";
            NCFPrefix.Width = 0;
            // 
            // NCFSecuenciaInicial
            // 
            NCFSecuenciaInicial.Text = "NCFSecuenciaInicial";
            NCFSecuenciaInicial.Width = 0;
            // 
            // NCFSecuenciaFinal
            // 
            NCFSecuenciaFinal.Text = "NCFSecuenciaFinal";
            NCFSecuenciaFinal.Width = 0;
            // 
            // NCFFechaVencimiento
            // 
            NCFFechaVencimiento.Text = "NCFFechaVencimiento";
            NCFFechaVencimiento.Width = 0;
            // 
            // NCFSecuenciaActual
            // 
            NCFSecuenciaActual.Text = "NCFSecuenciaActual";
            NCFSecuenciaActual.Width = 0;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 0;
            // 
            // Serie
            // 
            Serie.Text = "Serie";
            Serie.Width = 0;
            // 
            // AvisoComprobantes
            // 
            AvisoComprobantes.Text = "AvisoComprobantes";
            AvisoComprobantes.Width = 0;
            // 
            // TieneDisponible
            // 
            TieneDisponible.Text = "TieneDisponible";
            TieneDisponible.Width = 0;
            // 
            // MensajeComprobantes
            // 
            MensajeComprobantes.Text = "MensajeComprobantes";
            MensajeComprobantes.Width = 0;
            // 
            // AvisoVencimiento
            // 
            AvisoVencimiento.Text = "AvisoVencimiento";
            AvisoVencimiento.Width = 0;
            // 
            // TienenVencimiento
            // 
            TienenVencimiento.Text = "TienenVencimiento";
            TienenVencimiento.Width = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(306, 645);
            button1.Name = "button1";
            button1.Size = new Size(82, 70);
            button1.TabIndex = 7;
            button1.Text = "0";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(306, 569);
            button2.Name = "button2";
            button2.Size = new Size(82, 70);
            button2.TabIndex = 8;
            button2.Text = "1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(394, 569);
            button3.Name = "button3";
            button3.Size = new Size(82, 70);
            button3.TabIndex = 9;
            button3.Text = "2";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(482, 569);
            button4.Name = "button4";
            button4.Size = new Size(82, 70);
            button4.TabIndex = 10;
            button4.Text = "3";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(306, 493);
            button5.Name = "button5";
            button5.Size = new Size(82, 70);
            button5.TabIndex = 11;
            button5.Text = "4";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(394, 493);
            button6.Name = "button6";
            button6.Size = new Size(82, 70);
            button6.TabIndex = 12;
            button6.Text = "5";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(482, 493);
            button7.Name = "button7";
            button7.Size = new Size(82, 70);
            button7.TabIndex = 13;
            button7.Text = "6";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(306, 417);
            button8.Name = "button8";
            button8.Size = new Size(82, 70);
            button8.TabIndex = 14;
            button8.Text = "7";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(394, 417);
            button9.Name = "button9";
            button9.Size = new Size(82, 70);
            button9.TabIndex = 15;
            button9.Text = "8";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button10.Location = new Point(482, 417);
            button10.Name = "button10";
            button10.Size = new Size(82, 70);
            button10.TabIndex = 16;
            button10.Text = "9";
            button10.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Location = new Point(158, 120);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 20);
            lblMensaje.TabIndex = 18;
            // 
            // btnAsignar
            // 
            btnAsignar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAsignar.Location = new Point(394, 645);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(170, 70);
            btnAsignar.TabIndex = 19;
            btnAsignar.Text = "Aceptar";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // frmPantallaComprobante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(895, 814);
            Controls.Add(btnAsignar);
            Controls.Add(lblMensaje);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lvComprobantes);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmPantallaComprobante";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LET";
            Load += frmPantallaComprobante_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void InitializeNumericButton()
        {
            Buttons[0] = button1;
            Buttons[1] = button2;
            Buttons[2] = button3;
            Buttons[3] = button4;
            Buttons[4] = button5;
            Buttons[5] = button6;
            Buttons[6] = button7;
            Buttons[7] = button8;
            Buttons[8] = button9;
            Buttons[9] = button10;

            Buttons[0].Click += new EventHandler(Buttons_Click);
            Buttons[1].Click += new EventHandler(Buttons_Click);
            Buttons[2].Click += new EventHandler(Buttons_Click);
            Buttons[3].Click += new EventHandler(Buttons_Click);
            Buttons[4].Click += new EventHandler(Buttons_Click);
            Buttons[5].Click += new EventHandler(Buttons_Click);
            Buttons[6].Click += new EventHandler(Buttons_Click);
            Buttons[7].Click += new EventHandler(Buttons_Click);
            Buttons[8].Click += new EventHandler(Buttons_Click);
            Buttons[9].Click += new EventHandler(Buttons_Click);

        }

        private Button[] Buttons = new Button[10];

        private Panel panelTop;
        private Label label2;
        private Label lblComprobanteFiscales;
        private ListView lvComprobantes;
        private ColumnHeader Tipo;
        private ColumnHeader Descripcion;
        private ColumnHeader ID;
        private ColumnHeader NCFPrefix;
        private ColumnHeader NCFSecuenciaInicial;
        private ColumnHeader NCFSecuenciaFinal;
        private ColumnHeader NCFFechaVencimiento;
        private ColumnHeader NCFSecuenciaActual;
        private ColumnHeader Status;
        private ColumnHeader Serie;
        private ColumnHeader AvisoComprobantes;
        private ColumnHeader TieneDisponible;
        private ColumnHeader MensajeComprobantes;
        private ColumnHeader AvisoVencimiento;
        private ColumnHeader TienenVencimiento;
        private TextBox txtRNC;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button btnClear;
        private TextBox txtRazonSocial;
        private Button btnBuscarRNC;
        private Label lblMensaje;
        private Button btnAsignar;
    }
}