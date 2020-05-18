using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_ConfirmContract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events_BuyScene.instance.onPlayerChanged += SetButtonActive;
        Events_BuyScene.instance.onTeamChanged += SetButtonActive;

        GetComponent<Button>().onClick.AddListener(() => ConfirmContract());
    }

    private void OnEnable() {
        
        SetButtonActive();
    }

    void SetButtonActive()
    {   
        Team currentTeam = BuyScene_Controller.instance.SelectedTeam;
        Player currentPlayer = BuyScene_Controller.instance.SelectedPlayer;

        if(currentPlayer == null || currentTeam == null)
        {
            this.gameObject.SetActive(false);
        }else
        {
            this.gameObject.SetActive(true);
        }
    }

    void ConfirmContract()
    {
        Team currentTeam = BuyScene_Controller.instance.SelectedTeam;
        Player currentPlayer = BuyScene_Controller.instance.SelectedPlayer;

        Contract_model.instance.AddContract(currentTeam.id, currentPlayer.id, currentPlayer.cost);
    }

    
}
