using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private CannonBall CBall;
    
    
    public WaitingState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.StateStatus.text = "State: Waiting";
        CBall = _controller.Cannon.GetComponent<CannonController>()._CanBall;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        if (CBall.hasHit == true)
        {
            Collision col = CBall.col;

            CBall.Des();
            if (col.gameObject.tag == "Winner")
            {
                _stateMachine.ChangeState(_stateMachine.WonState);
            }
            else if (col.gameObject.tag == "Loser")
            {
                _stateMachine.ChangeState(_stateMachine.LostState);
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.PlayState);
            }
        }
    }
}
