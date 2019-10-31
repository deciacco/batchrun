using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomEditors
{
	public partial class SqlStringEditorDialog : Form
	{
		private SqlConnectionStringBuilder _scsb = null;
		private SQLDMO.Application _sqlapp;
		private SQLDMO.NameList _sqlservers;
		private SQLDMO.SQLServer _server;

		public SqlStringEditorDialog()
		{
			InitializeComponent();
			this._scsb = new SqlConnectionStringBuilder();
			this._sqlapp = new SQLDMO.ApplicationClass();
			this._sqlservers = this._sqlapp.ListAvailableSQLServers();
			this._server = new SQLDMO.SQLServerClass();
		}

		public SqlStringEditorDialog(ref SqlConnectionStringBuilder scsb) : base()
		{
			this._scsb.ConnectionString = scsb.ConnectionString;
		}

		public string ConnString
		{
			get { return this._scsb.ConnectionString; }
			set { this._scsb.ConnectionString = value; }
		}

		private void SqlStringEditorDialog_Load(object sender, EventArgs e)
		{
			this.comboBoxAuthType.Items.Add("Windows Authentication");
			this.comboBoxAuthType.Items.Add("Sql Server Authentication");
			this.comboBoxAuthType.SelectedIndex = 0;

			this.textBoxUser.Text = Environment.UserDomainName + "\\" + Environment.UserName;

			//Get Sql Servers
			for (int i = 0; i < this._sqlservers.Count; i++)
			{
				object srv = this._sqlservers.Item(i + 1);
				if (srv != null)
					this.comboBoxServers.Items.Add(srv);
			}

			if (this.comboBoxServers.Items.Count > 0)
				this.comboBoxServers.SelectedIndex = 0;
			else
				this.comboBoxServers.Text = "<No available SQL Servers>"; 

			this.textBoxUser.Enabled = false;
			this.textBoxPass.Enabled = false;

			this.connectToServer();
		}

		private void comboBoxAuthType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxAuthType.SelectedIndex == 1)
			{
				this.textBoxUser.Enabled = true;
				this.textBoxPass.Enabled = true;
				this.textBoxPass.Text = string.Empty;
				this.textBoxUser.Text = string.Empty;
				this.textBoxUser.Focus();
			}
			else
			{
				this.textBoxUser.Enabled = false;
				this.textBoxPass.Enabled = false;
				this.textBoxUser.Text = Environment.UserDomainName + "\\" + Environment.UserName;
				this.textBoxPass.Text = string.Empty;
			}
		}

		private void getDatabases()
		{
			foreach (SQLDMO.Database db in this._server.Databases)
			{
				if (db.Name != null)
					this.comboBoxDb.Items.Add(db.Name);
			}
		}

		private void connectToServer()
		{
			this.comboBoxDb.Items.Clear();
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				if (this.IsConnected())
					this._server.DisConnect();

				switch (this.comboBoxAuthType.SelectedIndex)
				{
					case 0://Windows
						this._server.LoginSecure = true;
						this._server.Connect(this.comboBoxServers.SelectedItem.ToString(), null, null);
						this.getDatabases();
						break;
					case 1://Sql Server
						this._server.LoginSecure = false;
						if (this.textBoxUser.Text != string.Empty && this.textBoxPass.Text != string.Empty)
						{
							this._server.Connect(this.comboBoxServers.SelectedItem.ToString(), this.textBoxUser.Text, this.textBoxPass.Text);
							this.getDatabases();
						}
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void comboBoxAuthType_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(this.comboBoxAuthType.SelectedIndex == 0)
			{
				this.connectToServer();
			}
		}

		private void textBoxUser_Leave(object sender, EventArgs e)
		{
			this.connectToServer();
		}

		private void textBoxPass_Leave(object sender, EventArgs e)
		{
			this.connectToServer();
		}

		private bool IsConnected()
		{
			try
			{
				if (this._server.VerifyConnection(false))
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				if (ex != null)
				{ }
				return false;
			}
			
		}

		private void comboBoxServers_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.connectToServer();
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			this._scsb.UserID = this.textBoxUser.Text;
			this._scsb.Password = this.textBoxPass.Text;
			this._scsb.DataSource = this.comboBoxServers.Text;
			this._scsb.InitialCatalog = this.comboBoxDb.Text;
			this._scsb.IntegratedSecurity = (this.comboBoxAuthType.SelectedIndex == 0 ? true: false);
		}
	}
}