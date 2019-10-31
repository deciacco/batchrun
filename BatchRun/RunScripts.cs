using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BatchRun
{
	public partial class RunScripts : Form
	{
		public RunScripts()
		{
			InitializeComponent();
		}

		public RunScripts(SqlScriptLauncher ssl)
			: base()
		{

		}
		
		private void RunScripts_Shown(object sender, EventArgs e)
		{
			this.executeScripts();
		}
		
		private void executeScripts()
		{
			ListView listviewProgress = (ListView)this.Owner.Controls["listViewSqlScripFiles"];
			
			for (int i = 0; i < listviewProgress.CheckedItems.Count; i++)
			{
				this.listviewProgress.Items.Add((ListViewItem)listviewProgress.CheckedItems[i].Clone());

			}
		}
	}
}