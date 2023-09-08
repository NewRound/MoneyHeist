using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputKeyManager : MonoBehaviour
{
    public static InputKeyManager IM;

    public event Action<Vector2> OnMoveEventHandller;

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
        OnMoveEventHandller?.Invoke(value.Get<Vector2>());
    }

}
