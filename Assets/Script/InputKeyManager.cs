using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputKeyManager : MonoBehaviour
{
    public static InputKeyManager IM;

    public event Action<Vector2> OnMoveEventHandller;
    public event Action<InputValue> OnShootEventHandller;
    public event Action OnShootDownEventHandller;
    public event Action OnShootUpEventHandller;


    public PlayerInput _input;

    public InputKeyManager()
    {
        if (IM != null)
        {
            Destroy(this);
            return;
        }

        IM = this;
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("aaaasd");
        OnMoveEventHandller?.Invoke(value.Get<Vector2>());
    }

    public void OnShoot(InputValue value)
    {
        Debug.Log("asd");
        OnShootEventHandller?.Invoke(value);
    }

}
