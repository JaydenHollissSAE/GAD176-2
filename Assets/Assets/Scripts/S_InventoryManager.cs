using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InventoryManager : MonoBehaviour
{
    public static S_InventoryManager Instance;
    public List<GameObject> Item = new List<GameObject>();
    public void Awake()
    {
        Instance = this;
    }

    public void Add(GameObject item)
    {
        Item.Add(item);
    }

    public void Remove(GameObject item)
    {
        Item.Remove(item);
    }
}
