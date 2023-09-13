using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusAbility : MonoBehaviour
{
    public TMP_Text ballDamage;
    public TMP_Text ballSpeed;
    public TMP_Text paddleSpeed;

    public TMP_Text ballDamagePrice;
    public TMP_Text ballSpeedPrice;
    public TMP_Text paddleSpeedPrice;

    int bDamagePrice;
    int bSpeedPrice;
    int pSpeedPrice;
    void Start()
    {
        ballDamage.text = DataManager.DMinstance.ballDamage.ToString();
        ballSpeed.text = DataManager.DMinstance.ballSpeed.ToString();
        paddleSpeed.text = DataManager.DMinstance.paddleSpeed.ToString();

        bDamagePrice = 500 + (100 * (DataManager.DMinstance.ballDamage-1));
        bSpeedPrice = (int)(100 + (100 * ((DataManager.DMinstance.ballSpeed - 5)/0.5)));
        pSpeedPrice = (int)(100 + (100 * ((DataManager.DMinstance.paddleSpeed - 150) / 0.5)));

        ballDamagePrice.text = bDamagePrice.ToString();
        ballSpeedPrice.text = bSpeedPrice.ToString();
        paddleSpeedPrice.text = pSpeedPrice.ToString();
    }

    public void ballDamageBtn()
    {
        if (DataManager.DMinstance.gold >= bDamagePrice)
        {
            DataManager.DMinstance.ballDamage += 1;
            ballDamage.text = DataManager.DMinstance.ballDamage.ToString();
            DataManager.DMinstance.gold -= bDamagePrice;
            bDamagePrice += 100;
            ballDamagePrice.text = bDamagePrice.ToString();
        }
    }
    public void ballSpeedBtn()
    {
        if (DataManager.DMinstance.gold >= bSpeedPrice)
        {
            DataManager.DMinstance.ballSpeed += 0.5f;
            ballSpeed.text = DataManager.DMinstance.ballSpeed.ToString();
            DataManager.DMinstance.gold -= bSpeedPrice;
            bSpeedPrice += 100;
            ballSpeedPrice.text = bSpeedPrice.ToString();
        }
    }
    public void paddleSpeedBtn()
    {
        if (DataManager.DMinstance.gold >= pSpeedPrice)
        {
            DataManager.DMinstance.paddleSpeed += 0.5f;
            paddleSpeed.text = DataManager.DMinstance.paddleSpeed.ToString();
            DataManager.DMinstance.gold -= pSpeedPrice;
            pSpeedPrice += 100;
            paddleSpeedPrice.text = pSpeedPrice.ToString();
        }
    }
}
