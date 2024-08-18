using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GAD176.ProjectRPG
{
    public class EnemyRunToPlayer : EnemyOverworld
    {

        // Start is called before the first frame update
        void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(Vector3.Distance(gameObject.transform.position, player.transform.position));
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 20f)
            {
                agent.speed = 50f;
            }
            else
            {
                agent.speed = 3.5f;
            }
        }
    }
}