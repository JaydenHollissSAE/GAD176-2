using GAD176.ProjectRPG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GAD1766.ProjectRPG
{
    public class PointTracker : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            GameManager.inst.loadBattle.AddListener(UpdateUI);
        }

        // Update is called once per frame
        void UpdateUI()
        {
            SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        }
    }
}