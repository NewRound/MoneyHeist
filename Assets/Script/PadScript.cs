using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PadScript : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    GameObject tagetBall;
    Rigidbody2D _rigidbody;

    Vector2 _direction;
    [SerializeField] float _speed = 150;
    [SerializeField] float _rotateSpd = 100;
    [SerializeField] float _shootPow = 200;

    bool _isReady = false;
    bool _reverseRotation = false;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InputKeyManager.IM.OnMoveEventHandller += InputDirectionKey;
        InputKeyManager.IM.OnShootEventHandller += ShootBall;
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }

    private void InputDirectionKey(Vector2 value)
    {
        _direction = value;
    }

    private void Update()
    {
        if (_isReady==true && GameManager.GM.IsShootBall == false) 
        {
            if (_reverseRotation == false)
            {
                tagetBall.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.forward);
                if (transform.eulerAngles.z >= 90)
                {
                    _reverseRotation = true;
                }
            }
            if (_reverseRotation == true)
            {
                tagetBall.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.back);
                if (transform.eulerAngles.z <= 10)
                {
                    _reverseRotation = false;
                }
            }
        }
    }

    private void Move(Vector2 value)
    {
        _rigidbody.velocity = _speed * Time.deltaTime * value;
    }

    private void ShootBall(InputValue inputkey)
    {
        if (GameManager.GM.IsShootBall)
            return;
        
        tagetBall = transform.Find("Ball").gameObject;

        if (inputkey.isPressed == false)
        {
            _isReady = false;
            tagetBall = transform.Find("Ball").gameObject;
            tagetBall.GetComponent<Rigidbody2D>().velocity = _shootPow*Time.deltaTime*tagetBall.transform.up;
            tagetBall.AddComponent<BallScript>();
            return;
        }
        if (inputkey.isPressed == true)
        {
            _isReady = true;
        }


    }

}

