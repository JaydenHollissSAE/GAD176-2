using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace GAD176.ProjectRPG
{
    public class BattleSystem : MonoBehaviour
    {
        private int turnRotation = 0;
        private List<GameObject> battleCharacters = new List<GameObject>();
        private List<GameObject> playerCharacters = new List<GameObject>();
        private List<GameObject> enemyCharacters = new List<GameObject>();
        private bool uiOpen;
        private GameObject enemyNeedsHealing;
        private GameObject enemyNeedsCuring;
        private List<GameObject> playersLowHealth = new List<GameObject>();
        private List<GameObject> playersHighHealth = new List<GameObject>();
        private Stats stats;
        private Stats tmpCharacter;


        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < battleCharacters.Count; i++)
            {
                stats = battleCharacters[i].GetComponent<Stats>();
                if (stats.type == "Player")
                {
                    playerCharacters.Add(battleCharacters[i]);
                }
                else
                {
                    enemyCharacters.Add(battleCharacters[i]);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Turn()
        {
            stats = battleCharacters[turnRotation].GetComponent<Stats>();
            if (stats.type == "Player")
            {
                //PlayerPhase();
                Debug.Log("Player Moved");
            }
            else
            {
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
            Turn();
        }
        private void EnemyPhase()
        {
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
                tmpCharacter = enemyCharacters[i].GetComponent<Stats>();
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
                tmpCharacter = enemyNeedsHealing.GetComponent<Stats>();
                tmpCharacter.health += stats.healingPower;
                tmpCharacter = null;
                enemyNeedsHealing = null;
            }
            else if (enemyNeedsCuring != null)
            {
                tmpCharacter = enemyNeedsCuring.GetComponent<Stats>();
                tmpCharacter.status = null;
                tmpCharacter = null;
                enemyNeedsCuring = null;
            }
            else
            {
                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    tmpCharacter = playerCharacters[i].GetComponent<Stats>();
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
                        tmpCharacter = playersLowHealth[i].GetComponent<Stats>();

                        tmpCharacter.health -= stats.aoeDamage;
                    }
                    tmpCharacter = null;

                }
                else if (playersLowHealth.Count() == 1)
                {
                    tmpCharacter = playersLowHealth[0].GetComponent<Stats>();

                    tmpCharacter.health -= stats.singleDamage;
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
                                tmpCharacter = playerCharacters[i].GetComponent<Stats>();
                                tmpCharacter.health -= stats.aoeDamage;
                            }
                            tmpCharacter = null;
                        }
                    }
                    else
                    {
                        tmpCharacter = playerCharacters[Random.Range(0, playerCharacters.Count())].GetComponent<Stats>();
                        tmpCharacter.health -= stats.singleDamage;

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
                tmpCharacter = playerCharacters[i].GetComponent<Stats>();
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
                    tmpCharacter = playersLowHealth[i].GetComponent<Stats>();
                    tmpCharacter.health -= stats.aoeDamage;
                }
                tmpCharacter = null;

            }
            else
            {
                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    if (Random.Range(1, 5) == 2)
                    {
                        tmpCharacter = playerCharacters[i].GetComponent<Stats>();
                        tmpCharacter.health -= stats.aoeDamage;
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
                tmpCharacter = playerCharacters[i].GetComponent<Stats>();
                if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
                {
                    playersLowHealth.Add(playerCharacters[i]);
                }
                tmpCharacter = null;
            }
            if (playersLowHealth.Count() > 0)
            {

                tmpCharacter = playersLowHealth[Random.Range(0, playersLowHealth.Count())].GetComponent<Stats>();
                tmpCharacter.health -= stats.singleDamage;
                tmpCharacter = null;

            }
            else
            {
                tmpCharacter = playerCharacters[Random.Range(0, playerCharacters.Count())].GetComponent<Stats>();
                tmpCharacter.health -= stats.singleDamage;



                tmpCharacter = null;
                playersLowHealth = null;
                playersLowHealth = new List<GameObject>();
            }
        }

        private void EnemyStatus()
        {
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                tmpCharacter = playerCharacters[i].GetComponent<Stats>();
                if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
                {
                    playersLowHealth.Add(playerCharacters[i]);
                }
                tmpCharacter = null;
            }
            if (playersHighHealth.Count() > 0)
            {

                tmpCharacter = playersHighHealth[Random.Range(0, playersHighHealth.Count())].GetComponent<Stats>();
                tmpCharacter.status = stats.statusAttack[Random.Range(0, stats.statusAttack.Count())];
            }
            else
            {
                tmpCharacter = playerCharacters[Random.Range(0, playerCharacters.Count())].GetComponent<Stats>();
                tmpCharacter.status = stats.statusAttack[Random.Range(0, stats.statusAttack.Count())];

                tmpCharacter = null;
                playersLowHealth = null;
                playersLowHealth = new List<GameObject>();
            }
        }

    }

}