using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_MatchInfo : MonoBehaviour
{   
    public GameObject noMatchdayInfo;
    public GameObject matchListItem;

    public GameObject resultListItem;
    // Start is called before the first frame update
    void Start()
    {
        Events_SeasonSimulator.instance.onGameDaySet += UpdatePanelNoMatch;
        Events_SeasonSimulator.instance.onMatchDaySet += UpdatePanelMatch;
        Events_SeasonSimulator.instance.onMatchDayProcessed += UpdateResultPanel;
    }

    void UpdateResultPanel()
    {
        DestroyOldInfo();

        List<Match> currentMatches = MatchDayController.instance.CurrentMatchDay.matches;
        foreach(Match match in currentMatches)
        {
            GameObject resultGo = Instantiate(resultListItem);
            resultGo.transform.SetParent(this.transform, false);

            ListItem_Result listItem = resultGo.GetComponent<ListItem_Result>();

            string resultString = match.GetResultAsString();
            listItem.InitResult(match.team1.name, match.team2.name, resultString); 

        }
    }

    void UpdatePanelMatch()
    {   
        //check if the current day is a matchday
        if(SeasonController.instance.currentDay.GameEvent != null)
        {   
            DestroyOldInfo();

            //show the matchinfo panels

            List<Match> currentMatches = MatchDayController.instance.CurrentMatchDay.matches;

            foreach(Match match in currentMatches)
            {
                GameObject matchDayGo = Instantiate(matchListItem);
                matchDayGo.transform.SetParent(this.transform, false);

                ListItem_MatchInfo listItem = matchDayGo.GetComponent<ListItem_MatchInfo>();

                listItem.InitMatchInfo(match.team1.name, match.team2.name);
            }    
        }
    }

    void UpdatePanelNoMatch()
    {   
        DestroyOldInfo();
        //check if the current day is a matchday
        if(SeasonController.instance.currentDay.GameEvent == null)
        {
            //show the indicator for no match
            GameObject noMatchGo = Instantiate(noMatchdayInfo);
            noMatchGo.transform.SetParent(this.transform, false);
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
