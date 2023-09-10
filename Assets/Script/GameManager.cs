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
    [SerializeField] GameObject _block;

    private Sprite[] blockImg = new Sprite[5];
    [SerializeField] Sprite won0;
    [SerializeField] Sprite won1;
    [SerializeField] Sprite won2;
    [SerializeField] Sprite won3;
    [SerializeField] Sprite won4;

    private Vector2 _respawnPos; // 리스폰 위치 = 패들pos + _respawnPos
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
        _respawnPos = new Vector2(0, 0.5f);
        blockImg[0] = won0;
        blockImg[1] = won1;
        blockImg[2] = won2;
        blockImg[3] = won3;
        blockImg[4] = won4;
    }

    public void GameStart() // 게임 시작& 재시작
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
            // 여기에 라이프 0일 경우 처리
        }
    }
    public void SetBlock(int level)
    {
        switch (level)
        {
            case 0:
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
                        GameObject newBlock = Instantiate(_block);
                        newBlock.transform.parent = GameObject.Find("BlockPar").transform;

                        float x = (i % 5) * 0.84f - 1.68f;
                        float y = 3.20f - (i / 5) * 0.54f;
                        newBlock.transform.position = new Vector3 (x, y, 0);

                        newBlock.transform.localScale = new Vector3(0.22f, 0.22f, 0f);

                        newBlock.transform.GetComponent<SpriteRenderer>().sprite = blockImg[imageNum[i]];
                    }
                }
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
