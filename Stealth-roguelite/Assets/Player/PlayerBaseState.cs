using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    private PlayerStateMachine _ctx;
    private PlayerStateFactory _factory;

    protected PlayerStateMachine Ctx { get { return _ctx; }}
    protected PlayerStateFactory Factory { get { return _factory; }}

    public PlayerBaseState(PlayerStateMachine context, PlayerStateFactory factory) {
        this._ctx = context;
        this._factory = factory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    protected void SwitchState(PlayerBaseState newState) {
        ExitState();

        newState.EnterState();

        _ctx.CurrentState = newState;
    }
}
