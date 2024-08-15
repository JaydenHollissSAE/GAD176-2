using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Stats stats;

    public void PhysicalAttack(float damage)
    {
        
    }

    public void MagicAttack(float damage)
    {

    }
}
