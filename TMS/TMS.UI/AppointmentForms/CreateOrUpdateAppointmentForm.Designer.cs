namespace TMS.UI
{
    partial class CreateOrUpdateAppointmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrUpdateAppointmentForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClient = new Guna.UI2.WinForms.Guna2ComboBox();
            this.datePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbAppointmentType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCreateOrEdit = new Guna.UI2.WinForms.Guna2Button();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tipo de Consulta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cliente";
            // 
            // cmbClient
            // 
            this.cmbClient.BackColor = System.Drawing.Color.Transparent;
            this.cmbClient.BorderColor = System.Drawing.Color.Black;
            this.cmbClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FocusedColor = System.Drawing.Color.Empty;
            this.cmbClient.FocusedState.Parent = this.cmbClient;
            this.cmbClient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.HoverState.Parent = this.cmbClient;
            this.cmbClient.ItemHeight = 30;
            this.cmbClient.ItemsAppearance.Parent = this.cmbClient;
            this.cmbClient.Location = new System.Drawing.Point(115, 9);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.ShadowDecoration.Parent = this.cmbClient;
            this.cmbClient.Size = new System.Drawing.Size(252, 36);
            this.cmbClient.TabIndex = 34;
            this.cmbClient.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.CmbClient_Format);
            // 
            // datePicker
            // 
            this.datePicker.BackColor = System.Drawing.Color.Transparent;
            this.datePicker.BorderThickness = 1;
            this.datePicker.CheckedState.Parent = this.datePicker;
            this.datePicker.FillColor = System.Drawing.Color.White;
            this.datePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.ForeColor = System.Drawing.Color.Black;
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.HoverState.Parent = this.datePicker;
            this.datePicker.Location = new System.Drawing.Point(115, 52);
            this.datePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datePicker.MinDate = new System.DateTime(2020, 5, 26, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.ShadowDecoration.Parent = this.datePicker;
            this.datePicker.Size = new System.Drawing.Size(150, 21);
            this.datePicker.TabIndex = 35;
            this.datePicker.Value = new System.DateTime(2020, 5, 26, 18, 40, 18, 825);
            // 
            // cmbAppointmentType
            // 
            this.cmbAppointmentType.BackColor = System.Drawing.Color.Transparent;
            this.cmbAppointmentType.BorderColor = System.Drawing.Color.Black;
            this.cmbAppointmentType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointmentType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAppointmentType.FocusedState.Parent = this.cmbAppointmentType;
            this.cmbAppointmentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAppointmentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAppointmentType.FormattingEnabled = true;
            this.cmbAppointmentType.HoverState.Parent = this.cmbAppointmentType;
            this.cmbAppointmentType.ItemHeight = 30;
            this.cmbAppointmentType.ItemsAppearance.Parent = this.cmbAppointmentType;
            this.cmbAppointmentType.Location = new System.Drawing.Point(115, 79);
            this.cmbAppointmentType.Name = "cmbAppointmentType";
            this.cmbAppointmentType.ShadowDecoration.Parent = this.cmbAppointmentType;
            this.cmbAppointmentType.Size = new System.Drawing.Size(252, 36);
            this.cmbAppointmentType.TabIndex = 37;
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
            this.btnCreateOrEdit.Location = new System.Drawing.Point(282, 279);
            this.btnCreateOrEdit.Name = "btnCreateOrEdit";
            this.btnCreateOrEdit.ShadowDecoration.Parent = this.btnCreateOrEdit;
            this.btnCreateOrEdit.Size = new System.Drawing.Size(85, 26);
            this.btnCreateOrEdit.TabIndex = 40;
            this.btnCreateOrEdit.Text = "CRIAR";
            this.btnCreateOrEdit.Click += new System.EventHandler(this.BtnCreateOrEdit_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderColor = System.Drawing.Color.Black;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.Parent = this.txtDescription;
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.FocusedState.Parent = this.txtDescription;
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.HoverState.Parent = this.txtDescription;
            this.txtDescription.Location = new System.Drawing.Point(115, 121);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.SelectedText = "";
            this.txtDescription.ShadowDecoration.Parent = this.txtDescription;
            this.txtDescription.Size = new System.Drawing.Size(252, 145);
            this.txtDescription.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Descrição";
            // 
            // timePicker
            // 
            this.timePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(272, 53);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(96, 20);
            this.timePicker.TabIndex = 43;
            // 
            // CreateOrUpdateAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 317);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnCreateOrEdit);
            this.Controls.Add(this.cmbAppointmentType);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateOrUpdateAppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Consulta";
            this.Load += new System.EventHandler(this.CreateOrUpdateAppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbClient;
        private Guna.UI2.WinForms.Guna2DateTimePicker datePicker;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAppointmentType;
        private Guna.UI2.WinForms.Guna2Button btnCreateOrEdit;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker timePicker;
    }
}