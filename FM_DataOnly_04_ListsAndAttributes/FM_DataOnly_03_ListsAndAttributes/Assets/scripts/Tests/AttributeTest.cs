using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttributeTest : MonoBehaviour
{
    
}

public class Testclass
{   
    [FmDbField]
    int field1;
    [FmDbField]
    float field2;
    [FmDbField]
    string field3;

    int otherField;

}

[AttributeUsage(AttributeTargets.Field)]
public class FmDbField : Attribute {}
