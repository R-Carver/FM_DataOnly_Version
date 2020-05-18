using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SeasonController : MonoBehaviour
{   
    public static SeasonController instance;

    private void Awake() {

        instance = this;
    }

    private List<AFM_GameDay> gameDaysCurrentMonth;
    public List<AFM_GameDay> GameDaysCurrentMonth
    {
        get {return gameDaysCurrentMonth;}

        protected set
        {
            if(gameDaysCurrentMonth == value) return;

            gameDaysCurrentMonth = value;

            Events_SeasonSimulator.instance.GameMonthChanged();
        }
    }

    public AFM_GameDay currentDay;
    public AFM_GameDay CurrentDay
    {
        get{return currentDay;}

        set
        {
            if(currentDay == value) return;

            currentDay = value;
            Events_SeasonSimulator.instance.GameDaySet();
        }
    }

    private void Start() {
        
        Events_SeasonSimulator.instance.onMonthChanged += PrepareNextMonth;
        PrepareNextMonth();
        
    }


    void PrepareNextMonth()
    {
        List<DateTime> newDays = DateController.instance.CurrentMonthDays;

        List<AFM_GameDay> tempList = new List<AFM_GameDay>();    

        foreach(DateTime day in newDays)
        {
            tempList.Add(new AFM_GameDay(day));
        }

        GameDaysCurrentMonth = tempList;

        //set the first day of the month as current day
        CurrentDay = GameDaysCurrentMonth[0];
        currentDay.IsCurrent = true;

        //here you might set the events for the next month
        SetGameEvents();
    }

    void SetGameEvents()
    {
        //later we would have some other mechanism which creates some events
        //or reads others from some config file, but for now we just simulate
        //the matchdays

        var aSunday = DayOfWeek.Sunday;

        var sundays = GameDaysCurrentMonth.Where(d => d.day.DayOfWeek == aSunday);

        foreach(AFM_GameDay day in sundays)
        {
            day.GameEvent = new AFM_GameEvent("Matchday");
        }
    }

    public void NextDay()
    {
        //remove the flag from the current day
        currentDay.IsCurrent = false;

        int nextDayIndex = GameDaysCurrentMonth.IndexOf(currentDay);

        if(nextDayIndex + 1 >= GameDaysCurrentMonth.Count)
        {
            //end of month reached
            DateController.instance.SetNextMonth();
            return;
        }

        CurrentDay = GameDaysCurrentMonth[nextDayIndex + 1];
        currentDay.IsCurrent = true;

        PrepareNextDay();
    }

    void PrepareNextDay()
    {
        //if a matchday set the next matchday
        if(currentDay.GameEvent != null)
        {
            if(currentDay.GameEvent.myEventType == EventType.Match)
            {
                MatchDayController.instance.GetNextMatchDay();
            }
        }
        
    }
}
