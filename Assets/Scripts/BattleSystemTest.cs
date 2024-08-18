using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace GAD176.ProjectRPG
{
    public class BattleSystemTest : MonoBehaviour
    {
        public int turnRotation = 0;
        public List<GameObject> battleCharacters = new List<GameObject>();
        private List<GameObject> playerCharacters = new List<GameObject>();
        public List<GameObject> enemyCharacters = new List<GameObject>();
        private bool uiOpen;
        private GameObject enemyNeedsHealing;
        private GameObject enemyNeedsCuring;
        private List<GameObject> playersLowHealth = new List<GameObject>();
        private List<GameObject> playersHighHealth = new List<GameObject>();
        private StatsTest stats;
        private StatsTest tmpCharacter;
        private PlayerTurnTest playerTurn;
        private int tmpSelected;


        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < battleCharacters.Count; i++)
            {
                stats = battleCharacters[i].GetComponent<StatsTest>();
                if (stats.type == "Player")
                {
                    playerCharacters.Add(battleCharacters[i]);
                }
                else
                {
                    enemyCharacters.Add(battleCharacters[i]);
                }
            }
            playerTurn = GetComponent<PlayerTurnTest>();
            Debug.Log(playerTurn.existance);
            Turn();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Turn()
        {
            stats = battleCharacters[turnRotation].GetComponent<StatsTest>();
            if (stats.type == "Player")
            {
                playerTurn.stats = stats;
                playerTurn.StartPlayerTurn();
                //PlayerPhase();
                Debug.Log("Player Moved");
            }
            else
            {
                Debug.Log("Enemy Moved");
                EnemyPhase();
            }
            if (turnRotation != battleCharacters.Count - 1)
            {
                turnRotation += 1;

            }
            else
            {
                turnRotation = 0;
            }
            if (!playerTurn.playerTurnActive)
            {
                Turn();
            }
        }
        private void EnemyPhase()
        {

            Debug.Log(stats.type + " " + stats.job);
            Debug.Log("Health = " + stats.health + "/" + stats.maxHealth);
            if (stats.status != null)
            {
                Debug.Log("Status = " + stats.status);
            }
            else
            {
                Debug.Log("Status = Clear");
            }



            if (stats.job == "Healer")
            {
                EnemyHealer();
            }
            else if (stats.job == "AOE")
            {
                EnemyAOE();
            }
            else if (stats.job == "Single")
            {
                EnemySingle();
            }
            else if (stats.job == "Status")
            {
                EnemyStatus();
            }

        }
        private void EnemyHealer()
        {
            for (int i = 0; i < enemyCharacters.Count; i++)
            {
                tmpCharacter = enemyCharacters[i].GetComponent<StatsTest>();
                if (tmpCharacter.health < tmpCharacter.healThreshold)
                {
                    enemyNeedsHealing = enemyCharacters[i];
                }
                else if (tmpCharacter.status != null)
                {
                    enemyNeedsCuring = enemyCharacters[i];
                }
                tmpCharacter = null;
            }
            if (enemyNeedsHealing != null)
            {
                tmpCharacter = enemyNeedsHealing.GetComponent<StatsTest>();
                tmpCharacter.health += stats.healingPower;
                tmpCharacter = null;
                enemyNeedsHealing = null;
            }
            else if (enemyNeedsCuring != null)
            {
                tmpCharacter = enemyNeedsCuring.GetComponent<StatsTest>();
                tmpCharacter.status = null;
                tmpCharacter = null;
                enemyNeedsCuring = null;
            }
            else
            {
                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    tmpCharacter = playerCharacters[i].GetComponent<StatsTest>();
                    if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
                    {
                        playersLowHealth.Add(playerCharacters[i]);
                    }
                    tmpCharacter = null;
                }
                if (playersLowHealth.Count() > 1)
                {
                    for (int i = 0; i < playersLowHealth.Count; i++)
                    {
                        tmpCharacter = playersLowHealth[i].GetComponent<StatsTest>();

                        tmpCharacter.health -= stats.aoeDamage;
                        if (tmpCharacter.health <= 0)
                        {
                            battleCharacters.Remove(playersLowHealth[i]);
                            playerCharacters.Remove(playersLowHealth[i]);
                        }
                    }
                    tmpCharacter = null;

                }
                else if (playersLowHealth.Count() == 1)
                {
                    tmpCharacter = playersLowHealth[0].GetComponent<StatsTest>();

                    tmpCharacter.health -= stats.singleDamage;

                    if (tmpCharacter.health <= 0)
                    {

                        battleCharacters.Remove(playersLowHealth[0]);
                        playerCharacters.Remove(playersLowHealth[0]);
                    }
                    tmpCharacter = null;
                }
                else
                {
                    if (Random.Range(1, 2) == 2)
                    {
                        for (int i = 0; i < playerCharacters.Count; i++)
                        {
                            if (Random.Range(1, 5) == 2)
                            {
                                tmpCharacter = playerCharacters[i].GetComponent<StatsTest>();
                                tmpCharacter.health -= stats.aoeDamage;
                                if (tmpCharacter.health <= 0)
                                {
                                    battleCharacters.Remove(playerCharacters[i]);
                                    playerCharacters.RemoveAt(i);
                                }
                            }
                            tmpCharacter = null;
                        }
                    }
                    else
                    {
                        tmpSelected = Random.Range(0, playerCharacters.Count());
                        tmpCharacter = playerCharacters[tmpSelected].GetComponent<StatsTest>();
                        tmpCharacter.health -= stats.singleDamage;
                        if (tmpCharacter.health <= 0)
                        {
                            battleCharacters.Remove(playerCharacters[tmpSelected]);
                            playerCharacters.RemoveAt(tmpSelected);
                        }

                    }

                    tmpCharacter = null;
                    playersLowHealth = null;
                    playersLowHealth = new List<GameObject>();
                }
            }
        }

        private void EnemyAOE()
        {
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                tmpCharacter = playerCharacters[i].GetComponent<StatsTest>();
                if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
                {
                    playersLowHealth.Add(playerCharacters[i]);
                }
                tmpCharacter = null;
            }
            if (playersLowHealth.Count() > 0)
            {
                for (int i = 0; i < playersLowHealth.Count; i++)
                {
                    tmpCharacter = playersLowHealth[i].GetComponent<StatsTest>();
                    tmpCharacter.health -= stats.aoeDamage;

                    if (tmpCharacter.health <= 0)
                    {
                        battleCharacters.Remove(playersLowHealth[i]);
                        playerCharacters.Remove(playersLowHealth[i]);
                    }
                }
                tmpCharacter = null;

            }
            else
            {
                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    if (Random.Range(1, 5) == 2)
                    {
                        tmpCharacter = playerCharacters[i].GetComponent<StatsTest>();
                        tmpCharacter.health -= stats.aoeDamage;
                    }
                    if (tmpCharacter.health <= 0)
                    {
                        battleCharacters.Remove(playersLowHealth[i]);
                        playerCharacters.Remove(playersLowHealth[i]);
                    }
                    tmpCharacter = null;
                }


                tmpCharacter = null;
                playersLowHealth = null;
                playersLowHealth = new List<GameObject>();
            }
        }

        private void EnemySingle()
        {
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                tmpCharacter = playerCharacters[i].GetComponent<StatsTest>();
                if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
                {
                    playersLowHealth.Add(playerCharacters[i]);
                }
                tmpCharacter = null;
            }
            if (playersLowHealth.Count() > 0)
            {
                tmpSelected = Random.Range(0, playersLowHealth.Count());
                tmpCharacter = playersLowHealth[tmpSelected].GetComponent<StatsTest>();
                tmpCharacter.health -= stats.singleDamage;

                if (tmpCharacter.health <= 0)
                {
                    battleCharacters.Remove(playersLowHealth[tmpSelected]);
                    playerCharacters.Remove(playersLowHealth[tmpSelected]);
                }
                tmpCharacter = null;

            }
            else
            {
                tmpSelected = Random.Range(0, playerCharacters.Count());
                tmpCharacter = playerCharacters[tmpSelected].GetComponent<StatsTest>();

                tmpCharacter.health -= stats.singleDamage;

                if (tmpCharacter.health <= 0)
                {
                    battleCharacters.Remove(playerCharacters[tmpSelected]);
                    playerCharacters.RemoveAt(tmpSelected);
                }


                tmpCharacter = null;
                playersLowHealth = null;
                playersLowHealth = new List<GameObject>();
            }
        }

        private void EnemyStatus()
        {
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                tmpCharacter = playerCharacters[i].GetComponent<StatsTest>();
                if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
                {
                    playersLowHealth.Add(playerCharacters[i]);
                }
                tmpCharacter = null;
            }
            if (playersHighHealth.Count() > 0)
            {

                tmpCharacter = playersHighHealth[Random.Range(0, playersHighHealth.Count())].GetComponent<StatsTest>();
                tmpCharacter.status = stats.statusAttack[Random.Range(0, stats.statusAttack.Count())];
            }
            else
            {
                tmpCharacter = playerCharacters[Random.Range(0, playerCharacters.Count())].GetComponent<StatsTest>();
                tmpCharacter.status = stats.statusAttack[Random.Range(0, stats.statusAttack.Count())];

                tmpCharacter = null;
                playersLowHealth = null;
                playersLowHealth = new List<GameObject>();
            }
        }

    }

}