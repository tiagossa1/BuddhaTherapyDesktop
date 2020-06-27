namespace TMS.UI.InvoiceForms
{
    partial class CreateOrUpdateInvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrUpdateInvoiceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateOrEdit = new Guna.UI2.WinForms.Guna2Button();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbAppointments = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Consulta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Preço";
            // 
            // btnCreateOrEdit
            // 
            this.btnCreateOrEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateOrEdit.BorderThickness = 1;
            this.btnCreateOrEdit.CheckedState.Parent = this.btnCreateOrEdit;
            this.btnCreateOrEdit.CustomImages.Parent = this.btnCreateOrEdit;
            this.btnCreateOrEdit.FillColor = System.Drawing.Color.White;
            this.btnCreateOrEdit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrEdit.ForeColor = System.Drawing.Color.Black;
            this.btnCreateOrEdit.HoverState.Parent = this.btnCreateOrEdit;
            this.btnCreateOrEdit.Location = new System.Drawing.Point(238, 99);
            this.btnCreateOrEdit.Name = "btnCreateOrEdit";
            this.btnCreateOrEdit.ShadowDecoration.Parent = this.btnCreateOrEdit;
            this.btnCreateOrEdit.Size = new System.Drawing.Size(85, 26);
            this.btnCreateOrEdit.TabIndex = 49;
            this.btnCreateOrEdit.Text = "CRIAR";
            this.btnCreateOrEdit.Click += new System.EventHandler(this.BtnCreateOrEdit_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Transparent;
            this.txtPrice.BorderColor = System.Drawing.Color.Black;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.DisabledState.Parent = this.txtPrice;
            this.txtPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrice.FocusedState.Parent = this.txtPrice;
            this.txtPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrice.HoverState.Parent = this.txtPrice;
            this.txtPrice.Location = new System.Drawing.Point(112, 54);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.PlaceholderText = "";
            this.txtPrice.SelectedText = "";
            this.txtPrice.ShadowDecoration.Parent = this.txtPrice;
            this.txtPrice.Size = new System.Drawing.Size(211, 22);
            this.txtPrice.TabIndex = 50;
            // 
            // cmbAppointments
            // 
            this.cmbAppointments.BackColor = System.Drawing.Color.Transparent;
            this.cmbAppointments.BorderColor = System.Drawing.Color.Black;
            this.cmbAppointments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAppointments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointments.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAppointments.FocusedState.Parent = this.cmbAppointments;
            this.cmbAppointments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAppointments.FormattingEnabled = true;
            this.cmbAppointments.HoverState.Parent = this.cmbAppointments;
            this.cmbAppointments.ItemHeight = 30;
            this.cmbAppointments.ItemsAppearance.Parent = this.cmbAppointments;
            this.cmbAppointments.Location = new System.Drawing.Point(112, 11);
            this.cmbAppointments.Name = "cmbAppointments";
            this.cmbAppointments.ShadowDecoration.Parent = this.cmbAppointments;
            this.cmbAppointments.Size = new System.Drawing.Size(211, 36);
            this.cmbAppointments.TabIndex = 51;
            // 
            // CreateOrUpdateInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 137);
            this.Controls.Add(this.cmbAppointments);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnCreateOrEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateOrUpdateInvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Recibo";
            this.Load += new System.EventHandler(this.CreateOrUpdateInvoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnCreateOrEdit;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAppointments;
    }
}