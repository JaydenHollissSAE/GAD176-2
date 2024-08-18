using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GAD176.ProjectRPG
{
    public class EnemyOverworld : MonoBehaviour
    {
        public GameObject player;
        public GameObject[] players;
        public bool multiplayer;
        [SerializeField] private bool edgeGuard;
        [SerializeField] private float maxDropDistance = 2.0f;
        public float detectDistance = 10f;
        [SerializeField] public NavMeshAgent agent;
        public bool trackingOverride = false;


        // Start is called before the first frame update
        public void Start()
        {

            players = GameObject.FindGameObjectsWithTag("Player");
            GetClosestPlayer();
        }

        // Update is called once per frame
        void Update()
        {
            if (multiplayer)
            {
                if (!trackingOverride)
                {
                    GetClosestPlayer();
                }
            }
            if (edgeGuard)
            {
                EdgeGuard();
            }
            if ((Vector3.Distance(player.transform.position, transform.position)) < detectDistance)
            {
                MoveTowardsPlayer();

            }


        }
        protected void GetClosestPlayer()
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
        private void MoveTowardsPlayer()
        {
            agent.SetDestination(player.transform.position);
            //transform.LookAt(player.transform.position);
            //RaycastHit hitForward;
            //RaycastHit hitLeft;
            //RaycastHit hitRight;
            //RaycastHit hitBack;
            //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitForward, Mathf.Infinity))
            //{
            //    if (!(hitForward.distance < 1.5f))
            //    {
            //        Debug.Log(hitForward.transform.gameObject.name);
            //        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 5.5f);
            //    }
            //}
            //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, Mathf.Infinity);
            //if (!(hitLeft.distance < 1.5f))
            //{
            //    Debug.Log(hitLeft.transform.gameObject.name);
            //    transform.position = Vector3.MoveTowards(transform.position, Vector3.left, Time.deltaTime * 5.5f);
            //}
            //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, Mathf.Infinity);
            //if (!(hitRight.distance < 1.5f))
            //{
            //    Debug.Log(hitRight.transform.gameObject.name);
            //    transform.position = Vector3.MoveTowards(transform.position, Vector3.right, Time.deltaTime * 5.5f);
            //}
            //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitBack, Mathf.Infinity);
            //if (!(hitBack.distance < 1.5f))
            //{
            //    Debug.Log(hitBack.transform.gameObject.name);
            //    transform.position = Vector3.MoveTowards(transform.position, Vector3.back, Time.deltaTime * 5.5f);
            //}
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
}