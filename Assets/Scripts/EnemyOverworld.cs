using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOverworld : MonoBehaviour
{
    private GameObject player;
    public GameObject[] players;
    public bool multiplayer;

    // Start is called before the first frame update
    void Start()
    {
        if (multiplayer)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (multiplayer)
        {
            GetClosestPlayer();
        }
    }
    private void GetClosestPlayer()
    {
        float clostest = 10000f;
        for (int i = 0; i < players.Length; i++) 
        {
            float distance = (Vector3.Distance(players[i].transform.position, transform.position));
            if (distance < clostest) 
            { 
                clostest = distance;
                player = players[i];
            }
        }
    }
}
