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
            this.cmbAppointments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateOrEdit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbAppointments
            // 
            this.cmbAppointments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointments.FormattingEnabled = true;
            this.cmbAppointments.Location = new System.Drawing.Point(112, 12);
            this.cmbAppointments.Name = "cmbAppointments";
            this.cmbAppointments.Size = new System.Drawing.Size(211, 21);
            this.cmbAppointments.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Consulta";
            // 
            // btnCreateOrEdit
            // 
            this.btnCreateOrEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrEdit.Location = new System.Drawing.Point(249, 68);
            this.btnCreateOrEdit.Name = "btnCreateOrEdit";
            this.btnCreateOrEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCreateOrEdit.TabIndex = 34;
            this.btnCreateOrEdit.Text = "Criar";
            this.btnCreateOrEdit.UseVisualStyleBackColor = true;
            this.btnCreateOrEdit.Click += new System.EventHandler(this.BtnCreateOrEdit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Preço";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(112, 39);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(211, 20);
            this.txtPrice.TabIndex = 48;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrice_KeyPress);
            // 
            // CreateOrUpdateInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 103);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAppointments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateOrEdit);
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
        private System.Windows.Forms.ComboBox cmbAppointments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateOrEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
    }
}