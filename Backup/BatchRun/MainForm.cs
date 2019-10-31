using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BatchRun.Data;

namespace BatchRun
{
    public partial class MainForm : Form
    {
		private SqlScriptLauncher _Laucher = null;
		private string _currentScriptsDirPath = null;

		public MainForm()
        {
            InitializeComponent();
			this._Laucher = new SqlScriptLauncher();
			this._currentScriptsDirPath = string.Empty;
        }

		private void populateScriptsList()
        {
			this.dataGridViewScripts.DataSource = this._Laucher.ScriptFilesData;
        }

		private void saveSettings()
		{

		}

		private void getSettings()
		{

		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			this.populateScriptsList();
		}

		private void tsmAbout_Click(object sender, EventArgs e)
		{
			AboutBox frmAbout = new AboutBox();
			frmAbout.ShowDialog(this);
		}

		private void tsmExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonMoveItemUp_Click(object sender, EventArgs e)
		{
			#region oldcodetokeepforref_1
			//if (this.listViewSqlScripFiles.SelectedItems.Count > -1 && this.listViewSqlScripFiles.Items.Count > 0)
			//{
			//    int selectedIndex;
			//    ListViewItem selectedItem;

			//    selectedIndex = this.listViewSqlScripFiles.SelectedIndices[0];
			//    selectedItem = this.listViewSqlScripFiles.SelectedItems[0];

			//    this.listViewSqlScripFiles.Items.Remove(selectedItem);

			//    if (selectedIndex == 0)
			//        selectedIndex = this.listViewSqlScripFiles.Items.Count + 1;

			//    this.listViewSqlScripFiles.Items.Insert(selectedIndex - 1, selectedItem);
			//    selectedItem.Selected = true;
			//} 
			#endregion
		}

		private void buttonMoveItemDown_Click(object sender, EventArgs e)
		{
			#region oldcodetokeepforref_2
			//if (this.listViewSqlScripFiles.SelectedItems.Count > -1 && this.listViewSqlScripFiles.Items.Count > 0)
			//{
			//    int selectedIndex;
			//    ListViewItem selectedItem;

			//    selectedIndex = this.listViewSqlScripFiles.SelectedIndices[0];
			//    selectedItem = this.listViewSqlScripFiles.SelectedItems[0];

			//    this.listViewSqlScripFiles.Items.Remove(selectedItem);

			//    if (selectedIndex == this.listViewSqlScripFiles.Items.Count)
			//        selectedIndex = -1;

			//    this.listViewSqlScripFiles.Items.Insert(selectedIndex + 1, selectedItem);
			//    selectedItem.Selected = true;
			//} 
			#endregion
		}
		
		private void buttonRun_Click(object sender, EventArgs e)
		{
			RunScripts frmRunScripts = new RunScripts();
			frmRunScripts.ShowDialog(this);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.propertyGridMain.CommandsVisibleIfAvailable = true;
			this.propertyGridMain.SelectedObject = this._Laucher;
		}

		private void propertyGridMain_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (e.ChangedItem.PropertyDescriptor.DisplayName == "ScriptsDirectoryPath" && this._Laucher.ScriptsDirectoryPath != string.Empty)
			{
				this.populateScriptsList();
			}
		}
    }
}