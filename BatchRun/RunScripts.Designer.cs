namespace BatchRun
{
	partial class RunScripts
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunScripts));
			this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
			this.listviewProgress = new System.Windows.Forms.ListView();
			this.columnHeader = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// imageListStatus
			// 
			this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
			this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListStatus.Images.SetKeyName(0, "SuccessComplete.bmp");
			this.imageListStatus.Images.SetKeyName(1, "Critical.bmp");
			// 
			// listviewProgress
			// 
			this.listviewProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
			this.listviewProgress.Location = new System.Drawing.Point(12, 12);
			this.listviewProgress.Name = "listviewProgress";
			this.listviewProgress.Size = new System.Drawing.Size(386, 281);
			this.listviewProgress.TabIndex = 1;
			this.listviewProgress.UseCompatibleStateImageBehavior = false;
			this.listviewProgress.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader
			// 
			this.columnHeader.Text = "Script Execution Status";
			this.columnHeader.Width = -2;
			// 
			// RunScripts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 305);
			this.Controls.Add(this.listviewProgress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RunScripts";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RunScripts";
			this.Shown += new System.EventHandler(this.RunScripts_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList imageListStatus;
		private System.Windows.Forms.ListView listviewProgress;
		private System.Windows.Forms.ColumnHeader columnHeader;

	}
}