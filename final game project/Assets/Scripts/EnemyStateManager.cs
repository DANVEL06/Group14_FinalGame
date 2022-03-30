using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{

    public EnemyState currentState;
    

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        EnemyState nextState =  currentState?.RunCurrentState();

        if(nextState != null)
        {
            SwitchToNextState (nextState);
        }
    }

    private void SwitchToNextState(EnemyState nextState)
    {
        currentState = nextState;
    }
}
