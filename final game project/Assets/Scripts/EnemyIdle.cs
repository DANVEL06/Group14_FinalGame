using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyChase enemyChase;
    public bool canSeeThePlayer;

    public override EnemyState RunCurrentState()
    {
        if(canSeeThePlayer)
        {
            return enemyChase;
        }

        else
        {
            return this;
        }
        
    }
}
    
