using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAD176.ProjectRPG
{
    public class BattleManager : MonoBehaviour
    {
        public List<GameObject> inBattleEnemies = new List<GameObject>();
        private GameManager gameManager;
        //private Enemy enemy;
        private int enemyCount;
        // Start is called before the first frame update
        void Start()
        {
            if (gameManager.randomisedEnemies == true)
            {
                enemyCount = Random.Range(1, gameManager.maxEnemies);
            }
            //else
            //{
                //enemy = enemy.enemyCount;
            //}
            for (int i = 0; i < enemyCount; i++)
            {

            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}