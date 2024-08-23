using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIRaycaster : MonoBehaviour
{
    GraphicRaycaster Ray;
    PointerEventData CursorData;
    public TMP_Text SkillStatDisplay;
    public string currentRay;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch Raycaster and Event System
        Ray = GetComponent<GraphicRaycaster>();

    }

    // Update is called once per frame
    void Update()
    {
        CursorData = new PointerEventData(EventSystem.current);
        CursorData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        Ray.Raycast(CursorData, results);
        foreach (RaycastResult result in results)
        {
            currentRay = result.gameObject.name;
            //Debug.Log(currentRay);
            //Debug.Log(result.gameObject.name);
            if (result.gameObject.name == "SkillText1")
            {
                SkillStatDisplay.text = ("Displaying Stats 1");
               // Debug.Log("Skill1Hit");
            } else if (result.gameObject.name == "SkillButton2")
            {
                SkillStatDisplay.text = ("Displaying Stats 2");
               // Debug.Log("Skill2Hit");
            } else if (result.gameObject.name == "SkillButton3")
            {
                SkillStatDisplay.text = ("Displaying Stats 3");
                //Debug.Log("Skill3Hit");
            }
        }
    }
}
