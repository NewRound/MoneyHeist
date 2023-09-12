using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour
{
    public void SelectLevel()
    {
        string buttenName = EventSystem.current.currentSelectedGameObject.name;
        DataManager.DMinstance.level = buttenName[6] - '0';
        Debug.Log($" {DataManager.DMinstance.level} ");
    }
}
