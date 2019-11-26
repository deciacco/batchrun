using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using CustomEditors;
using System.Data;
using System.Data.SqlClient;
using BatchRun.Data;

namespace BatchRun
{
	public class SqlScriptLauncher : IDisposable
	{
		private BatchRunDS _brds;
		private string _connectionString = "";
		private string _scriptsDirectoryPath = "";
		private string _lastScriptsDirectoryPath = "";
		private string _lastErrorMessage = "";
		private string _batchName = "";
		private int _batchId;

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
		
		public SqlScriptLauncher()
		{
			int newRowIndex;

			this._brds = new BatchRunDS();
			BatchRunDS.BatchRow br = this._brds.Batch.NewBatchRow();
			this._brds.Batch.Rows.Add(br);
			
			newRowIndex = this._brds.Batch.Rows.IndexOf(br);

			this._batchId = this._brds.Batch[newRowIndex].BatchId;
			this._brds.Batch[newRowIndex].BatchName = this._batchId.ToString();
		}

		[Description("Name of current batch.")]
		public string BatchName
		{
			get
			{
				return this._batchName;
			}
			set
			{
				this._batchName = value;
			}
		}
				
		[Editor(typeof(SqlStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[Description("The connection string to your database.")]
		public string ConnectionString
		{
			get 
			{ 
				return this._connectionString; 
			}
			set 
			{
				this._connectionString = value; 
			}
		}

		[Editor(typeof(FolderBrowserEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[Description("The full path of the directory containing your script files.")]
		public string ScriptsDirectoryPath
		{
			get 
			{ 
				return this._scriptsDirectoryPath; 
			}
			set 
			{ 
				this._scriptsDirectoryPath = value;
				this.FillScriptsList();
			}
		}

		[BrowsableAttribute(false), ReadOnly(true)]
		public string ErrorMessage
		{
			get { return this._lastErrorMessage; }
		}

		[BrowsableAttribute(false)]
		public DirectoryInfo ScriptFilesInfo
		{
			get { return new DirectoryInfo(this._scriptsDirectoryPath);}
		}

		[BrowsableAttribute(false)]
		public BatchRunDS.ScriptsListDataTable ScriptFilesData
		{
			get { return this._brds.ScriptsList; }
		}
		
		private void ExecuteSql(SqlConnection connection, string sqlFile)
		{
			string sql = "";

			using (FileStream strm = File.OpenRead(sqlFile))
			{
				StreamReader reader = new StreamReader(strm);
				sql = reader.ReadToEnd();
			}

			Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			string[] lines = regex.Split(sql);

			SqlTransaction transaction = connection.BeginTransaction();

			using (SqlCommand cmd = connection.CreateCommand())
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;

				foreach (string line in lines)
				{
					if (line.Length > 0)
					{
						cmd.CommandText = line;
						cmd.CommandType = CommandType.Text;

						try
						{
							cmd.ExecuteNonQuery();
						}
						catch (SqlException)
						{
							transaction.Rollback();
							throw;
						}
					}
				}
			}

			transaction.Commit();
		}

		private bool FillScriptsList()
		{
			bool methodSuccess = true;

			if (this._scriptsDirectoryPath == string.Empty)
			{
				methodSuccess = false;
				this._lastErrorMessage = "Cannot fill scripts list from empty scripts directory path";
			}
			else
			{
				if (this._scriptsDirectoryPath != this._lastScriptsDirectoryPath)
				{
					int sortOrder = 1;
					DirectoryInfo scriptFilesDirInfo = new DirectoryInfo(this._scriptsDirectoryPath);
					
					//scan directory and add any script files.
					foreach (FileInfo f in scriptFilesDirInfo.GetFiles())
					{
						if (f.Extension.ToLower() == @".sql")
						{
							//add new row to scripts list data table
							BatchRunDS.ScriptsListRow slr = this._brds.ScriptsList.NewScriptsListRow();
							slr.ScriptPath = f.FullName;
							slr.ScriptName = f.Name;
							slr.ScriptExt = f.Extension.Replace(".","");
							slr.WillExecute = true;
							slr.SortOrder = sortOrder;
							this._brds.ScriptsList.Rows.Add(slr);
							sortOrder += 1;
						}
					}

					//keep track of current directory to avoid scanning same directory
					this._lastScriptsDirectoryPath = this._scriptsDirectoryPath;
				}
			}

			return methodSuccess;
		}
	}
}
