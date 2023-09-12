using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DataManager : MonoBehaviour
{
    private static DataManager DMinstance;

    int level;
    int lenght;
    int ballCount;
    int ballSpeed;


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
        lenght = 0;
        ballCount = 1;
        ballSpeed = 0;
    }

    public void SelectLevel()
    {
        string buttenName = EventSystem.current.currentSelectedGameObject.name;
        level = buttenName[6] - '0';

        // 테스트용
        PlayerPrefs.SetInt("Level", level);
    }

}
