using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject InvView;
    public GameObject BattleStatsView;
    public GameObject BattleInvView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BattleInvButton()
    {
        //function that is activated with the click of the inventory button
        //hides stats panel and shows inventory, or visceversa
        BattleStatsView.SetActive(!BattleStatsView.activeInHierarchy);
        BattleInvView.SetActive(!BattleInvView.activeInHierarchy);
    }
    public void OverworldInvButton()
    {
        InvView.SetActive(!InvView.activeInHierarchy);
    }
}
