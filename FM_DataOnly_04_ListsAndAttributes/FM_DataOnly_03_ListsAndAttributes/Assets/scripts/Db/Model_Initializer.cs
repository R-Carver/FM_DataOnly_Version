using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Initializer : MonoBehaviour
{
    string datapath;
    private void Start() 
    {
        datapath = Application.dataPath;

        new Player_model(datapath);    
    }
}
