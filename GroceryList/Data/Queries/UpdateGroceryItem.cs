﻿using Npgsql;

namespace GroceryList.Data.Queries
{
    public class UpdateGroceryItem
    {
	    public UpdateGroceryItem()
	    {
	    }

		//	TODO: replace connection string local variables with environment variables
	    private const string SERVER = "localhost";
	    private const string DATABASE = "GroceryListDB";
	    private const string USER = "kwik";
	    private const string PASSWORD = "pNyn8_5E";
	    private static string GetConnectionString()
	    {
		    var csBuilder = new NpgsqlConnectionStringBuilder()
		    {
			    Host = SERVER,
			    Database = DATABASE,
			    Username = USER,
			    Password = PASSWORD
		    };

		    return csBuilder.ConnectionString;
	    }

	    public void UpdateGroceryItemQuery(GroceryItem Request)
	    {
			// Create and Open Database Connection
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
		    string sql =
			    "UPDATE " +
					"GroceryItems SET quantity = (quantity + :quantity) " +
			    "WHERE name = :name;";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
		    cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
		    cmd.Parameters[0].Value = Request.name.ToUpper();
		    cmd.Parameters.Add(new NpgsqlParameter("quantity", NpgsqlTypes.NpgsqlDbType.Integer));
		    cmd.Parameters[1].Value = Request.quantity;

			// Execute Query
		    cmd.ExecuteNonQuery();

			// Close Database Connection
			conn.Close();

	    }
    }
}

