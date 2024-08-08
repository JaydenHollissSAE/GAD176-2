using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemPickUp : MonoBehaviour
{
    public GameObject Item;
    
    void Pickup()
    {
        S_InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }

}
