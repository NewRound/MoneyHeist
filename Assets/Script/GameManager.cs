using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _Paddle;

    private Vector2 _respawnPos; // ������ ��ġ = �е�pos + _respawnPos
    private bool _isShootBall = false; // �߻��ϰ��� �� ���������� true
    private int _life = 3; // �뷱�� �����ϼŵ��˴ϴ�!

    public bool IsShootBall { get { return _isShootBall; } set { _isShootBall = value; } }

    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
    }

    private void Start()
    {
        _respawnPos = new Vector2(0, 0.5f);
        //blockArr[0] = won0;
        //blockArr[1] = won1;
        //blockArr[2] = won2;
        //blockArr[3] = won3;
        //blockArr[4] = won4;
        //SetBlock(PlayerPrefs.GetInt("Level"));
    }

    public void GameStart() // ���� ����& �����
    {
        if (_life > 0)
        {
            _isShootBall = false;
            _life--;

            GameObject temp = Instantiate(_ball, _Paddle.transform);
            temp.transform.localPosition = _respawnPos;
            temp.name = "Ball";
        }
        else
        {
            // ���⿡ ������ 0�� ��� ó��
        }
    }
}
