using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeagueController : MonoBehaviour
{
    public static LeagueController instance;

    private void Awake() {
        
        instance = this;
        CreateLeague();
    }

    private void Start() {

        StartCoroutine(TestSeasonMatchDays());
        
    }

    IEnumerator TestSeasonMatchDays()
    {
        yield return new WaitUntil(() => MatchPairController.instance != null);
        MatchPairController.instance.getSeasonMatchDays();
    }
    

    public List<Team> teams;

    public Division northern;
    public Division southern;

    void CreateLeague()
    {
        teams = new List<Team>();

        northern = new Division("Northern Football Division");
        southern = new Division("Southern Football Division");

        //teams in northern division
        Team newEngland = new Team("New England Patriots", 90);
        newEngland.myLeagueValues = new LeagueValues();
        teams.Add(newEngland);
        northern.teams.Add(newEngland);

        Team buffalo = new Team("Buffalo Bills", 75);
        buffalo.myLeagueValues = new LeagueValues();
        teams.Add(buffalo);
        northern.teams.Add(buffalo);

        Team miami = new Team("Miami Dolphins", 55);
        miami.myLeagueValues = new LeagueValues();
        teams.Add(miami);
        northern.teams.Add(miami);

        Team jets = new Team("New York Yets", 71);
        jets.myLeagueValues = new LeagueValues();
        teams.Add(jets);
        northern.teams.Add(jets);

        //teams in southern division
        Team kansas = new Team("Kansas City Chiefs", 95);
        kansas.myLeagueValues = new LeagueValues();
        teams.Add(kansas);
        southern.teams.Add(kansas);

        Team rams = new Team("Los Angeles Rams", 85);
        rams.myLeagueValues = new LeagueValues();
        teams.Add(rams);
        southern.teams.Add(rams);

        Team buccs = new Team("Tampa Bay Buccaneers", 80);
        buccs.myLeagueValues = new LeagueValues();
        teams.Add(buccs);
        southern.teams.Add(buccs);

        Team saints = new Team("New Orleans Saints", 88);
        saints.myLeagueValues = new LeagueValues();
        teams.Add(saints);
        southern.teams.Add(saints);

    }
}

public class Division
{
    public string name;
    //the short name for the division
    public string abreviation;
    public List<Team> teams; 

    public Division(string name)
    {
        this.name = name;
        teams = new List<Team>();
    }
}

public enum DivisionName
{
    northern,
    southern
}
