namespace BatchRun
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.buttonRun = new System.Windows.Forms.Button();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonMoveItemUp = new System.Windows.Forms.Button();
			this.buttonMoveItemDown = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.propertyGridMain = new System.Windows.Forms.PropertyGrid();
			this.dataGridViewScripts = new System.Windows.Forms.DataGridView();
			this.scriptsListDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.scriptNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.willExecuteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.sortOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewScripts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scriptsListDataTableBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonRun
			// 
			this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonRun.Location = new System.Drawing.Point(384, 331);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(75, 23);
			this.buttonRun.TabIndex = 5;
			this.buttonRun.Text = "&Run Scripts";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
			// 
			// menuStripMain
			// 
			this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(0);
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmAbout,
            this.tsmHelp});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Padding = new System.Windows.Forms.Padding(0);
			this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStripMain.Size = new System.Drawing.Size(471, 24);
			this.menuStripMain.TabIndex = 6;
			this.menuStripMain.Text = "menuStripMain";
			// 
			// tsmFile
			// 
			this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExit});
			this.tsmFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmFile.Name = "tsmFile";
			this.tsmFile.Padding = new System.Windows.Forms.Padding(0);
			this.tsmFile.Size = new System.Drawing.Size(27, 24);
			this.tsmFile.Text = "&File";
			// 
			// tsmExit
			// 
			this.tsmExit.Name = "tsmExit";
			this.tsmExit.Size = new System.Drawing.Size(94, 22);
			this.tsmExit.Text = "E&xit";
			this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
			// 
			// tsmAbout
			// 
			this.tsmAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmAbout.Name = "tsmAbout";
			this.tsmAbout.Padding = new System.Windows.Forms.Padding(0);
			this.tsmAbout.Size = new System.Drawing.Size(39, 24);
			this.tsmAbout.Text = "&About";
			this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
			// 
			// tsmHelp
			// 
			this.tsmHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsmHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmHelp.Name = "tsmHelp";
			this.tsmHelp.Padding = new System.Windows.Forms.Padding(0);
			this.tsmHelp.Size = new System.Drawing.Size(33, 24);
			this.tsmHelp.Text = "&Help";
			// 
			// buttonMoveItemUp
			// 
			this.buttonMoveItemUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveItemUp.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonMoveItemUp.Location = new System.Drawing.Point(12, 331);
			this.buttonMoveItemUp.Name = "buttonMoveItemUp";
			this.buttonMoveItemUp.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveItemUp.TabIndex = 3;
			this.buttonMoveItemUp.Text = "Ù";
			this.buttonMoveItemUp.UseVisualStyleBackColor = true;
			this.buttonMoveItemUp.Click += new System.EventHandler(this.buttonMoveItemUp_Click);
			// 
			// buttonMoveItemDown
			// 
			this.buttonMoveItemDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveItemDown.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonMoveItemDown.Location = new System.Drawing.Point(93, 331);
			this.buttonMoveItemDown.Name = "buttonMoveItemDown";
			this.buttonMoveItemDown.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveItemDown.TabIndex = 4;
			this.buttonMoveItemDown.Text = "Ú";
			this.buttonMoveItemDown.UseVisualStyleBackColor = true;
			this.buttonMoveItemDown.Click += new System.EventHandler(this.buttonMoveItemDown_Click);
			// 
			// toolTip
			// 
			this.toolTip.AutomaticDelay = 200;
			this.toolTip.UseAnimation = false;
			this.toolTip.UseFading = false;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "script");
			// 
			// propertyGridMain
			// 
			this.propertyGridMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGridMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.propertyGridMain.Location = new System.Drawing.Point(0, 27);
			this.propertyGridMain.Name = "propertyGridMain";
			this.propertyGridMain.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this.propertyGridMain.Size = new System.Drawing.Size(471, 149);
			this.propertyGridMain.TabIndex = 13;
			this.propertyGridMain.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridMain_PropertyValueChanged);
			// 
			// dataGridViewScripts
			// 
			this.dataGridViewScripts.AllowUserToAddRows = false;
			this.dataGridViewScripts.AllowUserToDeleteRows = false;
			this.dataGridViewScripts.AllowUserToResizeColumns = false;
			this.dataGridViewScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewScripts.AutoGenerateColumns = false;
			this.dataGridViewScripts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridViewScripts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridViewScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scriptNameDataGridViewTextBoxColumn,
            this.willExecuteDataGridViewCheckBoxColumn,
            this.sortOrderDataGridViewTextBoxColumn});
			this.dataGridViewScripts.DataSource = this.scriptsListDataTableBindingSource;
			this.dataGridViewScripts.Location = new System.Drawing.Point(0, 182);
			this.dataGridViewScripts.Name = "dataGridViewScripts";
			this.dataGridViewScripts.Size = new System.Drawing.Size(471, 143);
			this.dataGridViewScripts.TabIndex = 14;
			// 
			// scriptsListDataTableBindingSource
			// 
			this.scriptsListDataTableBindingSource.DataSource = typeof(BatchRun.Data.BatchRunDS.ScriptsListDataTable);
			// 
			// scriptNameDataGridViewTextBoxColumn
			// 
			this.scriptNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.scriptNameDataGridViewTextBoxColumn.DataPropertyName = "ScriptName";
			this.scriptNameDataGridViewTextBoxColumn.HeaderText = "ScriptName";
			this.scriptNameDataGridViewTextBoxColumn.Name = "scriptNameDataGridViewTextBoxColumn";
			// 
			// willExecuteDataGridViewCheckBoxColumn
			// 
			this.willExecuteDataGridViewCheckBoxColumn.DataPropertyName = "WillExecute";
			this.willExecuteDataGridViewCheckBoxColumn.HeaderText = "WillExecute";
			this.willExecuteDataGridViewCheckBoxColumn.Name = "willExecuteDataGridViewCheckBoxColumn";
			// 
			// sortOrderDataGridViewTextBoxColumn
			// 
			this.sortOrderDataGridViewTextBoxColumn.DataPropertyName = "SortOrder";
			this.sortOrderDataGridViewTextBoxColumn.HeaderText = "SortOrder";
			this.sortOrderDataGridViewTextBoxColumn.Name = "sortOrderDataGridViewTextBoxColumn";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 366);
			this.Controls.Add(this.dataGridViewScripts);
			this.Controls.Add(this.propertyGridMain);
			this.Controls.Add(this.buttonMoveItemDown);
			this.Controls.Add(this.buttonMoveItemUp);
			this.Controls.Add(this.buttonRun);
			this.Controls.Add(this.menuStripMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripMain;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(479, 800);
			this.MinimumSize = new System.Drawing.Size(479, 400);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Batch Run v1.0 Dev";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewScripts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scriptsListDataTableBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem tsmFile;
		private System.Windows.Forms.ToolStripMenuItem tsmExit;
		private System.Windows.Forms.ToolStripMenuItem tsmAbout;
		private System.Windows.Forms.Button buttonMoveItemUp;
		private System.Windows.Forms.Button buttonMoveItemDown;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem tsmHelp;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.PropertyGrid propertyGridMain;
		private System.Windows.Forms.DataGridView dataGridViewScripts;
		private System.Windows.Forms.BindingSource scriptsListDataTableBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn scriptNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn willExecuteDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sortOrderDataGridViewTextBoxColumn;
    }
}