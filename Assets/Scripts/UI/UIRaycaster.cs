using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIRaycaster : MonoBehaviour
{
    GraphicRaycaster Ray;
    PointerEventData CursorData;
    EventSystem EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch Raycaster and Event System
        Ray = GetComponent<GraphicRaycaster>();
        EventSystem = GetComponent<EventSystem>();

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
            //Debug.Log(result.gameObject.name);
            if (result.gameObject.name == "SkillButton1")
            {
                Debug.Log("Skill1Hit");
            } else if (result.gameObject.name == "SkillButton2")
            {
                Debug.Log("Skill2Hit");
            } else if (result.gameObject.name == "SkillButton3")
            {
                Debug.Log("Skill3Hit");
            }
        }
    }
}
