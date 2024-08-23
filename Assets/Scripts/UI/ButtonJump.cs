using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonJump : MonoBehaviour
{
    protected UnityEvent buttonClick = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        buttonClick.AddListener(OnButtonJump);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (buttonClick != null)
        {
            buttonClick.Invoke();
            Debug.Log("Invoked");
        }
        else
        {
            Debug.Log("Null");
        }
    }
    private void OnMouseUp()
    {
        if (buttonClick != null)
        {
            buttonClick.RemoveAllListeners();  
        }
    }
    void OnButtonJump()
    {
        Debug.Log("Jump");
    }
}
