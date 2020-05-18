using System.Collections.Generic;
using System.Data;

public class Player_model : SqliteHelper
{
    public static Player_model instance;
    private const string TABLE_NAME = "Player";

    public Player_model(string dataPath) : base(dataPath)
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public List<Player> GetFreeAgents()
    {
        IDbCommand cmd = base.GetDbCommand();

        string query = "SELECT * FROM " + TABLE_NAME + " " +
                        "WHERE contract IS NULL";

        cmd.CommandText = query;

        return CreatePlayerList(cmd.ExecuteReader());
    }

    public List<Player> GetPlayersByTeam(int teamId)
    {
        IDbCommand cmd = base.GetDbCommand();

        string query = "SELECT * FROM " + TABLE_NAME + " " +
                        "WHERE contract IN " +
                        "(SELECT id FROM contract WHERE contract.team = " + teamId.ToString() + ")";

        cmd.CommandText = query;

        return CreatePlayerList(cmd.ExecuteReader());
    }

    private List<Player> CreatePlayerList(IDataReader reader)
    {   
        List<Player> outList = new List<Player>();
        while(reader.Read())
        {
            int player_id = reader.GetInt32(0);
            string player_name = reader.GetString(1);
            int player_pos = reader.GetInt32(2);
            int player_cost = reader.GetInt32(3);

            outList.Add(new Player(player_id, player_name, player_pos, player_cost));
        }
        return outList;
    }

    public void CloseConnection()
    {
        base.close();
    }

}