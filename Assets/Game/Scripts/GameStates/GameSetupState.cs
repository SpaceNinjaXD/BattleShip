using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private bool subsInPosition = false;
    private int test = 0;
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
        _controller.subSpawner.SpawnSubs();
        _stateMachine.ChangeState(_stateMachine.PlayState);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("STATE: Game Setup Leaving");
    }

    public override void FixedTick()
    {
        base.FixedTick();
        /*while(test < 20000)
        {
            int i = 0;
            foreach (GameObject subs in _controller.subSpawner.SpawnedSubmarines)
            {
                Debug.Log(subs.GetComponent<Submarines>().isLegal + " "+ subs);
                subs.GetComponent<Submarines>().checkLegality();
                if (subs.GetComponent<Submarines>().isLegal)
                {
                    Debug.Log("Legal Sub is " + subs);
                    _controller.subSpawner.SpawnedSubmarines.RemoveAt(i);
                }
                i += 1;
            }
            
            test += 1;
        }
        if(_controller.subSpawner.SpawnedSubmarines.Count == 0)
        {
            subsInPosition = true;
        }*/

       
    }

    public override void Tick()
    {
        base.Tick();
        
        
         _stateMachine.ChangeState(_stateMachine.PlayState);
        

    }
}
