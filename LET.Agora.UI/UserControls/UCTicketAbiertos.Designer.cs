namespace LET.Agora.UI.UserControls
{
    partial class UCTicketAbiertos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            label2 = new Label();
            lblTicketAbierto = new Label();
            panel1 = new Panel();
            btnSalir = new Button();
            listViewTicketAbierto = new ListView();
            GlobalId = new ColumnHeader();
            BusinessDay = new ColumnHeader();
            UserId = new ColumnHeader();
            PosId = new ColumnHeader();
            PosName = new ColumnHeader();
            UserName = new ColumnHeader();
            NetAmount = new ColumnHeader();
            btnRefrescar = new Button();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(48, 54, 110);
            panelTop.Controls.Add(btnRefrescar);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(lblTicketAbierto);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1105, 71);
            panelTop.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(2002, 13);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 1;
            label2.Text = "CLIENTE:";
            // 
            // lblTicketAbierto
            // 
            lblTicketAbierto.AutoSize = true;
            lblTicketAbierto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTicketAbierto.ForeColor = SystemColors.ButtonFace;
            lblTicketAbierto.Location = new Point(3, 9);
            lblTicketAbierto.Name = "lblTicketAbierto";
            lblTicketAbierto.Size = new Size(167, 25);
            lblTicketAbierto.TabIndex = 0;
            lblTicketAbierto.Text = "TICKET ABIERTOS";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(48, 54, 110);
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 731);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 78);
            panel1.TabIndex = 3;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(854, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(248, 72);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // listViewTicketAbierto
            // 
            listViewTicketAbierto.Columns.AddRange(new ColumnHeader[] { GlobalId, BusinessDay, UserId, PosId, PosName, UserName, NetAmount });
            listViewTicketAbierto.Dock = DockStyle.Fill;
            listViewTicketAbierto.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            listViewTicketAbierto.FullRowSelect = true;
            listViewTicketAbierto.GridLines = true;
            listViewTicketAbierto.Location = new Point(0, 71);
            listViewTicketAbierto.MultiSelect = false;
            listViewTicketAbierto.Name = "listViewTicketAbierto";
            listViewTicketAbierto.Size = new Size(1105, 660);
            listViewTicketAbierto.TabIndex = 4;
            listViewTicketAbierto.UseCompatibleStateImageBehavior = false;
            listViewTicketAbierto.View = View.Details;
            listViewTicketAbierto.SelectedIndexChanged += listViewTicketAbierto_SelectedIndexChanged;
            // 
            // GlobalId
            // 
            GlobalId.Text = "Global Id";
            GlobalId.Width = 0;
            // 
            // BusinessDay
            // 
            BusinessDay.Text = "Business Day";
            BusinessDay.Width = 0;
            // 
            // UserId
            // 
            UserId.Text = "User ID";
            UserId.Width = 0;
            // 
            // PosId
            // 
            PosId.Text = "Pos Id";
            PosId.Width = 0;
            // 
            // PosName
            // 
            PosName.Text = "PUNTO DE VENTA";
            PosName.Width = 250;
            // 
            // UserName
            // 
            UserName.Text = "CAJERO";
            UserName.Width = 500;
            // 
            // NetAmount
            // 
            NetAmount.Text = "TOTAL";
            NetAmount.Width = 1000;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefrescar.Location = new Point(902, 9);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(176, 45);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "REFRESCAR";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // UCTicketAbiertos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listViewTicketAbierto);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            Name = "UCTicketAbiertos";
            Size = new Size(1105, 809);
            Load += UCTicketAbiertos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label label2;
        private Label lblTicketAbierto;
        private Panel panel1;
        private Button btnSalir;
        private ListView listViewTicketAbierto;
        private ColumnHeader GlobalId;
        private ColumnHeader BusinessDay;
        private ColumnHeader UserId;
        private ColumnHeader PosId;
        private ColumnHeader PosName;
        private ColumnHeader UserName;
        private ColumnHeader NetAmount;
        private Button btnRefrescar;
    }
}
