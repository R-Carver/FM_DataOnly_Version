using UnityEngine;

public class Model_initializer : MonoBehaviour
{   
    private Team_model db_team;
    //private Player_model db_player;
    //private Contract_model db_contract;

    //for testing in editor the datapath is Application.dataPath
    //on the device later this might be Application.persistentDataPath
    string datapath;
    private void Awake() 
    {   
        datapath = Application.dataPath;

        new Team_model(datapath);
        new Player_model(datapath);
        new Contract_model(datapath);
        //new Contract_model();    
    }

    private void OnDestroy() 
    {
        //close the db connections
        Team_model.instance.CloseConnection();
        Player_model.instance.CloseConnection();
        Contract_model.instance.CloseConnection();

    }
}