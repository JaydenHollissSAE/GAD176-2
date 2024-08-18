using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    float PhysicalAttack(float PhyAttack, float AttackMod);
    float MagicAttack(float MagAttack, float AttackMod);
}
