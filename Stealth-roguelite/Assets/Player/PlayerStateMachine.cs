using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    // Reference variables
    [SerializeField] private CharacterController _characterController;

    // Input variables
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private bool _isMovementPressed;
    private bool _isWalkingPressed;
    private bool _isGrounded = true;


    // States variables
    PlayerStateFactory _states;
    PlayerBaseState _currentState;

    // Constant
    private float _runMultiplier = 10.0f;
    private float _walkMultiplier = 7.0f;

    // getters and setters
    public Vector2 CurrentMovementInput { get { return _currentMovementInput; }}
    public float CurrentMovementY { get { return _currentMovement.y; } set { _currentMovement.y = value; }}
    public float CurrentMovementX { get { return _currentMovement.x; } set { _currentMovement.x = value; }}
    public float CurrentMovementZ { get { return _currentMovement.z; } set { _currentMovement.z = value; }}
    public bool IsMovementPressed { get { return _isMovementPressed; }}
    public bool IsWalkingPressed { get { return _isWalkingPressed; }}
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; }}
    public float RunMultiplier { get { return _runMultiplier; }}
    public float WalkMultiplier { get { return _walkMultiplier; }}
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; }}

    private void Awake() {
        _states = new PlayerStateFactory(this);

        // Initiate current state
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    private void Update() {
        _characterController.Move(_currentMovement * Time.deltaTime);

        _currentState.UpdateState();
    }

    public void onMovementInput(InputAction.CallbackContext context) {
        _currentMovementInput = context.ReadValue<Vector2>();
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
        //Debug.Log(_currentMovement);
    }
}
