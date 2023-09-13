using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DataManager : MonoBehaviour
{
    public static DataManager DMinstance;

    public int gold;

    public float volume;

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
        // SoundManager �ν��Ͻ��� �̹� �ִ��� Ȯ��, �� ���·� ����
        if (DMinstance == null)
            DMinstance = this;

        // �ν��Ͻ��� �̹� �ִ� ��� ������Ʈ ����
        else if (DMinstance != this)
            Destroy(gameObject);

        // �̷��� �ϸ� ���� scene���� �Ѿ�� ������Ʈ�� ������� �ʽ��ϴ�.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        level = 0;
        volume = 1.0f;
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
