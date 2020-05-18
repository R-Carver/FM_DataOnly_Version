using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        //StartCoroutine(GeneratePlayer());
        //StartCoroutine(Generate100Players());
    }

    IEnumerator GeneratePlayer()
    {   
        yield return new WaitUntil(() => Position_Controller.instance.allPositions.Count > 0);

        Player p1 = new Player(Position_Controller.instance.allPositions[PositionName.Qb]);
        Player p2 = new Player(Position_Controller.instance.allPositions[PositionName.Ol]);  
        Player p3 = new Player(Position_Controller.instance.allPositions[PositionName.Qb]);  
        Player p4 = new Player(Position_Controller.instance.allPositions[PositionName.Wr]);  
        Player p5 = new Player(Position_Controller.instance.allPositions[PositionName.Rb]);  

        Player_model.instance.AddPlayer(p1);
        Player_model.instance.AddPlayer(p2);
        Player_model.instance.AddPlayer(p3);
        Player_model.instance.AddPlayer(p4);
        Player_model.instance.AddPlayer(p5);    
    }

    IEnumerator Generate100Players()
    {
        yield return new WaitUntil(() => Position_Controller.instance.allPositions.Count > 0);

        for(int i=0; i<100 ; i++)
        {
            //get player with random position
            int randomPosIndex = Random.Range(0, 6);
            PositionName randomPos = (PositionName)randomPosIndex;
            Player newPlayer = new Player(Position_Controller.instance.allPositions[randomPos]);

            //save player to db
            Player_model.instance.AddPlayer(newPlayer);
        }
    }

    
}
