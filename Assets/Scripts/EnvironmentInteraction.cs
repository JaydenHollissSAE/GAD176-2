using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


namespace GAD176.ProjectRPG
{
    public class EnvironmentInteraction : MonoBehaviour
    {
        // assumes a class exists for environmental items
        [SerializeField] private InteractableItem interactableItem;
        // assumes a player class exists
        [SerializeField] private GameObject playerCamera;
        [SerializeField] private GameObject lastInteractable;
        [SerializeField] private LayerMask environmentItems;


        private void Update()
        {
            CheckObjectInFront();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(lastInteractable);
            }
        }



        private void Interact(GameObject item)
        {
            if(hitObject.isInteract) { 
                // logic to execute when interacted with
            }
        }

        private void CheckObjectInFront()
        {
            RaycastHit hit;
            // assumes a player camera exists; looks for an object 5m ahead
            Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5f, environmentItems);
            GameObject hitObject = hit.transform.gameObject;
            if (!hit.collider)
            {
                lastInteractable = null;
            }
            if (lastInteractable != hitObject)
            {
                MakeUninteractable(lastInteractable);
                lastInteractable = hitObject;
            }
            MakeInteractable(hitObject);
        }

        private void MakeInteractable(GameObject item)
        {
            if (!item) { return; }
            // logic for changing item's shaders, etc. to highlight interactability...
        }

        private void MakeUninteractable(GameObject item)
        {
            if (!item) { return; }
            // opposite of the other function obviously.
        }
    }
}