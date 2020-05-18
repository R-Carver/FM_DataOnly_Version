using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text_PlayerCost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events_BuyScene.instance.onPlayerChanged += SetText;
    }

    void SetText()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        string cost = BuyScene_Controller.instance.SelectedPlayer.cost.ToString();
        text.text = "Player Cost: " + cost;
    }
}
