using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListLoader_Team : MonoBehaviour
{   
    public GameObject listItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitList());
    }

    IEnumerator InitList()
    {   
        //wait until the teamdata manager has the teams loaded from db
        yield return new WaitUntil(() => Team_DataManager.instance.currentTeams.Count > 0);

        List<Team> allTeams = Team_DataManager.instance.currentTeams;

        foreach(Team team in allTeams)
        {
            GameObject listItem = Instantiate(listItemPrefab);

            listItem.transform.SetParent(this.transform, false);

            //set the listitem content
            ListItem_Team item = listItem.GetComponent<ListItem_Team>();
            item.SetTeamname(team.name);
            item.SetCapSpace(team.Capspace);

            team.propertyListeners.Add(item);

            Button teamBtn = listItem.GetComponent<Button>();
            teamBtn.onClick.AddListener(() => ChangeTeam(team));
        }

        void ChangeTeam(Team newTeam)
        {
            BuyScene_Controller.instance.SelectedTeam = newTeam;
        }
    }
}
