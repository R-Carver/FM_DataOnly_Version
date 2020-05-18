using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_BuyScene : MonoBehaviour
{
    public static Events_BuyScene instance;

    private void Awake() 
    {
        instance = this;    
    }

    public event Action onTeamChanged;
    public void TeamChanged()
    {
        if(onTeamChanged != null)
        {
            onTeamChanged();
        }
    }

    public event Action onPlayerChanged;
    public void PlayerChanged()
    {
        if(onTeamChanged != null)
        {
            onPlayerChanged();
        }
    }

    public event Action onModeChanged;
    public void ModeChanged()
    {
        if(onModeChanged != null)
        {
            onModeChanged();
        }
    }
}
