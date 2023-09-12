using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputKeyManager : MonoBehaviour
{
    public static InputKeyManager I;

    public event Action<Vector2> OnMoveEventHandller; // 방향키
    public event Action<InputValue> OnShootEventHandller; // 스페이스바

    public InputKeyManager()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }

        I = this;
    }

    public void OnMove(InputValue value)
    {
        OnMoveEventHandller?.Invoke(value.Get<Vector2>());
    }

    public void OnShoot(InputValue value)
    {
        OnShootEventHandller?.Invoke(value);
    }

    public void OnDebugKeyF()
    {
        BallManager.I.DivideBall();
    }

}
