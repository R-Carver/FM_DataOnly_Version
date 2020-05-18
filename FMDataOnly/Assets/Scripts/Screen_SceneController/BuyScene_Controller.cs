using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyScene_Controller : MonoBehaviour
{   
    public static BuyScene_Controller instance;

    private void Awake() 
    {
        instance = this;
        CurrentMode = Mode.buyPlayers;
    }

    private Team selectedTeam;
    public Team SelectedTeam
    {
        get{return selectedTeam;}
        set
        {
            if(selectedTeam == value)
            {
                return;
            }
            selectedTeam = value;
            Events_BuyScene.instance.TeamChanged();
        }
    }

    private Player selectedPlayer;
    public Player SelectedPlayer
    {
        get{return selectedPlayer;}
        set
        {
            if(selectedPlayer == value)
            {
                return;
            }
            selectedPlayer = value;
            Events_BuyScene.instance.PlayerChanged();
        }
    }

    private Mode currentMode;
    public Mode CurrentMode
    {
        get{return currentMode;}
        set
        {
            if(currentMode == value)
            {
                return;
            }
            currentMode = value;
            Events_BuyScene.instance.ModeChanged();

            //reset the chosen player each time you go to buy mode
            if(currentMode == Mode.buyPlayers)
            {
                SelectedPlayer = null;
            }
        }
    }
}

public enum Mode
{
    buyPlayers,
    SeeTeam
}
