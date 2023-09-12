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

    // 디버그 해보고싶은 것들은 여기에 넣어서 사용해보세요 F키임
    public void OnDebugKeyF() 
    {
        BallManager.I.DivideBall();
    }

}
