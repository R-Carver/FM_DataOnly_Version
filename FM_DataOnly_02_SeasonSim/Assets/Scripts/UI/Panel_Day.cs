using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Day : MonoBehaviour
{
    private AFM_GameDay myGameDay;
    public AFM_GameDay MyGameDay
    {
        get{return myGameDay;}
        set
        {
            if(myGameDay == value) return;
            if(myGameDay == null)
            {
                myGameDay = value;
                myGameDay.onNewDaySet += ChangeColor;
                myGameDay.onGameEventChanged += ChangeEventText;    
            }
            myGameDay = value;
        }
    }

    Color defaultColor = new Color(1f, 1f, 1f, 0.3f);
    Color selectedColor = new Color(0.9f, 0.55f, 0.1f, 0.3f);


    private void Start() {
        
        
        //eventText = transform.Find("Text_Event").GetComponent<TextMeshProUGUI>();
    }

    void ChangeColor()
    {
        if(myGameDay.IsCurrent)
        {
            GetComponent<Image>().color = selectedColor;
        }else
        {
            GetComponent<Image>().color = defaultColor;
        }
    }

    void ChangeEventText()
    {   
        if(myGameDay.GameEvent != null)
        {
            TextMeshProUGUI eventText = transform.Find("Text_Event").GetComponent<TextMeshProUGUI>();
            eventText.text = myGameDay.GameEvent.name;
        }
    }

    public void InitPanel()
    {   
        TextMeshProUGUI dateText = transform.Find("Text_Date").GetComponent<TextMeshProUGUI>();
        dateText.text = myGameDay.day.ToShortDateString();

        TextMeshProUGUI eventText = transform.Find("Text_Event").GetComponent<TextMeshProUGUI>();
        eventText.text = "";
    }

    
}
