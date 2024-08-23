using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject InvView;
    public GameObject BattleStatsView;
    public GameObject BattleInvView;
    public TMP_Text HealthDisplay;
    public Vector2 buttonJumpHeight = new Vector2 ( 0, 30);
    
    [SerializeField] Button skillOneButton, skillTwoButton, skillThreeButton, inventoryButton;
    public Vector2 buttonPosition = new Vector2() ;

    // Start is called before the first frame update
    void Start()
    {
        skillOneButton.onClick.AddListener(delegate { ButtonPosition(skillOneButton.transform); }) ;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    if (clickedObj.pointerPress != skillOneButton || clickedObj.pointerPress == null)
        //    {
        //        return;
        //    }
        //    Debug.Log("Click detected!");
        //}
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
    public void HealthDisplayUpdater()
    {
        //Will fetch current health & max health and update the health display on the battle UI
        // IMPORTANT!!! current health & max health still to be added after player stats are complete
        HealthDisplay.text = ("HP:");
    }
    public void ButtonPosition( Transform buttonTransform)
    {
        Debug.Log(buttonTransform.position);
        Vector2 pos = buttonTransform.position;
        pos += buttonJumpHeight;
        buttonTransform.position = pos;

    }
    public void ButtonJump()
    {
        Debug.Log("Button Jump" + buttonPosition);
    }

}
