using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortObjects : IComparable
{
    public string name;
    public int price;

    public int CompareTo(Object obj)
    {
        int value = price - ((SortObjects)obj).price;

        return value;
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
