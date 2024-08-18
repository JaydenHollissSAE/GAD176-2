using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GAD176.ProjectRPG
{
    [System.Serializable]
    public class BattleInst : UnityEvent<int>
    {

    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager inst;
        public BattleInst battleInst;
        public bool randomisedEnemies = false;
        public List<GameObject> enemiesList = new List<GameObject>();
        public int maxEnemies;
        public UnityEvent loadBattle; 

        void Awake()
        {
            if (inst == null)
            {
                inst = this;
                DontDestroyOnLoad(inst);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}