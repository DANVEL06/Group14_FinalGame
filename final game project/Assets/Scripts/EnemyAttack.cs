using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        Debug.Log("I have Attacked");
        return this;
    }
}
