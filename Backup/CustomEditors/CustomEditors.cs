using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace CustomEditors
{
	public class SqlOleDBStringEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			Cursor.Current = Cursors.WaitCursor;
			string tmpReturn = string.Empty;
			MSDASC.DataLinks dataLinks = new MSDASC.DataLinksClass();
			ADODB._Connection connection = null;

			if (value.ToString() == String.Empty)
			{
				try
				{
					connection = (ADODB._Connection)dataLinks.PromptNew();
					if (connection != null)//if cancel is pressed connection is null
						tmpReturn = connection.ConnectionString;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			else
			{
				connection = new ADODB.ConnectionClass();
				connection.ConnectionString = value.ToString();

				object oConnection = connection;
				try
				{
					if ((bool)dataLinks.PromptEdit(ref oConnection))
						tmpReturn = connection.ConnectionString;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			Cursor.Current = Cursors.Default;
			return tmpReturn;
		}
	}

	public class SqlStringEditor : UITypeEditor
	{
		private SqlStringEditorDialog _ssed;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			Cursor.Current = Cursors.WaitCursor;
			IWin32Window ww = provider.GetService(
				typeof(IWin32Window)) as
				IWin32Window;

			this._ssed = new SqlStringEditorDialog();
			this._ssed.ShowDialog(ww);
			value = this._ssed.ConnString;
			Cursor.Current = Cursors.Default;
			return value;
		}
	}

	public class FolderBrowserEditor : UITypeEditor
	{
		private FolderBrowserDialog _fbd;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			Cursor.Current = Cursors.WaitCursor;
			IWin32Window ww = provider.GetService(
				typeof(IWin32Window)) as
				IWin32Window;
		
			this._fbd = new FolderBrowserDialog();
			this._fbd.ShowNewFolderButton = false;
			this._fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
			this._fbd.Description = "Select Folder";
			if(this._fbd.ShowDialog(ww) == DialogResult.OK)
				value = this._fbd.SelectedPath;
			Cursor.Current = Cursors.Default;
			return value;
		}
	}
}
