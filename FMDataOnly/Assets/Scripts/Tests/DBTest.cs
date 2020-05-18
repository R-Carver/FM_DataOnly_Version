using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBTest : MonoBehaviour
{   
    private void Start() {
        ReadDatabase();
    }
    void ReadDatabase()
    {
        string conn = "URI=file:" + Application.dataPath + "/DB/TestDb.db";

        IDbConnection dbConn;
        dbConn = (IDbConnection)new SqliteConnection(conn);
        dbConn.Open();

        IDbCommand dbcmd = dbConn.CreateCommand();

        string sqlQuery = "SELECT name, hunger FROM Mopse";

        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();

        while(reader.Read())
        {   
            string name = reader.GetString(0);
            int hunger = reader.GetInt16(1);

            Debug.Log("Name: " + name + "hunger " + hunger.ToString());
        }

        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;

        dbConn.Close();
        dbConn = null;

    }
}
