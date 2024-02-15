using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LostState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private CannonBall CBall;


    public LostState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.StateStatus.text = "State: Lost";
        _controller.GameEnding.text = "You Lost...";
        _controller.GameEnding.gameObject.active = true;
        _controller._LoserSound.Play();
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
        if (StateDuration >= 5)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
