using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAD176.ProjectRPG
{
    public class BattleAsignment : MonoBehaviour
    {
        private GameManager gameManager;
        private GameObject currentModel;
        private BattleManager battleManager;
        //private Enemy enemy;
        // Start is called before the first frame update

        void Start()
        {
            if (gameManager.randomisedEnemies == true)
            {
                currentModel = gameManager.enemiesList[Random.Range(0, gameManager.enemiesList.Count)];
            }
            //else
            //{
                //currentModel = enemy.enemiesList[0];
                //Sets currentModel based on the enemyList threaded through from Enemy.
            //}
            Instantiate(currentModel, transform);
            battleManager.inBattleEnemies.Add(currentModel);
        }
    }













}