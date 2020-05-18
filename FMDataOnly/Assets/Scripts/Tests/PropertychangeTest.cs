using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertychangeTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            Team someTeam = Team_DataManager.instance.currentTeams[0];
            someTeam.Capspace -= 50;
            Debug.Log("Mops");
        }
    }
}
