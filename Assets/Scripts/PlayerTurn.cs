using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
namespace GAD176.ProjectRPG
{
    public class PlayerTurn : MonoBehaviour
    {
        private BattleSystem battleSystem;
        public bool playerTurnActive = false;
        public Stats stats;
        private Stats tmpCharacter;
        public string existance = "PlayerTurn Exists!!!";
        private bool showControls = false;
        private bool showStats = false;
        private int tmpSelected;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("I am working");
            battleSystem = GetComponent<BattleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerTurnActive) 
            {
                Turn();
            }
        }

        private void TurnFinish()
        {
            Debug.Log(playerTurnActive);
            playerTurnActive = false;
            Debug.Log(playerTurnActive);
            if (battleSystem.turnRotation != battleSystem.battleCharacters.Count - 1)
            {
                battleSystem.turnRotation += 1;

            }
            else
            {
                battleSystem.turnRotation = 0;
            }
            battleSystem.turnRotation += 1;
            battleSystem.Turn();
        }


        public void StartPlayerTurn()
        {
            playerTurnActive = true;
            showControls = true;
            showStats = true;
        }
        private void Turn()
        {
            if (showControls)
            {
                Debug.Log("Heal = Q, Heal Status = W, Apply Status = E, Perform AOE Attack = R, Perform Single Attack = T");
                showControls = false;
            }
            if (showStats)
            {
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
                }

                showStats = false;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stats.health += stats.healingPower;
                TurnFinish();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                stats.status = null;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                tmpSelected = Random.Range(0, battleSystem.enemyCharacters.Count);
                tmpCharacter = battleSystem.enemyCharacters[tmpSelected].GetComponent<Stats>();
                tmpCharacter.status = "Poison";
                tmpCharacter = null;
                TurnFinish();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                for (int i = 0; i < battleSystem.enemyCharacters.Count; i++)
                {
                    if (Random.Range(1, 5) == 2)
                    {
                        tmpCharacter = battleSystem.enemyCharacters[i].GetComponent<Stats>();
                        tmpCharacter.health -= stats.aoeDamage;

                        if (tmpCharacter.health <= 0)
                        {
                            battleSystem.battleCharacters.Remove(battleSystem.enemyCharacters[i]);
                            battleSystem.enemyCharacters.RemoveAt(i);
                        }
                    }
                    tmpCharacter = null;
                }
                TurnFinish();
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                tmpSelected = Random.Range(0, battleSystem.enemyCharacters.Count);
                tmpCharacter = battleSystem.enemyCharacters[tmpSelected].GetComponent<Stats>();
                tmpCharacter.health -= stats.singleDamage;
                if (tmpCharacter.health <= 0)
                {
                    battleSystem.battleCharacters.Remove(battleSystem.enemyCharacters[tmpSelected]);
                    battleSystem.enemyCharacters.RemoveAt(tmpSelected);
                }
                tmpCharacter = null;
                TurnFinish();
            }
        }


    }
}