using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItem_Table : MonoBehaviour
{   
    public TextMeshProUGUI text_teamname;

    public TextMeshProUGUI text_gamesPlayed;

    public TextMeshProUGUI text_gamesWon;

    public TextMeshProUGUI text_gameLost;

    public TextMeshProUGUI text_points;

    public void UpdateText(string teamName, LeagueValues newValues)
    {
        text_teamname.text = teamName;

        text_gamesPlayed.text = newValues.RegularGamesPlayed.ToString();
        text_gamesWon.text = newValues.RegularWins.ToString();
        text_gameLost.text = newValues.RegularLosses.ToString();
        
        string points = newValues.RegularPointsScored.ToString() 
                        + ":" 
                        + newValues.RegularPointsConceded.ToString();
        
        text_points.text = points;
    }


}
