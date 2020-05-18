using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public string name;

    //this is used to simulate a match
    [Range(0, 100)]
    public int strength;

    public Team(string name, int strength)
    {
        this.name = name;
        this.strength = strength;
    }

    public LeagueValues myLeagueValues;
}
