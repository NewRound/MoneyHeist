using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



}
