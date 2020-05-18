using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_PlayMatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        Events_SeasonSimulator.instance.onGameDaySet += CheckIfMatchday;
        GetComponent<Button>().onClick.AddListener(PlayMatch);
    }

    void CheckIfMatchday()
    {
        if(SeasonController.instance.currentDay.GameEvent == null)
        {
            //no matchday
            this.gameObject.SetActive(false);
        }else
        {
            //matchday
            this.gameObject.SetActive(true);
        }
    }

    void PlayMatch()
    {
        //here we can assume that this is a matchday
        MatchDay currentMatchday = MatchDayController.instance.CurrentMatchDay;

        foreach(Match match in currentMatchday.matches)
        {
            match.SimulateMatch();
        }
        MatchDayController.instance.CurrentMachtesPlayed = true;
    }
}
