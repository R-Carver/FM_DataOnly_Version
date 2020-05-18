using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public Position position;
    public Attributes attributes;
    public Skills skills;

    public Player(Position position)
    {   
        this.position = position;

        //get a new name
        name = NameHelper.instance.GetNewName();

        //generate a set of attributes
        attributes = Attributes_Controller.instance.GetRandomAttributeSet(this.position);
        attributes.CreateAttrDict();

        //calculate the skills from the attributes
        skills = new Skills(attributes);
    }
}
