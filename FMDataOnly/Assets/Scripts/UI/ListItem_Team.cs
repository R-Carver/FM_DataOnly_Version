using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItem_Team : MonoBehaviour, IPropertyListener<Team>
{   
    public TextMeshProUGUI text_teamName;
    public TextMeshProUGUI text_capSpace;
    
    public void SetTeamname(string teamName)
    {
        text_teamName.text = teamName;
    }

    public void SetCapSpace(int capSpace)
    {
        text_capSpace.text = capSpace.ToString();
    }

    public void OnPropertyChanged(Team changedTeam)
    {
        SetCapSpace(changedTeam.Capspace);
    }
}
