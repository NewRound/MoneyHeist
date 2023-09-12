using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void ShopOpen()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");

    }


}
