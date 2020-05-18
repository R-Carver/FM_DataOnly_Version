using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text_Contract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events_BuyScene.instance.onPlayerChanged += SetContractText;
        Events_BuyScene.instance.onTeamChanged += SetContractText;

        SetContractText();
    }

    void SetContractText()
    {   
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

        Team currentTeam = BuyScene_Controller.instance.SelectedTeam;
        Player currentPlayer = BuyScene_Controller.instance.SelectedPlayer;

        if(currentPlayer == null || currentTeam == null)
        {
            text.text = "Please select Player and team";
        }else
        {
            text.text = currentPlayer.name + " to " + currentTeam.name;
        }
    }
    
}
