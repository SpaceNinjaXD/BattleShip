using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.StateStatus.text = "State: Play";
        _controller._playerController.enabled = true;
        _controller.Line.enabled = true;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        _controller.Line.enabled = false;
        _controller._playerController.enabled = false;
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if(_controller.Cannon.GetComponent<CannonController>().hasFired == true)
        {
            _controller.Cannon.GetComponent<CannonController>().hasFired = false;
            _stateMachine.ChangeState(_stateMachine.WaitState);
        }
    }

    
}
