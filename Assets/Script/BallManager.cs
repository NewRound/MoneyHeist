using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager I;

    [SerializeField] GameObject ballPrefab;
    public List<BallScript> _balls = new();
    public Queue<BallScript> _disabledBalls = new();
    public BallScript _lastMakeBall;

    private void Awake()
    {
        I = this;
    }

    // �� �� �����
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

    // �� ����
    public void DivideBall()
    {
        MakeBall();
        float _maxPosY = -10;
        int _ballIndex = 0;
        for (int i = 0; i < _balls.Count; i++)
        {
            if (_balls[i].transform.position.y > _maxPosY && _balls[i] != _lastMakeBall && _balls[i].gameObject.activeSelf == true)
            {
                _maxPosY = _balls[i].transform.position.y;
                _ballIndex = i;
                continue;
            }
        }

        _lastMakeBall.transform.position = _balls[_ballIndex].transform.position;
        _lastMakeBall._ballShottingPow = _balls[_ballIndex]._ballShottingPow;
        Vector3 _oldVelocity = _balls[_ballIndex]._rigidbody.velocity;
        Vector3 _newVelocity = new Vector3(_oldVelocity.x * -1, _oldVelocity.y, 0).normalized;
        _lastMakeBall._rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _lastMakeBall._rigidbody.velocity = _newVelocity * _lastMakeBall._ballShottingPow;
    }

    // �� ũ�� ����
    public void ExpandCollider(BallScript ball, bool isWork)
    {
        if (isWork)
        {
            originalScale = ball.transform.localScale;
            // �� ���� ������Ʈ�� �������� ������ŵ�ϴ�.
            Vector3 newScale = ball.transform.localScale * 1.25f;
            ball.transform.localScale = newScale;
        }
        else
        {
            ball.transform.localScale = originalScale;
        }
    }
}
