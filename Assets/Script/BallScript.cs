using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    SpriteRenderer _sprite;
    GameObject _moneyBag;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        _moneyBag = transform.Find("MainSprite").Find("MoneyBag").gameObject;
        Destroy(transform.Find("Line").gameObject);
    }

    private void FixedUpdate()
    {
        Vector2 dir = Vector2.zero - _rigidbody.velocity.normalized;
        float _rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _rotZ +90);
        _sprite.flipX = Mathf.Abs(_rotZ) > 90f;

        if (transform.position.y < -5)
        {
            Destroy(gameObject);

            if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)
            {
                GameManager.I.GameStart();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Paddle")
        {
            _moneyBag.SetActive(false);
        }
        else if (coll.gameObject.tag == "Money")
        {
            _moneyBag.SetActive(true);
        }
    }


}
