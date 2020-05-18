using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Data : MonoBehaviour
{
    public static Position_Data instance;

    private void Awake() 
    {
        instance = this;    
    }

    public Dictionary<PositionName, List<PlayerAttribute>> positionModificators;

    private void Start() 
    {
        InitModifikators();
    }

    void InitModifikators()
    {
        positionModificators = new Dictionary<PositionName, List<PlayerAttribute>>();

        positionModificators.Add(PositionName.Qb, 
            new List<PlayerAttribute>{
                PlayerAttribute.ArmStrength,
                PlayerAttribute.Composure,
                PlayerAttribute.Intuition,
                PlayerAttribute.Concentration
            });

        positionModificators.Add(PositionName.Ol, 
            new List<PlayerAttribute>{
                PlayerAttribute.Strength,
                PlayerAttribute.Balance,
                PlayerAttribute.Controll,
                PlayerAttribute.Height,
                PlayerAttribute.Weight
            });

        positionModificators.Add(PositionName.Rb, 
            new List<PlayerAttribute>{
                PlayerAttribute.Speed,
                PlayerAttribute.Acceleration,
                PlayerAttribute.Balance,
                PlayerAttribute.Controll,
                PlayerAttribute.Intuition
            });

        positionModificators.Add(PositionName.Te, 
            new List<PlayerAttribute>{
                PlayerAttribute.Height,
                PlayerAttribute.Jumping,
                PlayerAttribute.Strength,
                PlayerAttribute.Intelligence,
                PlayerAttribute.Controll
            });

        positionModificators.Add(PositionName.Wr, 
            new List<PlayerAttribute>{
                PlayerAttribute.Speed,
                PlayerAttribute.Jumping,
                PlayerAttribute.Intelligence,
                PlayerAttribute.Controll,
                PlayerAttribute.Height,
                PlayerAttribute.Acceleration
            });
        
        positionModificators.Add(PositionName.K, 
            new List<PlayerAttribute>{
                PlayerAttribute.Controll,
                PlayerAttribute.Balance,
                PlayerAttribute.Concentration,
                PlayerAttribute.Composure
            });
    }
}
