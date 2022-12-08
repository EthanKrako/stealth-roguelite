using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerStates {
    idle,
    walk,
    run,
    fall
}

public class PlayerStateFactory
{
    Dictionary<PlayerStates, PlayerBaseState> _states = new Dictionary<PlayerStates, PlayerBaseState>();

    public PlayerStateFactory(PlayerStateMachine currentContext) {
        _states[PlayerStates.idle] = new PlayerIdleState(currentContext, this);
        _states[PlayerStates.walk] = new PlayerWalkState(currentContext, this);
        _states[PlayerStates.run] = new PlayerRunState(currentContext, this);
        _states[PlayerStates.fall] = new PlayerFallingState(currentContext, this);
    }

    public PlayerBaseState Idle(){
        return _states[PlayerStates.idle];
    }
    public PlayerBaseState Walk(){
        return _states[PlayerStates.walk];
    }
    public PlayerBaseState Run(){
        return _states[PlayerStates.run];
    }
    public PlayerBaseState Fall(){
        return _states[PlayerStates.fall];
    }
}
