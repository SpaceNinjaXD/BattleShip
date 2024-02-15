using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    public GameSetupState SetupState { get; private set; }
    public GamePlayState PlayState { get; private set; }
    public WaitingState WaitState { get; private set; }
    public LostState LostState { get; private set; }
    public WonState WonState { get; private set; }
    private void Awake()
    {
        _controller = GetComponent<GameController>();

        SetupState = new GameSetupState(this, _controller);
        PlayState = new GamePlayState(this, _controller);
        WaitState = new WaitingState(this, _controller);
        WonState = new WonState(this, _controller);
        LostState = new LostState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
