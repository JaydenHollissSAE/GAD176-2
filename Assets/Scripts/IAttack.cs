using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void PhysicalAttack(float damage);
    void MagicAttack(float damage);
}
