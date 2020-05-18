using System;

public class AFM_GameDay
{
    public DateTime day;

    private AFM_GameEvent gameEvent;
    public AFM_GameEvent GameEvent
    {
        get{return gameEvent;}

        set
        {
            if(gameEvent == value)
            {
                return;
            }
            gameEvent = value;

            GameEventChanged();
        }
    }

    private bool isCurrent = false;
    public bool IsCurrent
    {
        get{return isCurrent;}
        set
        {
            if(isCurrent == value)
            {
                return;
            }
            isCurrent = value;

            NewDaySet();
        }
    }

    public AFM_GameDay(DateTime day)
    {
        this.day = day;
    }

    public event Action onGameEventChanged;
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
    }
    
}
