using System.Collections.Generic;
using System.Data;

public class Team_model : SqliteHelper
{   
    public static Team_model instance;
    private const string TABLE_NAME = "Team";

    public Team_model(string dataPath) : base(dataPath)
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Team GetTeamById(int id)
    {   
        //get Data
        IDbCommand cmd = base.GetDbCommand();

        string query = "SELECT * FROM " + TABLE_NAME + " " + 
                        "WHERE id = " + id.ToString(); 

        cmd.CommandText = query;

        //create Player
        Team newTeam = null;

        IDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            int team_id = reader.GetInt32(0);
            string team_name = reader.GetString(1);
            int team_capspace = reader.GetInt32(2);

            newTeam = new Team(team_id, team_name, team_capspace);
        }

        if(newTeam == null)
        {
            return null;
        }else{
            return newTeam;
        }
    }

    public List<Team> GetAllTeams()
    {
         //get Data
        IDbCommand cmd = base.GetDbCommand();

        string query = "SELECT * FROM " + TABLE_NAME + " " + 
                        "ORDER BY name ASC"; 

        cmd.CommandText = query;

        //create Players
        List<Team> outList = new List<Team>();

        IDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {   
            int team_id = reader.GetInt32(0);
            string team_name = reader.GetString(1);
            int team_capspace = reader.GetInt32(2);
            
            outList.Add(new Team(team_id, team_name, team_capspace));
        }
        return outList;
    }

    public void CloseConnection()
    {
        base.close();
    }
}