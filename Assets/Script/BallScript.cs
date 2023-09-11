
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public SpriteRenderer _sprite;
    public GameObject _moneyBag;
    public float _ballPow;
    public GameObject _line;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        _moneyBag = transform.Find("MainSprite").Find("MoneyBag").gameObject;
    }

    private void FixedUpdate()
    {
        if (GameManager.I.IsShootBall == false)
            return;

        Vector2 dir = Vector2.zero - _rigidbody.velocity.normalized;
        float _rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _rotZ + 90);
        _sprite.flipX = Mathf.Abs(_rotZ) > 90f;

        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
            List<BallScript> checkList = BallManager.I.balls;
            for (int i = 0; i < checkList.Count; i++)
            {
                if (checkList[i].enabled == true && checkList[i] != this)
                    break;

                GameManager.I.GameStart();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        float rangeX = Random.Range(-0.05f, +0.05f);
        float rangeY = Random.Range(-0.05f, +0.05f);

        if (coll.gameObject.tag == "Paddle")
        {
            _moneyBag.SetActive(false);
            float contectX = transform.position.x - coll.transform.position.x;
            float per = Mathf.Abs(contectX) / (coll.gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f);
            per = contectX >= 0 ? per * +1 : per * -1;
            rangeX += per * 0.7f;
        }
        else if (coll.gameObject.tag == "Money")
        {
            _moneyBag.SetActive(true);
        }

        Vector2 currentDir = _rigidbody.velocity.normalized;
        Vector2 NextDir = new Vector2(currentDir.x + rangeX, currentDir.y + rangeY);
        _rigidbody.velocity = NextDir.normalized * _ballPow;
    }
}
