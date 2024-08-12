using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int attack;
    public int armor;

    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //for testing delete later
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 1;
        }
        if //(however attacking works)
        {
            //armor here
            currentHealth -= attack;
        }
       
        //Delete enemy model on death
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
   

    public void TakeDamage(int amount)
    {
        //change amount to what ever player attack is called
        //currentHealth -= amount;
       
           
    }
    

   
}
