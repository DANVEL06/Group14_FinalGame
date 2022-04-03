using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState

{
   public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("isWalking",true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        
    }
}
