using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controlls the currently needed team data*/

public class Team_DataManager : MonoBehaviour
{   
    public static Team_DataManager instance;

    private void Awake() {
        
        instance = this;
    }

    public List<Team> currentTeams = new List<Team>();

    // Start is called before the first frame update
    void Start()
    {
        currentTeams = Team_model.instance.GetAllTeams();
    }

    
}
