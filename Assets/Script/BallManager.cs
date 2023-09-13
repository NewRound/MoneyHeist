using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager I;

    [SerializeField] GameObject ball;
    public List<BallScript> balls = new();
    public BallScript lastMakeBall;
    private Vector3 originalScale; // 원래 스케일 값 저장 변수

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

    // 볼 크기 증가
    public void ExpandCollider(BallScript ball, bool isWork)
    {
        if (isWork)
        {
            originalScale = ball.transform.localScale;
            // 볼 게임 오브젝트의 스케일을 증가시킵니다.
            Vector3 newScale = ball.transform.localScale * 1.25f;
            ball.transform.localScale = newScale;
        }
        else
        {
            ball.transform.localScale = originalScale;
        }
    }
}
