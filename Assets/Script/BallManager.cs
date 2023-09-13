using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager I;

    [SerializeField] GameObject ballPrefab;
    public List<BallScript> _balls = new();
    public Queue<BallScript> _disabledBalls = new();
    public BallScript _lastMakeBall;
    private Vector3 originalScale; // ���� ������ �� ���� ����
    private int originalATK; // ���� ������ �� ���� ����
    private void Awake()
    {
        I = this;
    }
    private void Start()
    {
        originalScale = new Vector3(1,1,1);
        originalATK = DataManager.DMinstance.ballDamage;
    }

    // 볼 딱 만들기
    public void MakeBall()
    {
        if (_disabledBalls.Count != 0)
        {
            _lastMakeBall = _disabledBalls.Dequeue();
            _lastMakeBall.gameObject.SetActive(true);
            return;
        }

        _lastMakeBall = Instantiate(ballPrefab).GetComponent<BallScript>();
        _lastMakeBall.name = "Ball";
        _balls.Add(_lastMakeBall);
    }

    // 공 분할
    public void DivideBall()
    {
        float _maxPosY = -3;
        int _ballIndex = -1;
        for (int i = 0; i < _balls.Count; i++)
        {
            if (_balls[i].transform.position.y > _maxPosY && _balls[i].gameObject.activeSelf == true)
            {
                _maxPosY = _balls[i].transform.position.y;
                _ballIndex = i;
                continue;
            }
        }

        if (_ballIndex == -1)
            return;

        MakeBall();
        _lastMakeBall.transform.position = _balls[_ballIndex].transform.position;
        _lastMakeBall._ballShottingPow = _balls[_ballIndex]._ballShottingPow;
        Vector3 _oldVelocity = _balls[_ballIndex]._rigidbody.velocity;
        Vector3 _newVelocity = new Vector3(_oldVelocity.x * -1, _oldVelocity.y, 0).normalized;
        _lastMakeBall._rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _lastMakeBall._rigidbody.velocity = _newVelocity * _lastMakeBall._ballShottingPow;
    }

    // 진규님이 말씀하신 콜라이더 커지는 부분입니다.
    // 기본은 0.14f
    public void ExpandCollider(bool isWork)
    {
        if (isWork)
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                    Vector3 newScale = _balls[i].transform.localScale * 1.25f;
                    _balls[i].transform.localScale = newScale;
            }
        }
        else
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                    _balls[i].transform.localScale = originalScale;
            }
        }
    }
    // �� ���ݷ� ����
    public void AtkUP(bool isWork)
    {
        if (isWork)
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                    // �� ���� ������Ʈ�� �������� ������ŵ�ϴ�.
                    _balls[i]._dmg = 100;
            }
        }
        else
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                    _balls[i]._dmg = originalATK;
            }
        }
    }

}
