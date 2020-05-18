using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Panel_Division : MonoBehaviour
{   
    public DivisionName myDivision;

    public GameObject teamListItem;

    List<Team> divisionTeams;
    void Start()
    {
        Events_SeasonSimulator.instance.onMatchDayProcessed += UpdateTable;
        if(myDivision == DivisionName.northern)
        {
            divisionTeams = LeagueController.instance.northern.teams;
        }else
        {
            divisionTeams = LeagueController.instance.southern.teams;
        }
        UpdateTable();
    }

    void UpdateTable()
    {
        DestroyOldInfo();
        
        List<Team> orderedTeams = divisionTeams.OrderByDescending(t => t.myLeagueValues.RegularWins).ToList();
        foreach(Team team in orderedTeams)
        {
            GameObject teamGo = Instantiate(teamListItem);
            teamGo.transform.SetParent(this.transform, false);

            ListItem_Table listItem = teamGo.GetComponent<ListItem_Table>();

            listItem.UpdateText(team.name, team.myLeagueValues);
        }
    }

    void DestroyOldInfo()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
}
