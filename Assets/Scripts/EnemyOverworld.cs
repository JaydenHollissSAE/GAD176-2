using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOverworld : MonoBehaviour
{
    private GameObject player;
    public GameObject[] players;
    public bool multiplayer;
    [SerializeField] private bool edgeGuard;
    [SerializeField] private float maxDropDistance = 2.0f;

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
        EdgeGuard();
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
    private void EdgeGuard()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.distance);
            if (hit.distance < maxDropDistance)
            {
                Debug.Log("This is an acceptable height to walk down from");
            }
            else
            {
                Debug.Log("NOPE! NOPE!! NOPE!!! NOPE! NOPE!! NOPE!!!");
            }
            
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //Debug.Log("I am working guys, trust me");
        }
        else
        {
            Debug.Log("NOPE! NOPE!! NOPE!!! NOPE! NOPE!! NOPE!!!");
        }

    }
}
