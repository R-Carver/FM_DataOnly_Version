using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Controller : MonoBehaviour
{
    public static Position_Controller instance;

    private void Awake() 
    {
        instance = this;    
    }

    private void Start() 
    {
        InitPositions();    
    }

    // we need each position once
    public Dictionary<PositionName, Position> allPositions = new Dictionary<PositionName, Position>();
    // just a helper dict to get the posName by string

    void InitPositions()
    {   
        allPositions.Add(PositionName.Qb, new Position(PositionName.Qb));
        allPositions.Add(PositionName.Ol, new Position(PositionName.Ol));
        allPositions.Add(PositionName.Rb, new Position(PositionName.Rb));
        allPositions.Add(PositionName.Wr, new Position(PositionName.Wr));
        allPositions.Add(PositionName.Te, new Position(PositionName.Te));
        allPositions.Add(PositionName.K, new Position(PositionName.K));
    }
}
