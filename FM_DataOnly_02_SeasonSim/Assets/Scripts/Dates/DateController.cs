using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DateController : MonoBehaviour
{   
    public static DateController instance;

    private void Awake() {
        
        instance = this;
    }

    private List<DateTime> currentMonthDays;
    public List<DateTime> CurrentMonthDays
    {
        get{return currentMonthDays;}

        protected set
        {
            if(currentMonthDays == value) return;

            currentMonthDays = value;

            Events_SeasonSimulator.instance.MonthChanged();
        }
    }
    int currentMonth = 1;
    int currentYear = 2020;

    // Start is called before the first frame update
    void Start()
    {
        DateTime test = DateTime.Now.Date;
        DayOfWeek test2 = DateTime.Now.DayOfWeek;
        int test3 = DateTime.Now.DayOfYear;
        int test4 = DateTime.Now.Year;

        SetNextMonth();
        
    }

    public void SetNextMonth()
    {
        if(currentMonth > 12)
        {
            Debug.LogError("There is no month int bigger than 12");
            return;
        }

        int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);

        List<DateTime> monthDaysTemp = new List<DateTime>();
        for(int i=1 ; i<=daysInMonth ; i++)
        {
            monthDaysTemp.Add(new DateTime(currentYear, currentMonth, i));
        }

        CurrentMonthDays = monthDaysTemp;

        currentMonth++;

        if(currentMonth == 13)
        {
            currentYear++;
            currentMonth = 1;
        }
    }

    
}
