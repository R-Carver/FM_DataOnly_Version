using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFM_GameEvent
{
    public string name;
    public EventType myEventType;

    public AFM_GameEvent(string name)
    {
        this.name = name;
    }
}

public enum EventType
{
    Match
}
