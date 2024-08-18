using GAD176.ProjectRPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBattle : MonoBehaviour
{
    private EnemyOverworld manager;
    private bool battleTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<EnemyOverworld>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleTriggered)
        {
            if (Vector3.Distance(transform.position, manager.player.transform.position) <= 1f)
            {
                battleTriggered = true;
                GameManager.inst.loadBattle.Invoke();
            }
        }

    }
}
