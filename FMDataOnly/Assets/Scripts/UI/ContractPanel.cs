using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events_BuyScene.instance.onModeChanged += SetPanel;
        SetPanel();
    }

    void SetPanel()
    {   
        this.gameObject.SetActive(false);

        if(BuyScene_Controller.instance.CurrentMode == Mode.buyPlayers)
        {
            this.gameObject.SetActive(true);
        }
    }

    
}
