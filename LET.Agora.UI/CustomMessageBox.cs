using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LET.Agora.UI
{
    public partial class CustomMessageBox : Form
    {
        private Label lblMessage;
        private Button btnOk;
        private PictureBox iconBox;
        public enum MessageType
        {
            Info,
            Warning,
            Error
        }
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public CustomMessageBox(string message, string title, MessageType type)
        {
            // Form Settings
            this.Text = title;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 180); // Increased width
            this.BackColor = Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Message Label
            lblMessage = new Label()
            {
                Text = message,
                AutoSize = false,
                Location = new Point(80, 20),
                Size = new Size(300, 60),
                Font = new Font("Arial", 10),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // OK Button
            btnOk = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(150, 100),
                Size = new Size(100, 30),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (sender, e) => this.Close();

            // Icon PictureBox
            iconBox = new PictureBox()
            {
                Size = new Size(48, 48),
                Location = new Point(20, 30),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Set Icon Based on MessageType
            switch (type)
            {
                case MessageType.Warning:
                    iconBox.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageType.Error:
                    iconBox.Image = SystemIcons.Error.ToBitmap();
                    break;
                default:
                    iconBox.Image = SystemIcons.Information.ToBitmap();
                    break;
            }

            // Add Controls
            this.Controls.Add(lblMessage);
            this.Controls.Add(btnOk);
            this.Controls.Add(iconBox);
        }

        public static void Show(string message, string title = "Message", MessageType type = MessageType.Info)
        {
            using (CustomMessageBox box = new CustomMessageBox(message, title, type))
            {
                box.ShowDialog();
            }
       }
    }
}
