using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_NextDay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(NextDay);
    }

    void NextDay()
    {
        SeasonController.instance.NextDay();
    }

    
}
