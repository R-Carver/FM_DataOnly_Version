using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
For this prototype we only cover the offense
*/
public class Position
{
    public PositionName myPosition;
    public List<PlayerAttribute> positionModificators;

    public Position(PositionName pos)
    {
        myPosition = pos;
        positionModificators = Position_Data.instance.positionModificators[pos];
    }

}

public enum PositionName
{
    Qb,
    Ol,
    Rb,
    Wr,
    Te,
    K
}
