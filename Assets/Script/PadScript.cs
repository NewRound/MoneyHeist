using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PadScript : MonoBehaviour
{
    public BallScript tagetBall;
    public GameObject _Arrow;
    public Rigidbody2D _rigidbody;
    public BoxCollider2D _boxCollider;
    //public DataManager _dm = DataManager.DMinstance;
    public SpriteRenderer _spriteRenderer;

    private Vector2 _direction;
    public float _shootPow;
    [SerializeField] float _paddleSpeed;
    [SerializeField] float _rotateSpd = 100;

    bool _isReady = false;
    bool _reverseRotation = false;

    public float _paddleSize;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _paddleSize = _boxCollider.size.x * 0.5f;
       
    }

    private void Start()
    {
        GameManager.I._paddle = this;
        InputKeyManager.I.OnMoveEventHandller += InputDirectionKey;
        InputKeyManager.I.OnShootEventHandller += ShootBall; 
        _shootPow = DataManager.DMinstance.ballSpeed;
        _paddleSpeed = DataManager.DMinstance.paddleSpeed;
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

    private void InputDirectionKey(Vector2 value)
    {
        _direction = value;
    }

    private void Move(Vector2 value)
    {
        _rigidbody.velocity = _paddleSpeed * Time.deltaTime * value;


        if (value.x > 0)
            _spriteRenderer.flipX = true;
        else if (value.x < 0)
            _spriteRenderer.flipX = false;

        if (transform.position.x < -2.4f + _paddleSize && value.x < 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else if (transform.position.x > 2.4f - _paddleSize && value.x > 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    // 슛 입력과 발사
    private void ShootBall(InputValue inputkey)
    {
        if (GameManager.I.IsShootBall)
            return;

        tagetBall = BallManager.I.lastMakeBall;

        if (inputkey.isPressed == false)
        {
            GameManager.I.IsShootBall = true;
            _isReady = false;
            tagetBall._rigidbody.bodyType = RigidbodyType2D.Dynamic;
            tagetBall._rigidbody.velocity = _shootPow * tagetBall.transform.up;
            tagetBall._ballShottingPow = tagetBall._rigidbody.velocity.magnitude;

            _Arrow.transform.rotation = Quaternion.identity;
            _Arrow.SetActive(false);
            return;
        }
        else if (inputkey.isPressed == true)
        {
            GameManager.I._isGaming = true;
            _isReady = true;
        }
    }

    // 발사 각도 설정
    private void SettingBall()
    {
        if (_isReady == true && GameManager.I.IsShootBall == false)
        {
            if (_reverseRotation == false)
            {
                tagetBall.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.forward);
                _Arrow.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.forward);
                if (tagetBall.transform.rotation.z >= 0.6)
                {
                    _reverseRotation = true;
                }
            }
            else if (_reverseRotation == true)
            {
                tagetBall.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.back);
                _Arrow.transform.Rotate(_rotateSpd * Time.deltaTime * Vector3.back);
                if (tagetBall.transform.rotation.z <= -0.6)
                {
                    _reverseRotation = false;
                }
            }
        }
    }
}

