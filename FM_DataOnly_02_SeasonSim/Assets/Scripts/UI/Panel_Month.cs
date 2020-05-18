using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Month : MonoBehaviour
{   
    public GameObject dayPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Events_SeasonSimulator.instance.onGameMonthChanged += InitNewMonth;
        InitNewMonth();
    }

    void InitNewMonth()
    {   
        DestroyPrevMonth();

        List<AFM_GameDay> nextMonthDays = SeasonController.instance.GameDaysCurrentMonth;

        if(nextMonthDays != null)
        {
            foreach (AFM_GameDay day in nextMonthDays)
            {
                GameObject dayGo = Instantiate(dayPrefab);

                dayGo.transform.SetParent(this.transform, false);

                dayGo.AddComponent<Panel_Day>();

                Panel_Day tempday = dayGo.GetComponent<Panel_Day>();
                tempday.MyGameDay = day;
                tempday.InitPanel();
            }
        }
    }

    void DestroyPrevMonth()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
