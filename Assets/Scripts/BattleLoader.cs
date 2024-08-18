using GAD176.ProjectRPG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GAD1766.ProjectRPG
{
    public class BattleLoader : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI pointsTxt;
        [SerializeField] GameObject pointsTracker;
        public int totalPoints;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.inst.battleInst.AddListener(LoadBattle);
        }

        // Update is called once per frame
        void LoadBattle()
        {
            //Debug.Log("Points here: " + points);
            totalPoints += points;
            pointsTxt.text = "Points: " + totalPoints.ToString();
        }
    }
}