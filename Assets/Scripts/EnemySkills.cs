using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySkills : IAttack
    {
        public float PhysicalAttack(float phyAttack, float attackMod)
        {
            //Get max value of physical attack & attack modifier from enemy's stats 
            //return value of random range with max of physical attack and min of 1
            //(So attack success can vary and cause more or less damage)
            //then multiplied by the enemy's modifier

            float damage = Mathf.Round( Random.Range(1f, phyAttack) *attackMod);

            //return the amount of damage done, battle manager to allocate this damage to respective target
            return damage;  
        }
        public float MagicAttack(float magAttack, float attackMod)
        {
            //Get max value of magical attack & attack modifier from enemy's stats 
            //return value of random range with max of magical attack and min of 1
            //(So attack success can vary and cause more or less damage)
            //then multiplied by the enemy's modifier

            float damage = Mathf.Round(Random.Range(1f, magAttack) * attackMod);

            //return the amount of damage done, battle manager to allocate this damage to respective target
            return damage;
        }
        public void Heal(int maxHeal, ref int currentHealth )
        {
            //calculate amount to heal and add this to the current health of the enemy (Itself)
            int healing = Random.Range( 0, maxHeal );
            currentHealth += healing;
        }

    }
}

