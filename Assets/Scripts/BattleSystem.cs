using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

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


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < battleCharacters.Count; i++)
        {
            character = battleCharacters[i].GetComponent<Stats>;
            if (character.type == "Player")
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
        character = battleCharacters[turnRotation].GetComponent<Stats>;
        if (character.type == "Player")
        {
            PlayerPhase();
        }
        else
        {
            EnemyPhase();
        }
    }
    private void EnemyPhase()
    {
        if (character.job == "Healer")
        {
            EnemyHealer();
        }
        else if (character.job == "AOE")
        {
            EnemyAOE();
        }
        else if (character.job == "Single")
        {
            EnemySingle();
        }
        else if (character.job == "Status")
        {
            EnemyStatus();
        }

    }
    private void EnemyHealer()
    {
        for (int i = 0; i < enemyCharacters.Count; i++)
        {
            tmpCharacter = enemyCharacters[i].GetComponent<Stats>;
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
            tmpCharacter = enemyNeedsHealing.GetComponent<Stats>;
            tmpCharacter.health += character.healingPower;
            tmpCharacter = null;
            enemyNeedsHealing = null;
        }
        else if (enemyNeedsCuring != null)
        {
            tmpCharacter = enemyNeedsCuring.GetComponent<Stats>;
            tmpCharacter.status = null;
            tmpCharacter = null;
            enemyNeedsCuring = null;
        }
        else
        {
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                tmpCharacter = playerCharacters[i].GetComponent<Stats>;
                if (tmpCharacter.health <= tmpCharacter.maxHealth/4)
                {
                    playersLowHealth.Add(playerCharacters[i]);
                }
                tmpCharacter = null;
            }
            if (playersLowHealth.Count() > 1)
            {
                for (int i = 0;i < playersLowHealth.Count;i++)
                {
                    playersLowHealth[i].health -= character.aoeDamage;
                }
                
            }
            else if (playersLowHealth.Count() == 1)
            {
                playersLowHealth[i].health -= character.singleDamage;
            }
            else
            {
                if (Random.Range(1, 2) == 2)
                {
                    for (int i = 0; i < playerCharacters.Count; i++)
                    {
                        if (Random.Range(1, 5) == 2)
                        {
                            tmpCharacter = playerCharacters[i].GetComponent<Stats>;
                            tmpCharacter.health -= character.aoeDamage;
                        }
                    }
                }
                else
                {
                    tmpCharacter = playerCharacters[Random.Range(0, playerCharacters.Count())].GetComponent<Stats>;
                    tmpCharacter.health -= character.singleDamage;

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
            tmpCharacter = playerCharacters[i].GetComponent<Stats>;
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
                playersLowHealth[i].health -= character.aoeDamage;
            }

        }
        else
        {
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                if (Random.Range(1, 5) == 2)
                {
                    tmpCharacter = playerCharacters[i].GetComponent<Stats>;
                    tmpCharacter.health -= character.aoeDamage;
                }
            }


            tmpCharacter = null;
            playersLowHealth = null;
            playersLowHealth = new List<GameObject>();
        }
    }

    private void EnemySingle ()
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            tmpCharacter = playerCharacters[i].GetComponent<Stats>;
            if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
            {
                playersLowHealth.Add(playerCharacters[i]);
            }
            tmpCharacter = null;
        }
        if (playersLowHealth.Add(playerCharacters[i]).Count() > 0)
        {
            
            playersLowHealth[Random.Range(0, playersLowHealth.Count())].health -= character.singleDamage;

        }
        else
        {
            playerCharacters[Random.Range(0, playerCharacters.Count())].health -= character.singleDamage;



            tmpCharacter = null;
            playersLowHealth = null;
            playersLowHealth = new List<GameObject>();
        }
    }

    private void EnemyStatus()
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            tmpCharacter = playerCharacters[i].GetComponent<Stats>;
            if (tmpCharacter.health <= tmpCharacter.maxHealth / 4)
            {
                playersLowHealth.Add(playerCharacters[i]);
            }
            tmpCharacter = null;
        }
        if (playersHighHealth.Count() > 0)
        {

            playersHighHealth[Random.Range(0, playersHighHealth.Count())].status = character.statusAttack[Random.Range(character.statusAttack.Count());
        }
        else
        {
            playerCharacters[Random.Range(0, playerCharacters.Count())].status = character.statusAttack[Random.Range(character.statusAttack.Count());

            tmpCharacter = null;
            playersLowHealth = null;
            playersLowHealth = new List<GameObject>();
        }
    }

}

