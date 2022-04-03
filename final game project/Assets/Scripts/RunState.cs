using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
   public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("isRunning",true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if(movement.vInput<0)
        {
            movement.moveSpeed = movement.runBackSpeed;
        }
        else
        {
            movement.moveSpeed = movement.runSpeed;
        }
    }
    
}
