using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusAbility : MonoBehaviour
{
    public TMP_Text ballDamage;
    public TMP_Text ballSpeed;
    public TMP_Text paddleSpeed;
    DataManager dm = DataManager.DMinstance;
    void Start()
    {
        ballDamage.text = dm.ballDamage.ToString();
        ballSpeed.text = dm.ballSpeed.ToString();
        paddleSpeed.text = dm.paddleSpeed.ToString();
    }

    public void ballDamageBtn()
    {
        dm.ballDamage += 1;
        ballDamage.text = dm.ballDamage.ToString();
    }
    public void ballSpeedBtn()
    {
        dm.ballSpeed += 0.5f;
        ballSpeed.text = dm.ballSpeed.ToString();
    }
    public void paddleSpeedBtn()
    {
        dm.paddleSpeed += 0.5f;
        paddleSpeed.text = dm.paddleSpeed.ToString();
    }
}
