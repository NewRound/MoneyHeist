using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopClose : MonoBehaviour
{
    public void closeBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
