using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    #region UI
    [SerializeField] GameObject EndGameUI;
    [SerializeField] GameObject PauseGameUI;

    public int score;
    private int maxScore;
    #endregion

    public GameObject _ball;
    public PadScript _paddle;
    public SpriteRenderer paddleImage;


    [SerializeField] private Vector2 _paddleRespawnPos;
    private Vector2 _ballRespawnPos; // 리스폰 위치 = 패들pos + _respawnPos

    public int blockCount;
    private float gameLimitTime = 60.0f;
    private float gameTime;
    public bool _isGaming = false;
    private bool _isShootBall = false; // 발사하고나서 다 죽을때까지 true
    private int _life; // 밸런스 수정하셔도됩니다!
    public bool IsShootBall { get { return _isShootBall; } set { _isShootBall = value; } }

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        blockCount = (DataManager.DMinstance.level) * 10 + 20;
        score = 0;
        if (!PlayerPrefs.HasKey("MaxScore"))
        {
            maxScore = 0;
            Debug.Log("maxScore -> Set");
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }
        else
        {
            Debug.Log("maxScore -> Load");
            maxScore = PlayerPrefs.GetInt("MaxScore");
        }
        Time.timeScale = 1;
        gameTime = gameLimitTime;
        _life = 4;
        _isGaming = false;
        _isShootBall = false;
        EndGameUI.SetActive(false);
        PauseGameUI.SetActive(false);

        _ballRespawnPos = _paddleRespawnPos + (Vector2.up * 0.5f);
        if(DataManager.DMinstance.selectedPaddleImage != null)paddleImage.sprite = DataManager.DMinstance.selectedPaddleImage;

        GameStart();
    }

    private void Update()
    {
        if (_isGaming && gameTime>0)
        {
            gameTime -= Time.deltaTime;
            if (gameTime < 0)
                gameTime = 0;

            MainUIManager.I._scoretxt.text = score.ToString();
            MainUIManager.I._timetxt.text = gameTime.ToString("N2");
        }
        else if (gameTime <= 0)
        {
            _life = -1;
            EndGame();
        }
    }

    public void GameStart() // 게임 시작& 재시작
    {
        if (_life > 0 && gameTime >0)
        {
            _isShootBall = false;
            _life--;
            MainUIManager.I._lifetxt.text = _life.ToString();

            _paddle._Arrow.SetActive(true);
            _paddle.transform.position = _paddleRespawnPos;
            _paddle._rigidbody.velocity = Vector2.zero;

            BallManager.I.MakeBall();
            BallScript newBall = BallManager.I._lastMakeBall;

            newBall.transform.position = _ballRespawnPos;
            newBall.transform.rotation = Quaternion.identity;
            newBall._rigidbody.isKinematic = true;
        }
        else
        {
            // 여기에 라이프 0일 경우 처리
            EndGame();
        }
    }
    public void EndGame()
    {
        // 시간 멈춤
        Time.timeScale = 0;

        // 종료 UI 부르기.
        EndGameUI.SetActive(true);

        // 점수 계산해서 넣어주기.
        // 얻은 돈 *( {남은 시간 / 시작 시간} + 최소값)
        MainUIManager.I._totaltxt.text = ((int)((score / 100) * ((gameTime / gameLimitTime) + 0.2))).ToString();
        Debug.Log($"{(int)((score / 100) * ((gameTime / gameLimitTime) + 0.2))}");

        // 하이스코어 계산
        if (maxScore < (int)((score / 100) * ((gameTime / gameLimitTime) + 0.2)))
        {
            maxScore = (int)((score / 100) * ((gameTime / gameLimitTime) + 0.2));
            PlayerPrefs.SetInt("MaxScore", (int)((score / 100) * ((gameTime / gameLimitTime) + 0.2)));
        }
        MainUIManager.I._maxtxt.text = maxScore.ToString();
    }

    // 일시정지
    public void Pause()
    {
        Time.timeScale = 0;
        PauseGameUI.SetActive(true);
        // 다시 시작
    }

    public void StopPause()
    {
        Time.timeScale = 1;
        PauseGameUI.SetActive(false);
    }

    // 다시하기 (씬 로드)
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    // 상점으로 이동
    public void MoveToShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }

    // 시작 씬으로 이동
    public void MoveToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
