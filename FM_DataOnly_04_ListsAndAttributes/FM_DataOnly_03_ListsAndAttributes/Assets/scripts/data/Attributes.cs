using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The attributes of a Player. They determine other player values like the skills
*/

public class Attributes
{   
    [FmDbField]
    [Range(0,99)]
    public int jumping;
    [FmDbField]
    [Range(0,99)]
    public int strength;
    [FmDbField]
    [Range(0,99)]
    public int speed;
    [FmDbField]
    [Range(0,99)]
    public int acceleration;
    [FmDbField]
    [Range(0,99)]
    public int balance;
    [FmDbField]
    [Range(0,99)]
    public int controll;
    [FmDbField]
    [Range(0,99)]
    public int armStrength;
    [FmDbField]
    [Range(0,99)]
    public int height;
    [FmDbField]
    [Range(0,99)]
    public int weight;
    [FmDbField]
    [Range(0,99)]
    public int intelligence;
    [FmDbField]
    [Range(0,99)]
    public int leadership;
    [FmDbField]
    [Range(0,99)]
    public int composure;
    [FmDbField]
    [Range(0,99)]
    public int intuition;
    [FmDbField]
    [Range(0,99)]
    public int bravery;
    [FmDbField]
    [Range(0,99)]
    public int adaptability;
    [FmDbField]
    [Range(0,99)]
    public int learning;
    [FmDbField]
    [Range(0,99)]
    public int concentration;

    public Dictionary<PlayerAttribute, int> nameToAttribute;

    public Attributes(){}

    public Attributes(int jumping, int strength, int speed, int acceleration, int balance, int controll, int armStrength, int height, int weight, int intelligence, int leadership, int composure, int intuition, int bravery, int adaptability, int learning, int concentration)
    {
        this.jumping = jumping;
        this.strength = strength;
        this.speed = speed;
        this.acceleration = acceleration;
        this.balance = balance;
        this.controll = controll;
        this.armStrength = armStrength;
        this.height = height;
        this.weight = weight;
        this.intelligence = intelligence;
        this.leadership = leadership;
        this.composure = composure;
        this.intuition = intuition;
        this.bravery = bravery;
        this.adaptability = adaptability;
        this.learning = learning;
        this.concentration = concentration;

        CreateAttrDict();
    }

    public void CreateAttrDict()
    {
        nameToAttribute = new Dictionary<PlayerAttribute, int>();

        nameToAttribute.Add(PlayerAttribute.Jumping, this.jumping);
        nameToAttribute.Add(PlayerAttribute.Strength, this.strength);
        nameToAttribute.Add(PlayerAttribute.Speed, this.speed);
        nameToAttribute.Add(PlayerAttribute.Acceleration, this.acceleration);
        nameToAttribute.Add(PlayerAttribute.Balance, this.balance);
        nameToAttribute.Add(PlayerAttribute.Controll, this.controll);
        nameToAttribute.Add(PlayerAttribute.ArmStrength, this.armStrength);
        nameToAttribute.Add(PlayerAttribute.Height, this.height);
        nameToAttribute.Add(PlayerAttribute.Weight, this.weight);
        nameToAttribute.Add(PlayerAttribute.Intelligence, this.intelligence);
        nameToAttribute.Add(PlayerAttribute.Leadership, this.leadership);
        nameToAttribute.Add(PlayerAttribute.Composure, this.composure);
        nameToAttribute.Add(PlayerAttribute.Intuition, this.intuition);
        nameToAttribute.Add(PlayerAttribute.Bravery, this.bravery);
        nameToAttribute.Add(PlayerAttribute.Adaptability, this.adaptability);
        nameToAttribute.Add(PlayerAttribute.Lerning, this.learning);
        nameToAttribute.Add(PlayerAttribute.Concentration, this.concentration);

    }

}
