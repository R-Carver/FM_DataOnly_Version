using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Team t1 = Team_model.instance.GetTeamById(1);
        List<Team> allTeams = Team_model.instance.GetAllTeams();

        List<Player> allFreeAgents = Player_model.instance.GetFreeAgents();
        List<Player> newEnglandPlayers = Player_model.instance.GetPlayersByTeam(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
