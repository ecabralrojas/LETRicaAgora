namespace LET.Agora.UI.UserControls
{
    partial class UCFormaPago
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
            panel1 = new Panel();
            lblVentaCambio = new Label();
            lblVentaEntregada = new Label();
            lblVentaImporte = new Label();
            lblVentaFactura = new Label();
            btnVolver = new Button();
            btnCobrar = new Button();
            btnTicketAbierto = new Button();
            panelTop = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            lblRazonSocial = new Label();
            lblRNC = new Label();
            lblDescripcionComprobante = new Label();
            lblRNCTipo = new Label();
            btnComprobantes = new Button();
            lblCodigoCliente = new Label();
            lblCliente = new Label();
            lblCobrarTicket = new Label();
            panelRight = new Panel();
            lblMontoCambio = new Label();
            lblMontoEntregado = new Label();
            lblMontoTotal = new Label();
            lblCambio = new Label();
            lblEntregado = new Label();
            lblTotal = new Label();
            lblMontoPendiente = new Label();
            lblPendiente = new Label();
            panelLeft = new Panel();
            panel2 = new Panel();
            lblMensaje = new Label();
            listViewFormaPago = new ListView();
            TicketGlobalId = new ColumnHeader();
            PosId = new ColumnHeader();
            UserId = new ColumnHeader();
            Date = new ColumnHeader();
            PaymentMethodId = new ColumnHeader();
            Amount = new ColumnHeader();
            PaidAmount = new ColumnHeader();
            ChangeAmount = new ColumnHeader();
            TipAmount = new ColumnHeader();
            KeepOpen = new ColumnHeader();
            ExtraInformation = new ColumnHeader();
            FormaDePago = new ColumnHeader();
            Entregado = new ColumnHeader();
            Eliminar = new ColumnHeader();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button0 = new Button();
            buttonPunto = new Button();
            txtEntregado = new TextBox();
            btnGuion = new Button();
            btnEnter = new Button();
            btnClear = new Button();
            flowLayoutPanelPagos = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panelTop.SuspendLayout();
            panelRight.SuspendLayout();
            panelLeft.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(48, 54, 110);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblVentaCambio);
            panel1.Controls.Add(lblVentaEntregada);
            panel1.Controls.Add(lblVentaImporte);
            panel1.Controls.Add(lblVentaFactura);
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(btnCobrar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 686);
            panel1.Name = "panel1";
            panel1.Size = new Size(1199, 107);
            panel1.TabIndex = 0;
            // 
            // lblVentaCambio
            // 
            lblVentaCambio.AutoSize = true;
            lblVentaCambio.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVentaCambio.ForeColor = SystemColors.ButtonHighlight;
            lblVentaCambio.Location = new Point(604, 77);
            lblVentaCambio.Name = "lblVentaCambio";
            lblVentaCambio.Size = new Size(119, 25);
            lblVentaCambio.TabIndex = 25;
            lblVentaCambio.Text = "CAMBIADO:";
            // 
            // lblVentaEntregada
            // 
            lblVentaEntregada.AutoSize = true;
            lblVentaEntregada.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVentaEntregada.ForeColor = SystemColors.ButtonHighlight;
            lblVentaEntregada.Location = new Point(604, 52);
            lblVentaEntregada.Name = "lblVentaEntregada";
            lblVentaEntregada.Size = new Size(130, 25);
            lblVentaEntregada.TabIndex = 24;
            lblVentaEntregada.Text = "ENTREGADO:";
            // 
            // lblVentaImporte
            // 
            lblVentaImporte.AutoSize = true;
            lblVentaImporte.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVentaImporte.ForeColor = SystemColors.ButtonHighlight;
            lblVentaImporte.Location = new Point(604, 27);
            lblVentaImporte.Name = "lblVentaImporte";
            lblVentaImporte.Size = new Size(100, 25);
            lblVentaImporte.TabIndex = 23;
            lblVentaImporte.Text = "IMPORTE:";
            // 
            // lblVentaFactura
            // 
            lblVentaFactura.AutoSize = true;
            lblVentaFactura.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVentaFactura.ForeColor = SystemColors.ButtonHighlight;
            lblVentaFactura.Location = new Point(604, 2);
            lblVentaFactura.Name = "lblVentaFactura";
            lblVentaFactura.Size = new Size(78, 25);
            lblVentaFactura.TabIndex = 22;
            lblVentaFactura.Text = "VENTA:";
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(963, 14);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(232, 68);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnCobrar
            // 
            btnCobrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCobrar.Location = new Point(2, 18);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(332, 69);
            btnCobrar.TabIndex = 0;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // btnTicketAbierto
            // 
            btnTicketAbierto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTicketAbierto.Location = new Point(1089, 20);
            btnTicketAbierto.Name = "btnTicketAbierto";
            btnTicketAbierto.Size = new Size(94, 75);
            btnTicketAbierto.TabIndex = 26;
            btnTicketAbierto.Text = "TICKET ABIERTO";
            btnTicketAbierto.UseVisualStyleBackColor = true;
            btnTicketAbierto.Click += btnTicketAbierto_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(48, 54, 110);
            panelTop.Controls.Add(btnTicketAbierto);
            panelTop.Controls.Add(label5);
            panelTop.Controls.Add(label4);
            panelTop.Controls.Add(label3);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(lblRazonSocial);
            panelTop.Controls.Add(lblRNC);
            panelTop.Controls.Add(lblDescripcionComprobante);
            panelTop.Controls.Add(lblRNCTipo);
            panelTop.Controls.Add(btnComprobantes);
            panelTop.Controls.Add(lblCodigoCliente);
            panelTop.Controls.Add(lblCliente);
            panelTop.Controls.Add(lblCobrarTicket);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1199, 116);
            panelTop.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(579, 79);
            label5.Name = "label5";
            label5.Size = new Size(154, 25);
            label5.TabIndex = 24;
            label5.Text = "RAZON SOCIAL:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(579, 54);
            label4.Name = "label4";
            label4.Size = new Size(56, 25);
            label4.TabIndex = 23;
            label4.Text = "RNC:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(579, 29);
            label3.Name = "label3";
            label3.Size = new Size(160, 25);
            label3.TabIndex = 22;
            label3.Text = "COMPROBANTE:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(579, 4);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 21;
            label1.Text = "TIPO:";
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblRazonSocial.ForeColor = SystemColors.ButtonHighlight;
            lblRazonSocial.Location = new Point(735, 79);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(0, 25);
            lblRazonSocial.TabIndex = 20;
            // 
            // lblRNC
            // 
            lblRNC.AutoSize = true;
            lblRNC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblRNC.ForeColor = SystemColors.ButtonHighlight;
            lblRNC.Location = new Point(637, 54);
            lblRNC.Name = "lblRNC";
            lblRNC.Size = new Size(0, 25);
            lblRNC.TabIndex = 19;
            // 
            // lblDescripcionComprobante
            // 
            lblDescripcionComprobante.AutoSize = true;
            lblDescripcionComprobante.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescripcionComprobante.ForeColor = SystemColors.ButtonHighlight;
            lblDescripcionComprobante.Location = new Point(739, 29);
            lblDescripcionComprobante.Name = "lblDescripcionComprobante";
            lblDescripcionComprobante.Size = new Size(0, 25);
            lblDescripcionComprobante.TabIndex = 18;
            // 
            // lblRNCTipo
            // 
            lblRNCTipo.AutoSize = true;
            lblRNCTipo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblRNCTipo.ForeColor = SystemColors.ButtonHighlight;
            lblRNCTipo.Location = new Point(646, 4);
            lblRNCTipo.Name = "lblRNCTipo";
            lblRNCTipo.Size = new Size(0, 25);
            lblRNCTipo.TabIndex = 17;
            // 
            // btnComprobantes
            // 
            btnComprobantes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnComprobantes.Location = new Point(964, 20);
            btnComprobantes.Name = "btnComprobantes";
            btnComprobantes.Size = new Size(119, 75);
            btnComprobantes.TabIndex = 3;
            btnComprobantes.Text = "COMPROBANTES";
            btnComprobantes.UseVisualStyleBackColor = true;
            btnComprobantes.Click += btnComprobantes_Click;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigoCliente.ForeColor = SystemColors.ButtonFace;
            lblCodigoCliente.Location = new Point(8, 29);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(0, 25);
            lblCodigoCliente.TabIndex = 2;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCliente.ForeColor = SystemColors.ButtonFace;
            lblCliente.Location = new Point(8, 54);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(0, 25);
            lblCliente.TabIndex = 1;
            // 
            // lblCobrarTicket
            // 
            lblCobrarTicket.AutoSize = true;
            lblCobrarTicket.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCobrarTicket.ForeColor = SystemColors.ButtonFace;
            lblCobrarTicket.Location = new Point(8, 4);
            lblCobrarTicket.Name = "lblCobrarTicket";
            lblCobrarTicket.Size = new Size(154, 25);
            lblCobrarTicket.TabIndex = 0;
            lblCobrarTicket.Text = "COBRAR TICKET";
            // 
            // panelRight
            // 
            panelRight.BorderStyle = BorderStyle.FixedSingle;
            panelRight.Controls.Add(lblMontoCambio);
            panelRight.Controls.Add(lblMontoEntregado);
            panelRight.Controls.Add(lblMontoTotal);
            panelRight.Controls.Add(lblCambio);
            panelRight.Controls.Add(lblEntregado);
            panelRight.Controls.Add(lblTotal);
            panelRight.Controls.Add(lblMontoPendiente);
            panelRight.Controls.Add(lblPendiente);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(702, 116);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(497, 570);
            panelRight.TabIndex = 2;
            // 
            // lblMontoCambio
            // 
            lblMontoCambio.AutoSize = true;
            lblMontoCambio.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoCambio.ForeColor = SystemColors.ActiveCaptionText;
            lblMontoCambio.Location = new Point(161, 117);
            lblMontoCambio.Name = "lblMontoCambio";
            lblMontoCambio.Size = new Size(77, 32);
            lblMontoCambio.TabIndex = 8;
            lblMontoCambio.Text = "$0.00";
            lblMontoCambio.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMontoEntregado
            // 
            lblMontoEntregado.AutoSize = true;
            lblMontoEntregado.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoEntregado.ForeColor = SystemColors.ActiveCaptionText;
            lblMontoEntregado.Location = new Point(161, 86);
            lblMontoEntregado.Name = "lblMontoEntregado";
            lblMontoEntregado.Size = new Size(77, 32);
            lblMontoEntregado.TabIndex = 7;
            lblMontoEntregado.Text = "$0.00";
            lblMontoEntregado.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoTotal.ForeColor = SystemColors.ActiveCaptionText;
            lblMontoTotal.Location = new Point(161, 55);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(77, 32);
            lblMontoTotal.TabIndex = 6;
            lblMontoTotal.Text = "$0.00";
            lblMontoTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblCambio.ForeColor = SystemColors.ActiveCaptionText;
            lblCambio.Location = new Point(5, 118);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(108, 32);
            lblCambio.TabIndex = 5;
            lblCambio.Text = "Cambio:";
            // 
            // lblEntregado
            // 
            lblEntregado.AutoSize = true;
            lblEntregado.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblEntregado.ForeColor = SystemColors.ActiveCaptionText;
            lblEntregado.Location = new Point(5, 85);
            lblEntregado.Name = "lblEntregado";
            lblEntregado.Size = new Size(139, 32);
            lblEntregado.TabIndex = 4;
            lblEntregado.Text = "Entregado:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = SystemColors.ActiveCaptionText;
            lblTotal.Location = new Point(5, 55);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 32);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total:";
            // 
            // lblMontoPendiente
            // 
            lblMontoPendiente.AutoSize = true;
            lblMontoPendiente.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoPendiente.ForeColor = SystemColors.ActiveCaptionText;
            lblMontoPendiente.Location = new Point(161, 15);
            lblMontoPendiente.Name = "lblMontoPendiente";
            lblMontoPendiente.Size = new Size(93, 40);
            lblMontoPendiente.TabIndex = 2;
            lblMontoPendiente.Text = "$0.00";
            lblMontoPendiente.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPendiente
            // 
            lblPendiente.AutoSize = true;
            lblPendiente.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPendiente.ForeColor = SystemColors.ActiveCaptionText;
            lblPendiente.Location = new Point(3, 15);
            lblPendiente.Name = "lblPendiente";
            lblPendiente.Size = new Size(163, 40);
            lblPendiente.TabIndex = 1;
            lblPendiente.Text = "Pendiente:";
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(panel2);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 116);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(335, 570);
            panelLeft.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblMensaje);
            panel2.Controls.Add(listViewFormaPago);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button0);
            panel2.Controls.Add(buttonPunto);
            panel2.Controls.Add(txtEntregado);
            panel2.Controls.Add(btnGuion);
            panel2.Controls.Add(btnEnter);
            panel2.Controls.Add(btnClear);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(382, 570);
            panel2.TabIndex = 0;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Location = new Point(8, 279);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(321, 42);
            lblMensaje.TabIndex = 43;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listViewFormaPago
            // 
            listViewFormaPago.Alignment = ListViewAlignment.Left;
            listViewFormaPago.Columns.AddRange(new ColumnHeader[] { TicketGlobalId, PosId, UserId, Date, PaymentMethodId, Amount, PaidAmount, ChangeAmount, TipAmount, KeepOpen, ExtraInformation, FormaDePago, Entregado, Eliminar });
            listViewFormaPago.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            listViewFormaPago.FullRowSelect = true;
            listViewFormaPago.GridLines = true;
            listViewFormaPago.Location = new Point(8, 6);
            listViewFormaPago.MultiSelect = false;
            listViewFormaPago.Name = "listViewFormaPago";
            listViewFormaPago.Size = new Size(317, 270);
            listViewFormaPago.TabIndex = 42;
            listViewFormaPago.UseCompatibleStateImageBehavior = false;
            listViewFormaPago.View = View.Details;
            listViewFormaPago.MouseClick += listViewFormaPago_MouseClick;
            // 
            // TicketGlobalId
            // 
            TicketGlobalId.Text = "Ticket Global Id";
            TicketGlobalId.Width = 0;
            // 
            // PosId
            // 
            PosId.Text = "Pos Id";
            PosId.TextAlign = HorizontalAlignment.Right;
            PosId.Width = 0;
            // 
            // UserId
            // 
            UserId.Text = "User Id";
            UserId.Width = 0;
            // 
            // Date
            // 
            Date.Text = "Date";
            Date.Width = 0;
            // 
            // PaymentMethodId
            // 
            PaymentMethodId.Text = "Payment MethodId";
            PaymentMethodId.Width = 0;
            // 
            // Amount
            // 
            Amount.Text = "Amount";
            Amount.Width = 0;
            // 
            // PaidAmount
            // 
            PaidAmount.Text = "PaidAmount";
            PaidAmount.Width = 0;
            // 
            // ChangeAmount
            // 
            ChangeAmount.Text = "Devuelta";
            ChangeAmount.Width = 0;
            // 
            // TipAmount
            // 
            TipAmount.Tag = "";
            TipAmount.Text = "Propina";
            TipAmount.Width = 0;
            // 
            // KeepOpen
            // 
            KeepOpen.Text = "Keep Open";
            KeepOpen.Width = 0;
            // 
            // ExtraInformation
            // 
            ExtraInformation.Text = "Extra Information";
            ExtraInformation.Width = 0;
            // 
            // FormaDePago
            // 
            FormaDePago.Text = "Forma de Pago";
            FormaDePago.Width = 110;
            // 
            // Entregado
            // 
            Entregado.Text = "Entregado";
            Entregado.Width = 140;
            // 
            // Eliminar
            // 
            Eliminar.Text = "Eliminar";
            Eliminar.Width = 100;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(165, 370);
            button9.Name = "button9";
            button9.Size = new Size(78, 67);
            button9.TabIndex = 41;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(84, 370);
            button8.Name = "button8";
            button8.Size = new Size(78, 67);
            button8.TabIndex = 40;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(0, 370);
            button7.Name = "button7";
            button7.Size = new Size(78, 67);
            button7.TabIndex = 39;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(165, 443);
            button6.Name = "button6";
            button6.Size = new Size(78, 67);
            button6.TabIndex = 38;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(84, 443);
            button5.Name = "button5";
            button5.Size = new Size(78, 67);
            button5.TabIndex = 37;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(3, 443);
            button4.Name = "button4";
            button4.Size = new Size(78, 67);
            button4.TabIndex = 36;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(165, 516);
            button3.Name = "button3";
            button3.Size = new Size(78, 67);
            button3.TabIndex = 35;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(84, 516);
            button2.Name = "button2";
            button2.Size = new Size(78, 67);
            button2.TabIndex = 34;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(3, 516);
            button1.Name = "button1";
            button1.Size = new Size(78, 67);
            button1.TabIndex = 33;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button0
            // 
            button0.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button0.Location = new Point(5, 585);
            button0.Name = "button0";
            button0.Size = new Size(78, 67);
            button0.TabIndex = 32;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            // 
            // buttonPunto
            // 
            buttonPunto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPunto.Location = new Point(84, 585);
            buttonPunto.Name = "buttonPunto";
            buttonPunto.Size = new Size(78, 67);
            buttonPunto.TabIndex = 31;
            buttonPunto.Text = ".";
            buttonPunto.UseVisualStyleBackColor = true;
            // 
            // txtEntregado
            // 
            txtEntregado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEntregado.Location = new Point(3, 324);
            txtEntregado.Name = "txtEntregado";
            txtEntregado.PlaceholderText = "Entregado";
            txtEntregado.Size = new Size(322, 29);
            txtEntregado.TabIndex = 30;
            txtEntregado.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGuion
            // 
            btnGuion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuion.Location = new Point(249, 370);
            btnGuion.Name = "btnGuion";
            btnGuion.Size = new Size(78, 140);
            btnGuion.TabIndex = 29;
            btnGuion.Text = "-";
            btnGuion.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            btnEnter.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEnter.Location = new Point(249, 516);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(78, 136);
            btnEnter.TabIndex = 28;
            btnEnter.Text = "ENT";
            btnEnter.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(165, 585);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(78, 67);
            btnClear.TabIndex = 18;
            btnClear.Text = "CLR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // flowLayoutPanelPagos
            // 
            flowLayoutPanelPagos.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelPagos.Dock = DockStyle.Fill;
            flowLayoutPanelPagos.Location = new Point(335, 116);
            flowLayoutPanelPagos.Name = "flowLayoutPanelPagos";
            flowLayoutPanelPagos.Size = new Size(367, 570);
            flowLayoutPanelPagos.TabIndex = 4;
            // 
            // UCFormaPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanelPagos);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            Name = "UCFormaPago";
            Size = new Size(1199, 793);
            Load += UCFormaPago_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelLeft.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        private void InitializeNumericButton()
        {
            Buttons[0] = buttonPunto;
            Buttons[1] = button0;
            Buttons[2] = button1;
            Buttons[3] = button2;
            Buttons[4] = button3;
            Buttons[5] = button4;
            Buttons[6] = button5;
            Buttons[7] = button6;
            Buttons[8] = button7;
            Buttons[9] = button8;
            Buttons[10] = button9;
            Buttons[11] = btnGuion;

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
            Buttons[10].Click += new EventHandler(Buttons_Click);
            Buttons[11].Click += new EventHandler(Buttons_Click);
        }
        #endregion
        private Button[] Buttons = new Button[12];
        private Panel panel1;
        private Button btnCobrar;
        private Button btnVolver;
        private Panel panelTop;
        private Label lblCobrarTicket;
        private Panel panelRight;
        private Panel panelLeft;
        private FlowLayoutPanel flowLayoutPanelPagos;
        private Panel panel2;
        private Button btnGuion;
        private Button btnEnter;
        private Button btnClear;
        private TextBox txtEntregado;
        private Label lblPendiente;
        private Label lblMontoPendiente;
        private Label lblMontoTotal;
        private Label lblCambio;
        private Label lblEntregado;
        private Label lblTotal;
        private Label lblMontoEntregado;
        private Label lblMontoCambio;
        private Label lblCliente;
        private Button buttonPunto;
        private Button button0;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private ListView listViewFormaPago;
        private ColumnHeader TicketGlobalId;
        private ColumnHeader PosId;
        private ColumnHeader UserId;
        private ColumnHeader Date;
        private ColumnHeader PaymentMethodId;
        private ColumnHeader Amount;
        private ColumnHeader PaidAmount;
        private ColumnHeader ChangeAmount;
        private ColumnHeader TipAmount;
        private ColumnHeader KeepOpen;
        private ColumnHeader ExtraInformation;
        private ColumnHeader FormaDePago;
        private Label lblMensaje;
        private Label lblCodigoCliente;
        private ColumnHeader Entregado;
        private Button btnComprobantes;
        private Label lblVentaCambio;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label lblRazonSocial;
        private Label lblRNC;
        private Label lblDescripcionComprobante;
        private Label lblRNCTipo;
        private ColumnHeader Eliminar;
        private Label lblVentaFactura;
        private Label lblVentaImporte;
        private Label lblVentaEntregada;
        private Button btnTicketAbierto;
    }
}
