using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySkills : IAttack
    {
        public float PhysicalAttack(float PhyAttack, float AttackMod)
        {
            //Get max value of physical attack & attack modifier from enemy's stats 
            //return value of random range with max of physical attack and min of 1
            //(So attack success can vary and cause more or less damage)
            //then multiplied by the enemy's modifier
            float damage = Mathf.Round( Random.Range(1f, PhyAttack) *AttackMod);
            return damage;  
        }
        public float MagicAttack(float MagAttack, float AttackMod)
        {
            //Get max value of magical attack & attack modifier from enemy's stats 
            //return value of random range with max of physical attack and min of 1
            //(So attack success can vary and cause more or less damage)
            //then multiplied by the enemy's modifier
            float damage = Mathf.Round(Random.Range(1f, MagAttack) * AttackMod);
            return damage;
        }

    }
}

