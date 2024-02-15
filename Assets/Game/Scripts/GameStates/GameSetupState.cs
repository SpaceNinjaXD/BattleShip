using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        
    }

    public override void Enter()
    {
        _controller._playerController.enabled = false;
        _controller.StateStatus.text = "State: Setup";
        base.Enter();
        Debug.Log("STATE: Game Setup");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("STATE: Game Setup Leaving");
    }

    public override void FixedTick()
    {
        base.FixedTick();
       
    }

    public override void Tick()
    {
        base.Tick();
        
        if (StateDuration >= 5)
        {
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }

    }
}
