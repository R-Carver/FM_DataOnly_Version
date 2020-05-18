using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItem_Player : MonoBehaviour
{
    public TextMeshProUGUI text_playerName;
    public TextMeshProUGUI text_position;
    public TextMeshProUGUI text_cost;
    
    public void SetPlayername(string playerName)
    {
        text_playerName.text = playerName;
    }

    public void SetPosition(Position position)
    {
        text_position.text = position.ToString();
    }

    public void SetCost(int cost)
    {
        text_cost.text = cost.ToString();
    }

}
