using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void PhysicalAttack(float damage, int attackingIndex);
    void MagicAttack(float damage, int attackingIndex);
}
