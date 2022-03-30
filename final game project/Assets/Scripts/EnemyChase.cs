using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{   
     public EnemyAttack enemyAttack;
    public bool isInAttackRange;

    public override EnemyState RunCurrentState()
    {
        if(isInAttackRange)
        {
            return enemyAttack;
        }

        else
        {
            return this;
        }
        
    }
}
