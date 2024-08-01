using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAD176.ProjectRPG.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float playerHealth;
        [SerializeField] private float playerMaxHealth;
        [SerializeField] private float playerAttackDamage;
        [SerializeField] private float playerDefense;

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
        public float GetPlayerAttackDamage()
        {
            return playerAttackDamage;
        }

        public void SetPlayerAttackDamage(float setValue)
        {
            playerAttackDamage = setValue;
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