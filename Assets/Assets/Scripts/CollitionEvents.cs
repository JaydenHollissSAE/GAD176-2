using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollitionEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnter;


    private void OnTriggerEnder(Collider other)
    {
        var player = other.GetComponent<CharacterMovementScript>();
        if (player != null)
        {
            _onTriggerEnter.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
