using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NameHelper : MonoBehaviour
{   
    public static NameHelper instance;

    private void Awake() 
    {
        instance = this;    
    }

    public TextAsset namesRaw;
    string[] namesArray;
    int currentNameIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        string namesTest = namesRaw.text;
        namesArray = Regex.Split(namesRaw.text, "\n");
    }

    public string GetNewName()
    {   
        if(currentNameIndex < namesArray.Length)
        {
            return namesArray[currentNameIndex++];
        }else
        {
            Debug.LogError("No Names left");
            return null;
        }
        
    }

    
}
