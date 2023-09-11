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
        Move(_direction);
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

    private void ShootBall(InputValue inputkey) // �� �Է°� �߻�
    {
        if (GameManager.I.IsShootBall )
            return;

        tagetBall = transform.Find("Ball").gameObject;

        if (inputkey.isPressed == false)
        {
            GameManager.I.IsShootBall = true;
            _isReady = false;
            tagetBall = transform.Find("Ball").gameObject;
            tagetBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            tagetBall.transform.SetParent(null);
            tagetBall.GetComponent<Rigidbody2D>().velocity = _shootPow*tagetBall.transform.up;
            tagetBall.AddComponent<BallScript>();
            tagetBall.GetComponent<BallScript>()._ballPow = tagetBall.GetComponent<Rigidbody2D>().velocity.magnitude;
            return;
        }
        else if (inputkey.isPressed == true)
        {
            _isReady = true;
        }
    }

    private void SettingBall() // �߻� ���� ����
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
