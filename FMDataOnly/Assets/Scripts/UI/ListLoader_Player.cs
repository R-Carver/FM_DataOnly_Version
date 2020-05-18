using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListLoader_Player : MonoBehaviour
{   
    public GameObject listItemPrefab;
    List<Player> currentSelection;
    // Start is called before the first frame update
    void Start()
    {
        currentSelection = Player_model.instance.GetFreeAgents();
        PopulateList();

        Events_BuyScene.instance.onTeamChanged += ChangeCurrentSelection;
        Events_BuyScene.instance.onModeChanged += ChangeCurrentSelection;
    }

    void ChangeCurrentSelection()
    {   
        //if in see Team mode get the specific players
        if(BuyScene_Controller.instance.CurrentMode == Mode.SeeTeam)
        {
            Team currentTeam = BuyScene_Controller.instance.SelectedTeam;
            if(currentTeam != null)
            {
                currentSelection = Player_model.instance.GetPlayersByTeam(currentTeam.id);
            }else
            {
                //set to empty list
                currentSelection = new List<Player>(); 
            }
            

        }else if(BuyScene_Controller.instance.CurrentMode == Mode.buyPlayers)
        {   
            //if in buy mode always show all free agents
            currentSelection = Player_model.instance.GetFreeAgents();
        }
        PopulateList();
        
    }

    void PopulateList()
    {   
        //remove all list elems first
        foreach(Transform listItem in this.transform)
        {
            Destroy(listItem.gameObject);
        }

        foreach(Player player in currentSelection)
        {
            GameObject listItem = Instantiate(listItemPrefab);

            listItem.transform.SetParent(this.transform, false);

            //set the listitem content
            ListItem_Player item =  listItem.GetComponent<ListItem_Player>();
            item.SetPlayername(player.name);
            item.SetPosition(player.position);
            item.SetCost(player.cost);

            Button playerBtn = listItem.GetComponent<Button>();
            playerBtn.onClick.AddListener(() => ChangePlayer(player));
        }

        void ChangePlayer(Player player)
        {
            BuyScene_Controller.instance.SelectedPlayer = player;
        }
    }

    
}
