using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    // Reference variables
    PlayerInput playerInput;
    CharacterController characterController;

    public void message(InputAction.CallbackContext context) {
        Debug.Log("bouge");
    }
}
