using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject setCanvas;
    [SerializeField] GameObject audio;
    [SerializeField] GameObject audioSettingBar;

    AudioSource audioSource;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        startCanvas.SetActive(true);
        levelCanvas.SetActive(false);
        setCanvas.SetActive(false);
        audioSource = audio.GetComponent<AudioSource>();
        audioSettingBar.GetComponent<Slider>().value = DataManager.DMinstance.volume;
    }

    public void ShopOpen()
    {
        DataManager.DMinstance.volume = audioSource.volume;
        SceneManager.LoadScene("ShopScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        DataManager.DMinstance.volume = audioSource.volume;
        SceneManager.LoadScene("MainScene");
    }


}
