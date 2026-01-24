using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputActions.IPlayerActions
{
    public static InputReader Instance { get; private set; }

    //public event EventHandler OnMenuButtonPressed;

    private InputActions inputActions;

    // =====
    public event UnityAction<bool> Jump = delegate { };   

    // option
    //public bool IsJumpKeyPressed => inputActions.Player.Jump.IsPressed();

    public event UnityAction<Vector2> Move = delegate{};
    //public Vector2 Direction;
    //public Vector2 Direction => inputActions.Player.Move.ReadValue<Vector2>();

    public EventHandler OnMenuButtonPressed;
    // ======

    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Enable();

        // =====
        inputActions.Player.SetCallbacks(this);        

        //
        inputActions.Player.Menu.performed += Menu_performed;

    }

    private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnMenuButtonPressed?.Invoke(this, EventArgs.Empty);
    }


    // ===== =====
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("OnJump from : " + this.gameObject.name + " | context: " + context.phase ); 

        switch (context.phase)
        {
            case InputActionPhase.Started:
                Jump.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Jump.Invoke(false);
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //
        //Debug.Log("OnMove from : " + this.gameObject.name + " | context: " + context.phase ); 
        Move.Invoke(context.ReadValue<Vector2>());    



    }


   // ===== =====
    public bool IsUpPressed()
    {        
        return inputActions.Player.Up.IsPressed();
    }

    public bool IsDownPressed()
    {
        
        return inputActions.Player.Down.IsPressed();
    }

    public bool IsLeftPressed()
    {
        return inputActions.Player.Left.IsPressed();
    }

    public bool IsRightPressed()
    {
        return inputActions.Player.Right.IsPressed();
    }

    public Vector2 GetMovementInputVector2()
    {
        return inputActions.Player.Movement.ReadValue<Vector2>();
    }

    // public Vector2 GetMovementInputVector2()
    // {
    //     return inputActions.Player.Movement.ReadValue<Vector2>();
    // }


    private void OnDestroy()
    {
        inputActions.Disable();
    }

    // ===== =====

    public void OnUp(InputAction.CallbackContext context)
    {
        //
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        //
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        //
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        //
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        //
    }
}
