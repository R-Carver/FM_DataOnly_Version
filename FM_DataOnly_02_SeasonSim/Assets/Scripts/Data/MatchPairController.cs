using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MatchPairController : MonoBehaviour
{
    public static MatchPairController instance;

    private void Awake() {
        instance = this;
    }

    public Queue<MatchDay> currentMatches;

    private void Start() {
        currentMatches = getSeasonMatchDays();
    }

    public Queue<MatchDay> getSeasonMatchDays()
    {
        //here we create the Matchpairs for all Matchdays of one year
        Queue<MatchDay> allMatches = new Queue<MatchDay>();
        
        //1. create list where all teams have the info about whom they allready
        //played
        List<MatchPairTeam> matchTeams = new List<MatchPairTeam>();

        List<Team> allTeamsTemp = LeagueController.instance.teams; 
        foreach(Team team in allTeamsTemp)
        {
            MatchPairTeam newTeam = new MatchPairTeam(team);
            //the team has to play all teams execpt itself
            IEnumerable<Team> iterator = allTeamsTemp.Where(t => t.name != team.name);
            foreach(Team t in iterator)
            {
                newTeam.teamsToPlay.Add(t);
            }

            matchTeams.Add(newTeam);
        }

        //2. create the 7 games
        for(int i=0; i<7; i++)
        {

            MatchDay matchDay = new MatchDay();;
            List<MatchPairTeam> matchTeamsForDay = new List<MatchPairTeam>(matchTeams);
            while(matchTeamsForDay.Count != 0)
            {   
                //take some team
                MatchPairTeam someTeam = matchTeamsForDay.ElementAtOrDefault(0);
                MatchPairTeam validOponent = matchTeamsForDay.FirstOrDefault(t => t.teamsToPlay.Contains(someTeam.team) );

                //create a match with the two teams
                Match newMatch = new Match(someTeam.team, validOponent.team);
                matchDay.matches.Add(newMatch);

                //mark the current combination as done
                someTeam.teamsToPlay.Remove(validOponent.team);
                validOponent.teamsToPlay.Remove(someTeam.team);

                //remove the teams from the candidates for the current matchday
                matchTeamsForDay.Remove(someTeam);
                matchTeamsForDay.Remove(validOponent);

            }

            allMatches.Enqueue(matchDay);
        }

        return allMatches;
    }
}

//this is a wrapper for the teams to keep track of the teams they are
//allready matched with
public class MatchPairTeam
{
    public Team team;

    public List<Team> teamsToPlay;

    public MatchPairTeam(Team team)
    {
        this.team = team;

        teamsToPlay = new List<Team>();
    }
}
