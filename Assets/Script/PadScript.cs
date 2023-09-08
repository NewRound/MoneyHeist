using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadScript : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    
    Vector2 _direction;
    int _speed = 150;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InputKeyManager.IM.OnMoveEventHandller += InputDirectionKey;
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }

    private void InputDirectionKey(Vector2 value)
    {
        _direction = value;
    }

    private void Move(Vector2 value)
    {
        _rigidbody.velocity = _speed * Time.deltaTime * value;
    }
}
