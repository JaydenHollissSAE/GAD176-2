using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace GAD176.ProjectRPG
{
    public class TrackingOverride : MonoBehaviour
    {
        private EnemyOverworld enemyOverworld;
        private GameObject[] enemies;
        private int selectedEnemy = 0;
        private int selectedPlayer = 0;
        [SerializeField] TextMeshProUGUI tracker;
        [SerializeField] TextMeshProUGUI tracked;
        // Start is called before the first frame update
        void Start()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            enemyOverworld = enemies[selectedEnemy].GetComponent<EnemyOverworld>();
            enemyOverworld.trackingOverride = true;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeSelectedEnemy()
        {
            if (selectedEnemy == enemies.Length - 1)
            {
                selectedEnemy = 0;
            }
            else
            {
                selectedEnemy += 1;
            }
            enemyOverworld = enemies[selectedEnemy].GetComponent<EnemyOverworld>();
            enemyOverworld.trackingOverride = true;
            tracker.text = "Enemy Selected: " + selectedEnemy.ToString();
        }

        public void OverrideEnemyTracking()
        {
            if (selectedPlayer == enemyOverworld.players.Length - 1)
            {
                selectedPlayer = 0;
            }
            else
            {
                selectedPlayer += 1;
            }
            enemyOverworld.player = enemyOverworld.players[selectedPlayer];
            tracked.text = "Tracking Player: " + selectedPlayer.ToString();
        }

    }
}