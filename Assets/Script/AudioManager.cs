using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = DataManager.DMinstance.volume;
        Debug.Log($"AudioManager Awake => {gameObject.GetComponent<AudioSource>().volume}");
    }
}
