﻿using System;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class DeleteGroceryItem
    {
	    public DeleteGroceryItem()
	    {
	    }

		//	TODO: replace connection string local variables with environment variables
	    private const string SERVER = "localhost";
	    private const string DATABASE = "gl_db";
	    private const string USER = "gl_user";
	    private const string PASSWORD = "cbf5fbb4-636b-4ce7-81d5-3dda794abd31";


		private static string GetConnectionString()
	    {
		    var csBuilder = new NpgsqlConnectionStringBuilder()
		    {
//			    Host = Environment.GetEnvironmentVariable("GL_HOST"),
//			    Database = Environment.GetEnvironmentVariable("GL_DATABASE"),
//			    Username = Environment.GetEnvironmentVariable("GL_USER"),
//			    Password = Environment.GetEnvironmentVariable("GL_PASSWORD")
				Host = SERVER,
			    Database = DATABASE,
			    Username = USER,
			    Password = PASSWORD
		    };

		    return csBuilder.ConnectionString;
	    }
		public void DeleteGroceryItemQuery(string name)
	    {
			// Create and Open Database connection
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			string sql =
				"DELETE FROM GroceryItems " +
				"WHERE (name = :name);";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
			cmd.Parameters[0].Value = name.ToUpper();

			// Run the query
			cmd.ExecuteNonQuery();

			// Close Database Connection
			conn.Close();
			cmd.Dispose();
	    }
	}
}
