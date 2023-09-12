using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] public GameObject _ball;
    [SerializeField] public PadScript _paddle;

    private GameObject[] blockArr = new GameObject[5];
    [SerializeField] GameObject won0;
    [SerializeField] GameObject won1;
    [SerializeField] GameObject won2;
    [SerializeField] GameObject won3;
    [SerializeField] GameObject won4;

    [SerializeField] private Vector2 _paddleRespawnPos;
    private Vector2 _ballRespawnPos; // 리스폰 위치 = 패들pos + _respawnPos
    private bool _isShootBall = false; // 발사하고나서 다 죽을때까지 true
    private int _life = 3; // 밸런스 수정하셔도됩니다!

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
        blockArr[0] = won0;
        blockArr[1] = won1;
        blockArr[2] = won2;
        blockArr[3] = won3;
        blockArr[4] = won4;

        _ballRespawnPos = _paddleRespawnPos + (Vector2.up * 0.5f);

        SetBlock(0);
        GameStart();
    }

    public void GameStart() // 게임 시작& 재시작
    {
        if (_life >= 0)
        {
            _isShootBall = false;
            _life--;


            _paddle._Arrow.SetActive(true);
            _paddle.transform.position = _paddleRespawnPos;
            _paddle._rigidbody.velocity = Vector2.zero;

            BallManager.I.MakeBall();
            BallScript newBall = BallManager.I.lastMakeBall;

            newBall.transform.position = _ballRespawnPos;
            newBall.transform.rotation = Quaternion.identity;
            newBall._rigidbody.isKinematic = true;
        }
        else
        {
            // 여기에 라이프 0일 경우 처리
        }
    }
    //고칠점...
    public void SetBlock(int level)
    {
        //level은 이후 개발에 따라 변경.(매개변수 자체를 없앨 수도.)
        switch (level)
        {
            case 0:
                //level = 1, blockCount == 30 (5 * 6)
                //50000 * 5, 10000 * 10, 5000 * 5, 1000 * 10(임시)
                {
                    int count = 0;
                    int[] imageNum = new int[50];
                    while (count < 10)
                    {
                        imageNum[count] = 0;
                        count++;
                    }
                    while (count < 15)
                    {
                        imageNum[count] = 1;
                        count++;
                    }
                    while (count < 25)
                    {
                        imageNum[count] = 2;
                        count++;
                    }
                    while (count < 30)
                    {
                        imageNum[count] = 3;
                        count++;
                    }

                    imageNum = imageNum.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

                    for (int i = 0; i < 30; i++)
                    {
                        GameObject newBlock = Instantiate(blockArr[imageNum[i]]);
                        newBlock.transform.parent = GameObject.Find("BlockPar").transform;

                        float x = (i % 5) * 0.84f - 1.68f;
                        float y = 3.20f - (i / 5) * 0.54f;

                        newBlock.transform.position = new Vector3(x, y, 0);
                        newBlock.transform.localScale = new Vector3(0.22f, 0.22f, 0f);
                    }
                }
                break;
            case 1:
                //level = 2, blockCount == 40(5 * 8)
                //50000 * 10, 10000 * 20, 5000 * 6, 1000 * 4(임시)
                {
                    int count = 0;
                    int[] imageNum = new int[40];
                    while (count < 4)
                    {
                        imageNum[count] = 0;
                        count++;
                    }
                    while (count < 10)
                    {
                        imageNum[count] = 1;
                        count++;
                    }
                    while (count < 30)
                    {
                        imageNum[count] = 2;
                        count++;
                    }
                    while (count < 40)
                    {
                        imageNum[count] = 3;
                        count++;
                    }

                    imageNum = imageNum.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

                    for (int i = 0; i < 40; i++)
                    {
                        GameObject newBlock = Instantiate(blockArr[imageNum[i]]);
                        newBlock.transform.parent = GameObject.Find("BlockPar").transform;

                        float x = (i % 5) * 0.84f - 1.68f;
                        float y = 3.20f - (i / 5) * 0.54f;

                        newBlock.transform.position = new Vector3(x, y, 0);
                        newBlock.transform.localScale = new Vector3(0.22f, 0.22f, 0f);
                    }
                }
                break;
            case 2:
                //level = 3, blockCount == 50
                //50000 * 20, 10000 * 25, 5000 * 4, 1000 * 1(임시)
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

                    imageNum = imageNum.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

                    for (int i = 0; i < 50; i++)
                    {
                        GameObject newBlock = Instantiate(blockArr[imageNum[i]]);
                        newBlock.transform.parent = GameObject.Find("BlockPar").transform;

                        float x = (i % 5) * 0.84f - 1.68f;
                        float y = 3.20f - (i / 5) * 0.54f;

                        newBlock.transform.position = new Vector3(x, y, 0);
                        newBlock.transform.localScale = new Vector3(0.22f, 0.22f, 0f);
                    }
                }
                break;
        }
    }
}
