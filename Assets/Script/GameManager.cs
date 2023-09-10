using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _Paddle;
    [SerializeField] GameObject _block;

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
    public void SetBlockLevel(int level)
    {
        switch (level)
        {
            case 0:
                //level = 3, blockCount == 50
                //50000 * 20, 10000 * 25, 5000 * 4, 1000 * 1(�ӽ�)
                {
                    int count = 0;
                    int[] imageNum = new int[50];
                    while (count < 1)
                    {
                        imageNum[count] = 0;
                        count++;
                    }
                    while (count < 5)
                    {
                        imageNum[count] = 1;
                        count++;
                    }
                    while (count < 30)
                    {
                        imageNum[count] = 2;
                        count++;
                    }
                    while (count < 50)
                    {
                        imageNum[count] = 3;
                        count++;
                    }

                    imageNum = SetBlock(imageNum);
                    for(int i = 0; i < 50; i++)
                    {
                        GameObject newBlock = Instantiate(_block);

                    }
                }
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
    private int[] SetBlock(int[] array)
    {
        return array = array.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
    }
}
