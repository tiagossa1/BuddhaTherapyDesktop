namespace TMS.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.appointmentsNotificationBadge = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnInvoices = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAppointments = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnClients = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnImportFromSqlite = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // appointmentsNotificationBadge
            // 
            this.appointmentsNotificationBadge.CheckedState.Parent = this.appointmentsNotificationBadge;
            this.appointmentsNotificationBadge.CustomImages.Parent = this.appointmentsNotificationBadge;
            this.appointmentsNotificationBadge.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(225)))), ((int)(((byte)(244)))));
            this.appointmentsNotificationBadge.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsNotificationBadge.ForeColor = System.Drawing.Color.Red;
            this.appointmentsNotificationBadge.HoverState.Parent = this.appointmentsNotificationBadge;
            this.appointmentsNotificationBadge.Location = new System.Drawing.Point(660, 15);
            this.appointmentsNotificationBadge.Margin = new System.Windows.Forms.Padding(4);
            this.appointmentsNotificationBadge.Name = "appointmentsNotificationBadge";
            this.appointmentsNotificationBadge.ShadowDecoration.Depth = 20;
            this.appointmentsNotificationBadge.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.appointmentsNotificationBadge.ShadowDecoration.Parent = this.appointmentsNotificationBadge;
            this.appointmentsNotificationBadge.Size = new System.Drawing.Size(31, 30);
            this.appointmentsNotificationBadge.TabIndex = 7;
            this.appointmentsNotificationBadge.Text = "0";
            this.appointmentsNotificationBadge.Click += new System.EventHandler(this.AppointmentsNotificationBadge_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackgroundImage = global::TMS.UI.Properties.Resources.bill;
            this.btnInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInvoices.CheckedState.Parent = this.btnInvoices;
            this.btnInvoices.HoverState.Parent = this.btnInvoices;
            this.btnInvoices.Location = new System.Drawing.Point(495, 79);
            this.btnInvoices.Margin = new System.Windows.Forms.Padding(4);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.PressedState.Parent = this.btnInvoices;
            this.btnInvoices.Size = new System.Drawing.Size(196, 165);
            this.btnInvoices.TabIndex = 6;
            this.btnInvoices.Click += new System.EventHandler(this.BtnInvoices_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAppointments.BackgroundImage")));
            this.btnAppointments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAppointments.CheckedState.Parent = this.btnAppointments;
            this.btnAppointments.HoverState.Parent = this.btnAppointments;
            this.btnAppointments.Location = new System.Drawing.Point(267, 79);
            this.btnAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.PressedState.Parent = this.btnAppointments;
            this.btnAppointments.Size = new System.Drawing.Size(166, 165);
            this.btnAppointments.TabIndex = 5;
            this.btnAppointments.Click += new System.EventHandler(this.BtnAppointments_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.Transparent;
            this.btnClients.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClients.BackgroundImage")));
            this.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClients.CheckedState.Parent = this.btnClients;
            this.btnClients.HoverState.Parent = this.btnClients;
            this.btnClients.Location = new System.Drawing.Point(15, 79);
            this.btnClients.Margin = new System.Windows.Forms.Padding(4);
            this.btnClients.Name = "btnClients";
            this.btnClients.PressedState.Parent = this.btnClients;
            this.btnClients.Size = new System.Drawing.Size(177, 165);
            this.btnClients.TabIndex = 4;
            this.btnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // btnImportFromSqlite
            // 
            this.btnImportFromSqlite.CheckedState.Parent = this.btnImportFromSqlite;
            this.btnImportFromSqlite.CustomImages.Parent = this.btnImportFromSqlite;
            this.btnImportFromSqlite.FillColor = System.Drawing.Color.Red;
            this.btnImportFromSqlite.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFromSqlite.ForeColor = System.Drawing.Color.White;
            this.btnImportFromSqlite.HoverState.Parent = this.btnImportFromSqlite;
            this.btnImportFromSqlite.Location = new System.Drawing.Point(15, 15);
            this.btnImportFromSqlite.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportFromSqlite.Name = "btnImportFromSqlite";
            this.btnImportFromSqlite.ShadowDecoration.BorderRadius = 5;
            this.btnImportFromSqlite.ShadowDecoration.Parent = this.btnImportFromSqlite;
            this.btnImportFromSqlite.Size = new System.Drawing.Size(115, 39);
            this.btnImportFromSqlite.TabIndex = 8;
            this.btnImportFromSqlite.Text = "Importar";
            this.btnImportFromSqlite.Click += new System.EventHandler(this.BtnAppointments_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Sqlite files (*.sqlite, *.db)|*.sqlite;*.db|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 258);
            this.Controls.Add(this.btnImportFromSqlite);
            this.Controls.Add(this.appointmentsNotificationBadge);
            this.Controls.Add(this.btnInvoices);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMS - Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton btnClients;
        private Guna.UI2.WinForms.Guna2ImageButton btnAppointments;
        private Guna.UI2.WinForms.Guna2ImageButton btnInvoices;
        private Guna.UI2.WinForms.Guna2CircleButton appointmentsNotificationBadge;
        private Guna.UI2.WinForms.Guna2Button btnImportFromSqlite;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

