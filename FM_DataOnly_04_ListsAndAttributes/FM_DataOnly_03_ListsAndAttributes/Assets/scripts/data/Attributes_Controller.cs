using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Attributes_Controller : MonoBehaviour
{
    public static Attributes_Controller instance;

    private void Awake() 
    {
        instance = this;    
    }

    private void Start()
    {
        Attributes test = GetRandomAttributeSet(new Position(PositionName.Wr));
    }

    public Attributes GetRandomAttributeSet(Position pos)
    {
        Attributes tempAttr = new Attributes();

        //first generate the random attr value and then check if the position
        //modifier applies

        //JUMPING
        if(pos.positionModificators.Contains(PlayerAttribute.Jumping))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.jumping = clampedValue;
        }else
        {
            tempAttr.jumping = getRandomBaseAttr();
        }

        //STRENGTH
        if(pos.positionModificators.Contains(PlayerAttribute.Strength))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.strength = clampedValue;
        }else
        {
            tempAttr.strength = getRandomBaseAttr();
        }

        //SPEED
        if(pos.positionModificators.Contains(PlayerAttribute.Speed))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.speed = clampedValue;
        }else
        {
            tempAttr.speed = getRandomBaseAttr();
        }

        //ACCELERATION
        if(pos.positionModificators.Contains(PlayerAttribute.Acceleration))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.acceleration = clampedValue;
        }else
        {
            tempAttr.acceleration = getRandomBaseAttr();
        }

        //BALANCE
        if(pos.positionModificators.Contains(PlayerAttribute.Balance))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.balance = clampedValue;
        }else
        {
            tempAttr.balance = getRandomBaseAttr();
        }

        //CONTROLL
        if(pos.positionModificators.Contains(PlayerAttribute.Controll))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.controll = clampedValue;
        }else
        {
            tempAttr.controll = getRandomBaseAttr();
        }

        //ARMSTRENGTH
        if(pos.positionModificators.Contains(PlayerAttribute.ArmStrength))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.armStrength = clampedValue;
        }else
        {
            tempAttr.armStrength = getRandomBaseAttr();
        }

        //HEIGHT
        if(pos.positionModificators.Contains(PlayerAttribute.Height))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.height = clampedValue;
        }else
        {
            tempAttr.height = getRandomBaseAttr();
        }

        //WEIGHT
        if(pos.positionModificators.Contains(PlayerAttribute.Weight))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.weight = clampedValue;
        }else
        {
            tempAttr.weight = getRandomBaseAttr();
        }

        //INTELLIGENCE
        if(pos.positionModificators.Contains(PlayerAttribute.Intelligence))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.intelligence = clampedValue;
        }else
        {
            tempAttr.intelligence = getRandomBaseAttr();
        }

        //LEADERSHIP
        if(pos.positionModificators.Contains(PlayerAttribute.Leadership))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.leadership = clampedValue;
        }else
        {
            tempAttr.leadership = getRandomBaseAttr();
        }

        //COMPOSURE
        if(pos.positionModificators.Contains(PlayerAttribute.Composure))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.composure = clampedValue;
        }else
        {
            tempAttr.composure = getRandomBaseAttr();
        }

        //INTUITION
        if(pos.positionModificators.Contains(PlayerAttribute.Intuition))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.intuition = clampedValue;
        }else
        {
            tempAttr.intuition = getRandomBaseAttr();
        }

        //BRAVERY
        if(pos.positionModificators.Contains(PlayerAttribute.Bravery))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.bravery = clampedValue;
        }else
        {
            tempAttr.bravery = getRandomBaseAttr();
        }

        //ADAPTABILITY
        if(pos.positionModificators.Contains(PlayerAttribute.Adaptability))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.adaptability = clampedValue;
        }else
        {
            tempAttr.adaptability = getRandomBaseAttr();
        }

        //Learning
        if(pos.positionModificators.Contains(PlayerAttribute.Lerning))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.learning = clampedValue;
        }else
        {
            tempAttr.learning = getRandomBaseAttr();
        }

        //CONCENTRATION
        if(pos.positionModificators.Contains(PlayerAttribute.Concentration))
        {   
            int modifiedAttr = Mathf.RoundToInt((getRandomBaseAttr() * Random.Range(1.0f, 2.0f)));
            int clampedValue = Mathf.Min(99, modifiedAttr);
            tempAttr.concentration = clampedValue;
        }else
        {
            tempAttr.concentration = getRandomBaseAttr();
        }

        return tempAttr;
    }

    private int getRandomBaseAttr()
    {   
        //the values for the non position attributes shouldnt be to high
        return Random.Range(1, 70);
    }
}
