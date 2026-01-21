using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static InputReader Instance { get; private set; }

    //public event EventHandler OnMenuButtonPressed;

    private InputActions inputActions;



    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Enable();

        

        //inputActions.Player.Menu.performed += Menu_performed;
    }

    // private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    // {
    //     OnMenuButtonPressed?.Invoke(this, EventArgs.Empty);
    // }
  



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

    // public Vector2 GetMovementInputVector2()
    // {
    //     return inputActions.Player.Movement.ReadValue<Vector2>();
    // }


    private void OnDestroy()
    {
        inputActions.Disable();
    }




    
}
