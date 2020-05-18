using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItem_Result : MonoBehaviour
{
    public TextMeshProUGUI text_awayTeam;
    public TextMeshProUGUI text_homeTeam;
    public TextMeshProUGUI text_result;

    public void InitResult(string awayTeam, string homeTeam, string result)
    {
        text_awayTeam.text = awayTeam;
        text_homeTeam.text = homeTeam;
        text_result.text = result;
    }
}
