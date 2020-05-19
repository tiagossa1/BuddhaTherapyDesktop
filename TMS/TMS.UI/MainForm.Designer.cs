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
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAppointments
            // 
            this.btnAppointments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAppointments.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppointments.Image = ((System.Drawing.Image)(resources.GetObject("btnAppointments.Image")));
            this.btnAppointments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointments.Location = new System.Drawing.Point(164, 9);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(146, 54);
            this.btnAppointments.TabIndex = 3;
            this.btnAppointments.Text = "CONSULTAS";
            this.btnAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.BtnAppointments_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClients.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(12, 9);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(146, 54);
            this.btnClients.TabIndex = 2;
            this.btnClients.Text = "CLIENTES";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInvoices.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoices.Image = ((System.Drawing.Image)(resources.GetObject("btnInvoices.Image")));
            this.btnInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoices.Location = new System.Drawing.Point(316, 9);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(146, 54);
            this.btnInvoices.TabIndex = 1;
            this.btnInvoices.Text = "RECIBOS";
            this.btnInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInvoices.UseVisualStyleBackColor = true;
            this.btnInvoices.Click += new System.EventHandler(this.BtnInvoices_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 71);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.btnInvoices);
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
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnAppointments;
    }
}

