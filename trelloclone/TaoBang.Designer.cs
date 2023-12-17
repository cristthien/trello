namespace trelloclone
{
    partial class TaoBang
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
            this.textBoxPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.createButton = new Guna.UI2.WinForms.Guna2Button();
            this.txtNameOfTable = new Guna.UI2.WinForms.Guna2TextBox();
            this.noteLineLabel = new System.Windows.Forms.Label();
            this.headLabel = new System.Windows.Forms.Label();
            this.textBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPanel
            // 
            this.textBoxPanel.BackgroundImage = global::trelloclone.Properties.Resources.myTablePanel;
            this.textBoxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxPanel.Controls.Add(this.titleLabel);
            this.textBoxPanel.Controls.Add(this.exitButton);
            this.textBoxPanel.Controls.Add(this.createButton);
            this.textBoxPanel.Controls.Add(this.txtNameOfTable);
            this.textBoxPanel.Controls.Add(this.noteLineLabel);
            this.textBoxPanel.Controls.Add(this.headLabel);
            this.textBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.textBoxPanel.Name = "textBoxPanel";
            this.textBoxPanel.Size = new System.Drawing.Size(300, 300);
            this.textBoxPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(25, 59);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(87, 16);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Tiêu đề bảng";
            // 
            // exitButton
            // 
            this.exitButton.BorderRadius = 5;
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.FillColor = System.Drawing.Color.Transparent;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::trelloclone.Properties.Resources.tab_close;
            this.exitButton.Location = new System.Drawing.Point(247, 25);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 1;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // createButton
            // 
            this.createButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.createButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.createButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.createButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.createButton.ForeColor = System.Drawing.Color.White;
            this.createButton.Location = new System.Drawing.Point(60, 202);
            this.createButton.Name = "createButton";
            this.createButton.PressedColor = System.Drawing.Color.MidnightBlue;
            this.createButton.Size = new System.Drawing.Size(180, 45);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Tạo Bảng Mới";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // txtNameOfTable
            // 
            this.txtNameOfTable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameOfTable.DefaultText = "";
            this.txtNameOfTable.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameOfTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameOfTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameOfTable.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameOfTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameOfTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameOfTable.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameOfTable.Location = new System.Drawing.Point(22, 79);
            this.txtNameOfTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameOfTable.Name = "txtNameOfTable";
            this.txtNameOfTable.PasswordChar = '\0';
            this.txtNameOfTable.PlaceholderText = "";
            this.txtNameOfTable.SelectedText = "";
            this.txtNameOfTable.Size = new System.Drawing.Size(250, 50);
            this.txtNameOfTable.TabIndex = 1;
            // 
            // noteLineLabel
            // 
            this.noteLineLabel.AutoSize = true;
            this.noteLineLabel.Location = new System.Drawing.Point(25, 133);
            this.noteLineLabel.Name = "noteLineLabel";
            this.noteLineLabel.Size = new System.Drawing.Size(156, 16);
            this.noteLineLabel.TabIndex = 2;
            this.noteLineLabel.Text = "Tiêu đề bảng là bắt buộc";
            // 
            // headLabel
            // 
            this.headLabel.AutoSize = true;
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.headLabel.Location = new System.Drawing.Point(100, 25);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(106, 25);
            this.headLabel.TabIndex = 1;
            this.headLabel.Text = "Tạo Bảng";
            // 
            // TaoBang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.textBoxPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaoBang";
            this.Text = "TaoBang";
            this.textBoxPanel.ResumeLayout(false);
            this.textBoxPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel textBoxPanel;
        private Guna.UI2.WinForms.Guna2TextBox txtNameOfTable;
        private System.Windows.Forms.Label noteLineLabel;
        private System.Windows.Forms.Label headLabel;
        private Guna.UI2.WinForms.Guna2Button createButton;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private System.Windows.Forms.Label titleLabel;
    }
}