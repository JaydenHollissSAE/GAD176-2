using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GAD176.ProjectRPG.Player
{

    public class PlayerAttack : MonoBehaviour
    {

        [SerializeField] private PlayerStats playerStats; // reference to player stats script
        // [SerializeField] private Weapon currentWeapon; // current weapon the player is holding
        
        private void DamageEnemy(Enemy enemy, Weapon weapon)
        {
            if (!CheckIfPlayerTurn()) {  return; }
            float damageMulti = playerStats.GetPlayerAttackMultiplier(); // get player damage multi
            float totalDamage = weapon.damage * damageMulti; // calculate total damage to be dealt

            if (weapon.damageType == "physical")
            {
                float enemyHealth = enemy.GetEnemyHealth();
                float physicalDamage = enemyHealth - totalDamage;
                enemy.SetEnemyHealth(physicalDamage);
            } else if (weapon.damageType == "magic")
            {
                // logic for magic damage ...
            } // other damage types ad infinitum ...
        }

        private bool CheckIfPlayerTurn()
        {
            // if player's turn, return true
            // else return false
            return true;
        }

        private void Start()
        {
            CheckIfPlayerTurn();
        }
    }
}