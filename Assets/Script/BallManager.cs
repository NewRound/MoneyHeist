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

    public void DivideBall()
    {
        MakeBall();
        float maxPosY = -10;
        int ballIndex = 0;
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].transform.position.y > maxPosY && balls[i] != lastMakeBall && balls[i].gameObject.activeSelf ==true )
            {
                maxPosY = balls[i].transform.position.y;
                ballIndex = i;
                break;
            }


        }

        lastMakeBall.transform.position = balls[ballIndex].transform.position;
        lastMakeBall._ballShottingPow = balls[ballIndex]._ballShottingPow;
        Vector3 oldVelocity = balls[ballIndex]._rigidbody.velocity;
        Vector3 newVelocity = new Vector3 (oldVelocity.x * -1, oldVelocity.y, 0).normalized;
        lastMakeBall._rigidbody.bodyType = RigidbodyType2D.Dynamic;
        lastMakeBall._rigidbody.velocity = newVelocity * lastMakeBall._ballShottingPow;
    }



}
