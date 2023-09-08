using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    bool isShootBall = false;
    public bool IsShootBall { get { return isShootBall; }set { isShootBall = value; } }

    private void Awake()
    {
        GM = this;
    }
}
