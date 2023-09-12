using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputKeyManager : MonoBehaviour
{
    public static InputKeyManager I;

    public event Action<Vector2> OnMoveEventHandller; // ����Ű
    public event Action<InputValue> OnShootEventHandller; // �����̽���

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

    // ����� �غ������ �͵��� ���⿡ �־ ����غ����� FŰ��
    public void OnDebugKeyF() 
    {
        BallManager.I.DivideBall();
    }

}
