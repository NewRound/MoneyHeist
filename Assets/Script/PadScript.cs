using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PadScript : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    public BallScript tagetBall;
    public Rigidbody2D _rigidbody;

    private Vector2 _direction;
    [SerializeField] float _speed = 150;
    [SerializeField] float _rotateSpd = 100;
    public float _shootPow = 5;

    bool _isReady = false;
    bool _reverseRotation = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InputKeyManager.I.OnMoveEventHandller += InputDirectionKey;
        InputKeyManager.I.OnShootEventHandller += ShootBall;
    }

    private void FixedUpdate()
    {
        if (GameManager.I.IsShootBall == true)
        {
            Move(_direction);
            return;

        }
        SettingBall();
    }

    private void Update()
    {
    }

    private void InputDirectionKey(Vector2 value)
    {
        _direction = value;
    }

    private void Move(Vector2 value)
    {
        _rigidbody.velocity = _speed * Time.deltaTime * value;
    }

    private void ShootBall(InputValue inputkey) // 슛 입력과 발사
    {
        if (GameManager.I.IsShootBall )
            return;

        tagetBall = BallManager.I.lastMakeBall;

        if (inputkey.isPressed == false)
        {
            GameManager.I.IsShootBall = true;
            _isReady = false;
            tagetBall._line.SetActive(false);
            tagetBall._rigidbody.bodyType = RigidbodyType2D.Dynamic;
            tagetBall._rigidbody.velocity = _shootPow*tagetBall.transform.up;
            tagetBall._ballPow = tagetBall._rigidbody.velocity.magnitude;
            return;
        }
        else if (inputkey.isPressed == true)
        {
            _isReady = true;
        }
    }

    private void SettingBall() // 발사 각도 설정
    {
        if (_isReady == true && GameManager.I.IsShootBall == false)
        {
            if (_reverseRotation == false)
            {
                tagetBall.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.forward);
                if (tagetBall.transform.rotation.z >= 0.6)
                {
                      _reverseRotation = true;
                }
            }
            else if (_reverseRotation == true)
            {
                tagetBall.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.back);
                if (tagetBall.transform.rotation.z <= -0.6)
                {
                    _reverseRotation = false;
                }
            }
        }
    }
}

