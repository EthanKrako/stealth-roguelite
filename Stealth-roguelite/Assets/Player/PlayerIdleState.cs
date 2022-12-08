using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine context, PlayerStateFactory factory) : base(context, factory){}

    public override void EnterState(){ }

    public override void UpdateState(){ 
        CheckSwitchStates();
    }

    public override void ExitState(){ }

    public override void CheckSwitchStates() {
        if (!Ctx.IsGrounded) {
            SwitchState(Factory.Fall());
        } else if (Ctx.IsMovementPressed && !Ctx.IsWalkingPressed) {
            SwitchState(Factory.Run());
        } else if (Ctx.IsMovementPressed) {
            SwitchState(Factory.Walk());
        }
    }
}
