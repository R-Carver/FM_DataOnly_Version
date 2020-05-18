using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class SqliteHelper
{
    private const string database_name = "FM_DB_Proto_01.db";

    public string db_connection_string;
    public IDbConnection db_connection;

    public SqliteHelper(string dataPath)
    {
        db_connection_string = "URI=file:" + dataPath + "/DB/" + database_name;
        db_connection = new SqliteConnection(db_connection_string);
        db_connection.Open();

        Debug.Log("Db Connection");
    }

    //Helper functions
    public IDbCommand GetDbCommand()
    {
        return db_connection.CreateCommand();
    }

    public IDataReader getNumOfRows(string table_name)
    {
        IDbCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText =
            "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
        IDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public void close()
    {
        db_connection.Close();
    }
}