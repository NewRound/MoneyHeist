using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager I;

    [SerializeField] GameObject ball;
    public List<BallScript> balls = new();
    public BallScript lastMakeBall;

    private void Awake()
    {
        I = this;
    }


    // º¼ µü ¸¸µé±â
    public void MakeBall()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].gameObject.activeSelf == false)
            {
                lastMakeBall = balls[i];
                balls[i].gameObject.SetActive(true);
                return;
            }
        }

        lastMakeBall = Instantiate(ball).GetComponent<BallScript>();
        lastMakeBall.name = "Ball";
        balls.Add(lastMakeBall);
    }

}
