using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DataManager : MonoBehaviour
{
    public static DataManager DMinstance;

    public int level;
    public float paddleSpeed;
    public int ballDamage;
    public float ballSpeed;

    public Sprite selectedPaddleImage;
    public Sprite selectedballImage;


    private void Awake()
    {
        if( DMinstance == null )
        {
            DMinstance = this;
            DontDestroyOnLoad( DMinstance );
        }

    }

    private void Start()
    {
        level = 0;
        paddleSpeed = 150;
        ballDamage = 1;
        ballSpeed = 5;
    }

    public void SelectLevel()
    {
        string buttenName = EventSystem.current.currentSelectedGameObject.name;
        level = buttenName[6] - '0';
        Debug.Log($" {level} ");
    }

}
