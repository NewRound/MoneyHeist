using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PadScript : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    [SerializeField] LineRenderer _lineRenderer;

    Vector2 _direction;
    int _speed = 150;
    int _rotateSpd = 1;
    bool _isReady = true;
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

    private void Move(Vector2 value)
    {
        _rigidbody.velocity = _speed * Time.deltaTime * value;
    }

    private void ShootBall(InputValue inputkey)
    {
            Debug.Log(inputkey.isPressed);
            GameObject tagetBall = transform.Find("Ball").gameObject;

            if (inputkey.isPressed == false)
            {
                tagetBall = transform.Find("Ball").gameObject;
                tagetBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 500));
                return;
            }
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

    // 10~80도의 각도
    // 마우스 누르는 동안 작동 때면 바로 발사
    //void RotateBow()
    //{
    //    UnityEngine.Debug.Log("asd");
    //    if (Input.GetMouseButton(0) && SetRotateBow == false)
    //    {
    //        if (ReverseRotation == false)
    //        {
    //            transform.Rotate(RotateSpeed * Time.deltaTime * Vector3.forward);
    //            if (transform.eulerAngles.z >= 90)
    //            {
    //                ReverseRotation = true;
    //            }
    //        }
    //        if (ReverseRotation == true)
    //        {
    //            transform.Rotate(RotateSpeed * Time.deltaTime * Vector3.back);
    //            if (transform.eulerAngles.z <= 10)
    //            {
    //                ReverseRotation = false;
    //            }
    //        }
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        SetRotateBow = true;
    //    }

    //}

}

