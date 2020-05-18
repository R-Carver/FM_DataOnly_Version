using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

public class Player_model : SqliteHelper
{
    public static Player_model instance;

    private const string TABLE_NAME_PLAYER = "Player";
    private const string TABLE_NAME_ATTRIBUTES = "Attributes";
    private const string TABLE_NAME_SKILLS = "Skills";

    public Player_model(string dataPath) : base(dataPath)
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void AddPlayer(Player newPlayer)
    {
        IDbCommand cmd = base.GetDbCommand();

        using(IDbTransaction transaction = base.db_connection.BeginTransaction())
        {
            try
            {
                // create and add the player-Attributes
                string createAttributesString = base.GetInsertStringForObject(newPlayer.attributes, TABLE_NAME_ATTRIBUTES);

                cmd.CommandText = createAttributesString;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT last_insert_rowid()";
                Int64 LastRow64 = (Int64)cmd.ExecuteScalar();
                int attrId = (int)LastRow64;

                // create and add the player-Skills
                string createSkillsString = base.GetInsertStringForObject(newPlayer.skills, TABLE_NAME_SKILLS);

                cmd.CommandText = createSkillsString;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT last_insert_rowid()";
                LastRow64 = (Int64)cmd.ExecuteScalar();
                int skillId = (int)LastRow64;

                // add player, set attr and skills
                string createPlayerString = 
                    "INSERT INTO " + TABLE_NAME_PLAYER + " (name, position, attributes, skills) " +
                    "VALUES (" +
                    "\"" + newPlayer.name + "\"" + "," +
                    ((int)newPlayer.position.myPosition).ToString() + "," +
                    attrId.ToString() + "," +
                    skillId.ToString() +
                    ") ";

                cmd.CommandText = createPlayerString;
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

    public Attributes GetAttributes(int attributeId)
    {
        return null;
    }

    public Skills GetSkills(int skillId)
    {
        return null;
    }

    private List<Player> CreatePlayerList(IDataReader reader)
    {
        List<Player> outList = new List<Player>();

        //to be implemented

        return outList;
    }

    public void CloseConnection()
    {
        base.close();
    }
}
