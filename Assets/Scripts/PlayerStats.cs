using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAD176.ProjectRPG.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float playerHealth; // player's current health value
        [SerializeField] private float playerMaxHealth = 100f; // maximum health the player can have. can be altered by different items like armor, etc. default is 100
        [SerializeField] private float playerAttackMultiplier; // multiplies the damage done by the weapon the player is using
        [SerializeField] private float playerDefense; // a value that decreases the amount of damage the player takes

        public float GetPlayerHealth()
        {
            return playerHealth;
        }

        public void SetPlayerHealth(float setValue)
        {
            playerHealth = setValue;
        }

        public float GetMaxPlayerHealth()
        {
            return playerMaxHealth;
        }

        public void SetMaxPlayerHealth(float setValue)
        {
            playerMaxHealth = setValue;
        }
        public float GetPlayerAttackMultiplier()
        {
            return playerAttackMultiplier;
        }

        public void SetPlayerAttackMultiplier(float setValue)
        {
            playerAttackMultiplier = setValue;
        }

        public float GetPlayerDefense()
        {
            return playerDefense;
        }

        public void SetPlayerDefense(float setValue)
        {
            playerDefense = setValue;
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
}