using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text_TeamBudget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events_BuyScene.instance.onTeamChanged += SetText;
    }

    void SetText()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        string capspace = BuyScene_Controller.instance.SelectedTeam.Capspace.ToString();
        text.text = "Current Budget: " + capspace;
    }
}
