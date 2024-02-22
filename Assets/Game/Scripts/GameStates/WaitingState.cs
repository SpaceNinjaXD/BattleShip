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
            if (col.gameObject.tag == "Tile")
            {
                col.gameObject.GetComponent<Tiles>().cannonHit = true;
                int numOfSunkSubs = 0;
                foreach(GameObject sub in _controller.subSpawner.SpawnedSubmarines)
                {
                    sub.GetComponent<Submarines>().checkIfSunk();
                    if (sub.GetComponent<Submarines>().hasSunk)
                    {
                        numOfSunkSubs += 1;
                    }
                }
                if(numOfSunkSubs == _controller.subSpawner.SpawnedSubmarines.Count)
                {
                    _stateMachine.ChangeState(_stateMachine.WonState);
                }else
                _stateMachine.ChangeState(_stateMachine.PlayState);
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.PlayState);
            }
        }
    }
}
