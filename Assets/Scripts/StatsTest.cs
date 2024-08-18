using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GAD176.ProjectRPG
{
    public class StatsTest : MonoBehaviour
    {
        public string job; //
        public int maxHealth; //
        public int health; //
        public int healThreshold;
        public int healingPower;
        public int aoeDamage;
        public int singleDamage;
        public string status; //
        public string type; //
        public List<string> statusAttack = new List<string>();


        //public void DisplayStats()
        //{
        //    Debug.Log(type + " " + job);
        //    Debug.Log("Health = " + health + "/" + maxHealth);
        //    if (status != null )
        //    {
        //        Debug.Log("Status = " + status);
        //    }
        //    else
        //    {
        //        Debug.Log("Status = Clear");
        //    }
        //}

    }
}