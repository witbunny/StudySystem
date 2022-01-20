using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace cprocess
{
	class DbHelper
	{
		private const string connectionString =
			@"Data Source=localhost\SQLEXPRESS;
				Initial Catalog=TaskSQL;
				User ID=sa;
				Password=0117;
				Connect Timeout=30;
				Encrypt=False;
				TrustServerCertificate=False;
				ApplicationIntent=ReadWrite;
				MultiSubnetFailover=False";

		public IDbConnection GetNewConnection()
		{
			return new SqlConnection(connectionString);
		}

		//public IDbConnection GetCurrentConnection() { }

		public int ExecuteNonQuery(string cmdText, params IDataParameter[] parameters)
		{
			using (IDbConnection connection = GetNewConnection())
			{
				try
				{
					connection.Open();

					IDbCommand command = new SqlCommand();
					command.Connection = connection;

					command.CommandText = cmdText;
					for (int i = 0; i < parameters.Length; i++)
					{
						command.Parameters.Add(parameters[i]);
					}

					return command.ExecuteNonQuery();
				}
				catch (Exception)
				{

					throw;
				}
			}
		}

		public int Insert(string cmdText, params IDataParameter[] parameters)
		{
			return ExecuteNonQuery(cmdText, parameters);
		}

		public int Delete(string cmdText, params IDataParameter[] parameters)
		{
			return ExecuteNonQuery(cmdText, parameters);
		}

		public int Update(string cmdText, params IDataParameter[] parameters)
		{
			return ExecuteNonQuery(cmdText, parameters);
		}
	}
}
