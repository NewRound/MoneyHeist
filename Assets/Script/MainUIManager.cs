using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public static MainUIManager I;

    private void Awake()
    {
        I = this;
    }

    public TextMeshProUGUI _timetxt;

}
