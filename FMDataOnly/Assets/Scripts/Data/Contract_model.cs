using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

public class Contract_model : SqliteHelper
{   
    public static Contract_model instance;

    private const string TABLE_NAME = "Contract";

    public Contract_model(string dataPath) : base(dataPath)
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void AddContract(int teamId, int playerId, int playerCost)
    {
        IDbCommand cmd  = base.GetDbCommand();

        using(IDbTransaction transaction = base.db_connection.BeginTransaction())
        {
            try
            {
                //create new contract
                string createContract = "INSERT INTO Contract (cost, player, team) " +
                                "VALUES (" +
                                playerCost.ToString() + "," +
                                playerId.ToString() + "," +
                                teamId.ToString() +
                                ")";

                cmd.CommandText = createContract;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT last_insert_rowid()";

                Int64 LastRow64 = (Int64)cmd.ExecuteScalar();
                int lastId = (int)LastRow64;

                //update contract info on player
                string updateContractInfo = "UPDATE Player " + 
                                            "SET contract = " + lastId.ToString() + " " +
                                            "WHERE id = " + playerId.ToString();

                cmd.CommandText = updateContractInfo;
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }
        }
    }

    public void CloseConnection()
    {
        base.close();
    }
}