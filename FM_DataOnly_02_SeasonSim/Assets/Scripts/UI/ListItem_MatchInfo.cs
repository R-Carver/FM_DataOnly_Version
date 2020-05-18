using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItem_MatchInfo : MonoBehaviour
{
    public TextMeshProUGUI text_awayTeam;
    public TextMeshProUGUI text_homeTeam;

    public void InitMatchInfo(string awayTeam, string homeTeam)
    {
        text_awayTeam.text = awayTeam;
        text_homeTeam.text = homeTeam;
    }
}
