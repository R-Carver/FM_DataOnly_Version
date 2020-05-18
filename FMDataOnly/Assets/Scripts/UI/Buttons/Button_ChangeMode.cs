using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_ChangeMode : MonoBehaviour
{   
    public Mode myMode;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ChangeMode());
    }

    void ChangeMode()
    {
        if(BuyScene_Controller.instance.CurrentMode != myMode)
        {
            BuyScene_Controller.instance.CurrentMode = myMode;
        }
    }
    
}
