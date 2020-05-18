using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class ReflectionTest : MonoBehaviour
{
    

    private void Start() 
    {
        

         TestDbStringCreation();
    }

    void TestDbStringCreation()
    {
        TestClass2 testInstance = new TestClass2(1, 2, "viech", 3);

        List<FieldInfo> fields = getObjectDbFields(testInstance);

        string dbString = "INSERT INTO Sometable (" ;
        string valueString = ") VALUES (";
        
        foreach(FieldInfo field in fields)
        {
            dbString += field.Name + ",";
            if(field.FieldType == typeof(string))
            {
                valueString += "\"" + field.GetValue(testInstance) + "\",";
            }else
            {
                valueString += field.GetValue(testInstance) + ",";
            }
            
        }

        //remove last ,
        dbString = dbString.Substring(0, dbString.Length-1);
        valueString = valueString.Substring(0, valueString.Length-1);
        dbString += valueString;

        dbString += ")";


    }

    void TestClassFields()
    {
        FieldInfo[] fields2 = typeof(TestClass2).GetFields();

        foreach(FieldInfo field in fields2)
        {
            FmDbField dbAnnotation = Attribute.GetCustomAttribute(field, typeof(FmDbField)) as FmDbField;

            if(dbAnnotation != null)
            {
                //later... save to db
                Debug.Log(field.Name);
            }
        }
    }

    public List<FieldInfo> getObjectDbFields(object obj)
    {   
        FieldInfo[] fields = obj.GetType().GetFields();

        List<FieldInfo> outList = new List<FieldInfo>();

        foreach(FieldInfo field in fields)
        {
            FmDbField dbAnnotation = Attribute.GetCustomAttribute(field, typeof(FmDbField)) as FmDbField;

            if(dbAnnotation != null)
            {
                outList.Add(field);
            }
        }

        return outList;
    }
    
}

public class TestClass2
{   
    [FmDbField]
    public int field1;
    [FmDbField]
    public int field2;

    [FmDbField]
    public string stringField;

    public int field3;

    public TestClass2(int field1, int field2, string stringField, int field3)
    {
        this.field1 = field1;
        this.field2 = field2;
        this.stringField = stringField;
        this.field3 = field3;
    }
}


