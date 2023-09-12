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


    // 볼 딱 만들기
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

        lastMakeBall = Instantiate(ball).GetComponentInChildren<BallScript>();
        lastMakeBall.name = "Ball";
        balls.Add(lastMakeBall);
    }

    // 공 분할
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
                continue;
            }
        }

        lastMakeBall.transform.position = balls[ballIndex].transform.position;
        lastMakeBall._ballShottingPow = balls[ballIndex]._ballShottingPow;
        Vector3 oldVelocity = balls[ballIndex]._rigidbody.velocity;
        Vector3 newVelocity = new Vector3 (oldVelocity.x * -1, oldVelocity.y, 0).normalized;
        lastMakeBall._rigidbody.bodyType = RigidbodyType2D.Dynamic;
        lastMakeBall._rigidbody.velocity = newVelocity * lastMakeBall._ballShottingPow;
    }

    // 진규님이 말씀하신 콜라이더 커지는 부분입니다.
    // 기본은 0.14f
    public void ExpandCollider(BallScript ball)
    {
        ball._circleCollider.radius = 0.21f;
    }


}
