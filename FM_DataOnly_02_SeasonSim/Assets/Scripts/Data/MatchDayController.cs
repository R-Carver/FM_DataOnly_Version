using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchDayController : MonoBehaviour
{
    public static MatchDayController instance;

    private void Awake() {
        instance = this;
    }

    private MatchDay currentMatchday;
    public MatchDay CurrentMatchDay
    {
        get {return currentMatchday;}
        protected set
        {
            if(currentMatchday == value) return;

            currentMatchday = value;
            currentMatchesPlayed = false;
            
            Events_SeasonSimulator.instance.MatchDaySet();
        }
    }

    private bool currentMatchesPlayed;
    public bool CurrentMachtesPlayed
    {
        get{return currentMatchesPlayed;}
        set
        {
            if(currentMatchesPlayed == value) return;

            currentMatchesPlayed = value;
            Events_SeasonSimulator.instance.MatchDayProcessed();
        }
    }

    public void GetNextMatchDay()
    {
        CurrentMatchDay = MatchPairController.instance.currentMatches.Dequeue();
    }
}
