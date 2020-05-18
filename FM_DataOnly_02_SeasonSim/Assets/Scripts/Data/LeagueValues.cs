using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeagueValues
{   
    public LeagueValues()
    {
        RegularGamesPlayed = 0;
        RegularWins = 0;
        RegularLosses = 0;
        RegularDraws = 0;
        RegularPointsScored = 0;
        RegularPointsConceded = 0;
    }

    [Range(0, 14)]
    private int regularGamesPlayed;
    public int RegularGamesPlayed
    { 
        get{return regularGamesPlayed;} 
        set
        {
            regularGamesPlayed = value;
            LeagueValuesChanged();
        }
    }

    [Range(0, 14)]
    int regularWins;
    public int RegularWins
    { 
        get{return regularWins;} 
        set
        {
            regularWins = value;
            LeagueValuesChanged();    
        }
    }

    [Range(0, 14)]
    int regularLosses;
    public int RegularLosses
    { 
        get{return regularLosses;} 
        set
        {
            regularLosses = value;
            LeagueValuesChanged();
        }
    }
    [Range(0, 14)]
    int regularDraws;
    public int RegularDraws
    { 
        get{return regularDraws;} 
        set
        {
            regularDraws = value;
            LeagueValuesChanged();
        }
    }

    int regularPointsScored;
    public int RegularPointsScored
    { 
        get{return regularPointsScored;} 
        set
        {
            regularPointsScored = value;
            LeagueValuesChanged();
        }
    }
    int regularPointsConceded;
    public int RegularPointsConceded
    { 
        get{return regularPointsConceded;} 
        set
        {
            regularPointsConceded = value;
            LeagueValuesChanged();    
        }
    }

    public event Action onLeagueValuesChanged;
    public void LeagueValuesChanged()
    {
        if(onLeagueValuesChanged != null)
        {
            onLeagueValuesChanged();
        }
    }
    
}
