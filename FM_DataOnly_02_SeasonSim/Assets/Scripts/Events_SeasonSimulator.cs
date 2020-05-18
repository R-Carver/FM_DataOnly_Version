using System;
using UnityEngine;

public class Events_SeasonSimulator : MonoBehaviour
{
    public static Events_SeasonSimulator instance;

    private void Awake() {
        
        instance = this;
    }

    public event Action onGameMonthChanged;
    public void GameMonthChanged()
    {
        if(onGameMonthChanged != null)
        {
            onGameMonthChanged();
        }
    }

    public event Action onMonthChanged;
    public void MonthChanged()
    {
        if(onMonthChanged != null)
        {
            onMonthChanged();
        }
    }

    public event Action onMatchDaySet;
    public void MatchDaySet()
    {
        if(onMatchDaySet != null)
        {
            onMatchDaySet();
        }
    }

    public event Action onGameDaySet;
    public void GameDaySet()
    {
        if(onGameDaySet != null)
        {
            onGameDaySet();
        }
    }

    public event Action onMatchDayProcessed;
    public void MatchDayProcessed()
    {
        if(onMatchDayProcessed != null)
        {
            onMatchDayProcessed();
        }
    }

    /*public event Action onGameEventChanged;
    public void GameEventChanged()
    {
        if(onGameEventChanged != null)
        {
            onGameEventChanged();
        }
    }

    public event Action onNewDaySet;
    public void NewDaySet()
    {
        if(onNewDaySet != null)
        {
            onNewDaySet();
        }
    }*/



}
