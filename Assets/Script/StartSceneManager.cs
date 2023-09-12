using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject setCanvas;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        startCanvas.SetActive(true);
        levelCanvas.SetActive(false);
        setCanvas.SetActive(false);
    }

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
