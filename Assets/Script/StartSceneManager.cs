using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void ChoiceLevel()
    {
        string name = gameObject.name;
        int level = name[6] - '0';

        // 테스트용
        PlayerPrefs.SetInt("Level", level);

        SceneManager.LoadScene("MainScene");

    }


}
