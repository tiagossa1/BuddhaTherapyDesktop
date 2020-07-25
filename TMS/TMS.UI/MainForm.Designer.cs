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
            this.btnInvoices = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAppointments = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnClients = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackgroundImage = global::TMS.UI.Properties.Resources.bill;
            this.btnInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInvoices.CheckedState.Parent = this.btnInvoices;
            this.btnInvoices.HoverState.Parent = this.btnInvoices;
            this.btnInvoices.Location = new System.Drawing.Point(315, 12);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.PressedState.Parent = this.btnInvoices;
            this.btnInvoices.Size = new System.Drawing.Size(146, 53);
            this.btnInvoices.TabIndex = 6;
            this.btnInvoices.Click += new System.EventHandler(this.BtnInvoices_Click);
            this.btnInvoices.MouseEnter += new System.EventHandler(this.BtnInvoices_MouseEnter);
            this.btnInvoices.MouseLeave += new System.EventHandler(this.BtnInvoices_MouseLeave);
            // 
            // btnAppointments
            // 
            this.btnAppointments.BackgroundImage = global::TMS.UI.Properties.Resources.meeting;
            this.btnAppointments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAppointments.CheckedState.Parent = this.btnAppointments;
            this.btnAppointments.HoverState.Parent = this.btnAppointments;
            this.btnAppointments.Location = new System.Drawing.Point(163, 12);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.PressedState.Parent = this.btnAppointments;
            this.btnAppointments.Size = new System.Drawing.Size(146, 53);
            this.btnAppointments.TabIndex = 5;
            this.btnAppointments.Click += new System.EventHandler(this.BtnAppointments_Click);
            this.btnAppointments.MouseEnter += new System.EventHandler(this.BtnAppointments_MouseEnter);
            this.btnAppointments.MouseLeave += new System.EventHandler(this.BtnAppointments_MouseLeave);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.Transparent;
            this.btnClients.BackgroundImage = global::TMS.UI.Properties.Resources.customers;
            this.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClients.CheckedState.Parent = this.btnClients;
            this.btnClients.HoverState.Parent = this.btnClients;
            this.btnClients.Location = new System.Drawing.Point(11, 12);
            this.btnClients.Name = "btnClients";
            this.btnClients.PressedState.Parent = this.btnClients;
            this.btnClients.Size = new System.Drawing.Size(146, 53);
            this.btnClients.TabIndex = 4;
            this.btnClients.Click += new System.EventHandler(this.BtnClients_Click);
            this.btnClients.MouseEnter += new System.EventHandler(this.BtnClients_MouseEnter);
            this.btnClients.MouseLeave += new System.EventHandler(this.BtnClients_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 78);
            this.Controls.Add(this.btnInvoices);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMS - Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton btnClients;
        private Guna.UI2.WinForms.Guna2ImageButton btnAppointments;
        private Guna.UI2.WinForms.Guna2ImageButton btnInvoices;
    }
}

