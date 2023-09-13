using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DataManager : MonoBehaviour
{
    public static DataManager DMinstance;

    public int gold;

    public GameObject Auido;

    public int level;
    public float paddleSpeed;
    public int ballDamage;
    public float ballSpeed;

    public Sprite selectedPaddleImage;
    public Sprite selectedballImage;

    [SerializeField] Sprite basePaddleImage;
    [SerializeField] Sprite baseBallImage;


    private void Awake()
    {
        // SoundManager 인스턴스가 이미 있는지 확인, 이 상태로 설정
        if (DMinstance == null)
            DMinstance = this;

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (DMinstance != this)
            Destroy(gameObject);

        // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        level = 0;
        gold = 1000;
        paddleSpeed = 150;
        ballDamage = 1;
        ballSpeed = 5;
        setBaseImage();
    }

    public void setBaseImage()
    {
        selectedPaddleImage = basePaddleImage;
        selectedballImage = baseBallImage;
    }
}
