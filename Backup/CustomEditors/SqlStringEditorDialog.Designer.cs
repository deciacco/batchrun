namespace CustomEditors
{
	partial class SqlStringEditorDialog
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
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.textBoxPass = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxAuthType = new System.Windows.Forms.ComboBox();
			this.comboBoxDb = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.comboBoxServers = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// textBoxUser
			// 
			this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxUser.Location = new System.Drawing.Point(118, 65);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(217, 20);
			this.textBoxUser.TabIndex = 2;
			this.textBoxUser.Leave += new System.EventHandler(this.textBoxUser_Leave);
			// 
			// textBoxPass
			// 
			this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPass.Location = new System.Drawing.Point(118, 91);
			this.textBoxPass.Name = "textBoxPass";
			this.textBoxPass.PasswordChar = '*';
			this.textBoxPass.Size = new System.Drawing.Size(217, 20);
			this.textBoxPass.TabIndex = 3;
			this.textBoxPass.Leave += new System.EventHandler(this.textBoxPass_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Server Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Login";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Password";
			// 
			// comboBoxAuthType
			// 
			this.comboBoxAuthType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxAuthType.FormattingEnabled = true;
			this.comboBoxAuthType.Location = new System.Drawing.Point(118, 38);
			this.comboBoxAuthType.Name = "comboBoxAuthType";
			this.comboBoxAuthType.Size = new System.Drawing.Size(217, 21);
			this.comboBoxAuthType.TabIndex = 1;
			this.comboBoxAuthType.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAuthType_SelectionChangeCommitted);
			this.comboBoxAuthType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthType_SelectedIndexChanged);
			// 
			// comboBoxDb
			// 
			this.comboBoxDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDb.FormattingEnabled = true;
			this.comboBoxDb.Location = new System.Drawing.Point(118, 117);
			this.comboBoxDb.Name = "comboBoxDb";
			this.comboBoxDb.Size = new System.Drawing.Size(217, 21);
			this.comboBoxDb.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Database";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(12, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Authentication";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCancel.Location = new System.Drawing.Point(260, 144);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonOk.Location = new System.Drawing.Point(179, 144);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 5;
			this.buttonOk.Text = "&OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// comboBoxServers
			// 
			this.comboBoxServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxServers.FormattingEnabled = true;
			this.comboBoxServers.Location = new System.Drawing.Point(118, 12);
			this.comboBoxServers.Name = "comboBoxServers";
			this.comboBoxServers.Size = new System.Drawing.Size(217, 21);
			this.comboBoxServers.TabIndex = 0;
			this.comboBoxServers.SelectionChangeCommitted += new System.EventHandler(this.comboBoxServers_SelectionChangeCommitted);
			// 
			// SqlStringEditorDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(347, 179);
			this.ControlBox = false;
			this.Controls.Add(this.comboBoxServers);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxDb);
			this.Controls.Add(this.comboBoxAuthType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPass);
			this.Controls.Add(this.textBoxUser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SqlStringEditorDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sql String Editor";
			this.Load += new System.EventHandler(this.SqlStringEditorDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.TextBox textBoxPass;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxAuthType;
		private System.Windows.Forms.ComboBox comboBoxDb;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.ComboBox comboBoxServers;
	}
}