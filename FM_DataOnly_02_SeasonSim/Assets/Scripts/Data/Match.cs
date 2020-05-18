using UnityEngine;
using System;

public class Match
{
    public Team team1;
    public Team team2;

    //result in the form <pointsTeam1, pointsTeam2>
    Vector2Int result;
    public Match(Team team1, Team team2)
    {
        this.team1 = team1;
        this.team2 = team2;
    }

    public string GetResultAsString()
    {
        if(result != null)
        {
            return result.x.ToString() + ":" + result.y.ToString();
        }
        return "no result";
    }

    public void SimulateMatch()
    {   
        /*
        There are 10 rounds in which one of the teams can score. 
        First it is determined which team can score and then if it scores a 
        field goal, a touchdown or misses
        */

        int pointsTeam1 = 0;
        int pointsTeam2 = 0;

        for(int i=0; i<10; i++)
        {
            //Winning team scores
            float team1rand = (float)Math.Round(UnityEngine.Random.Range(0.0f, 1.0f), 3);
            float team1score = team1rand * team1.strength;

            float team2rand = (float)Math.Round(UnityEngine.Random.Range(0.0f, 1.0f), 3);
            float team2score = team2rand * team2.strength;

            Team roundWinner = (team1score > team2score) ? team1 : team2;

            //Now see if the winning team manages to score
            int driveValue = UnityEngine.Random.Range(0, 10);

            
            if (driveValue <= 4)
            {   
                //didnt manage to score
                continue;
            }else if(driveValue <= 8)
            {   
                //fieldgoal scored
                if(roundWinner == team1)
                {
                    pointsTeam1 += 3;
                }else
                {
                    pointsTeam2 += 3;
                }
            }else
            {
                //touchdown scored
                if(roundWinner == team1)
                {
                    pointsTeam1 += 7;
                }else
                {
                    pointsTeam2 += 7;
                }
            }
        }

        //set the final points
        this.result = new Vector2Int(pointsTeam1, pointsTeam2);
        UpdateLeagueValues();
        
    }

    void UpdateLeagueValues()
    {   
        team1.myLeagueValues.RegularGamesPlayed ++;
        team2.myLeagueValues.RegularGamesPlayed ++;

        if(result.x > result.y)
        {
            //team 1 won
            team1.myLeagueValues.RegularWins ++;
            team2.myLeagueValues.RegularLosses --;

            

        }else if(result.x < result.y)
        {
            //team2 won
            team2.myLeagueValues.RegularWins ++;
            team1.myLeagueValues.RegularLosses --;

        }else
        {
            //draw
            team1.myLeagueValues.RegularDraws ++;
            team2.myLeagueValues.RegularDraws ++;
        }

        //update points
        team1.myLeagueValues.RegularPointsScored += result.x;
        team1.myLeagueValues.RegularPointsConceded += result.y;

        team2.myLeagueValues.RegularPointsScored += result.y;
        team2.myLeagueValues.RegularPointsConceded += result.x;
    }

}