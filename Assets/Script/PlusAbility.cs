using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusAbility : MonoBehaviour
{
    public TMP_Text ballDamage;
    public TMP_Text ballSpeed;
    public TMP_Text paddleSpeed;
    void Start()
    {
        ballDamage.text = DataManager.DMinstance.ballDamage.ToString();
        ballSpeed.text = DataManager.DMinstance.ballSpeed.ToString();
        paddleSpeed.text = DataManager.DMinstance.paddleSpeed.ToString();
    }

    public void ballDamageBtn()
    {
        DataManager.DMinstance.ballDamage += 1;
        ballDamage.text = DataManager.DMinstance.ballDamage.ToString();
    }
    public void ballSpeedBtn()
    {
        DataManager.DMinstance.ballSpeed += 0.5f;
        ballSpeed.text = DataManager.DMinstance.ballSpeed.ToString();
    }
    public void paddleSpeedBtn()
    {
        DataManager.DMinstance.paddleSpeed += 0.5f;
        paddleSpeed.text = DataManager.DMinstance.paddleSpeed.ToString();
    }
}
