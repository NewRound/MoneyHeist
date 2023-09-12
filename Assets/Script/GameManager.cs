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
    public SpriteRenderer paddleImage;


    private Vector2 _respawnPos; // 리스폰 위치 = 패들pos + _respawnPos

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

        _respawnPos = new Vector2(0, 0.5f);
        //blockArr[0] = won0;
        //blockArr[1] = won1;
        //blockArr[2] = won2;
        //blockArr[3] = won3;
        //blockArr[4] = won4;
        //SetBlock(PlayerPrefs.GetInt("Level"));


        _ballRespawnPos = _paddleRespawnPos + (Vector2.up * 0.5f);
        if(DataManager.DMinstance.selectedPaddleImage != null)paddleImage.sprite = DataManager.DMinstance.selectedPaddleImage;

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
}
