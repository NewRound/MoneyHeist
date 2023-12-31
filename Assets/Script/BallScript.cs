using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public CircleCollider2D _circleCollider;
    public SpriteRenderer _sprite;
    public TrailRenderer _trailRenderer;
    public GameObject _moneyBag;

    public float _ballShottingPow;
    public int _dmg;

    private void Start()
    {
        if (DataManager.DMinstance.selectedballImage != null) _sprite.sprite = DataManager.DMinstance.selectedballImage;
        _dmg = DataManager.DMinstance.ballDamage;
    }
    private void FixedUpdate()
    {
        if (GameManager.I.IsShootBall == false)
            return;

        RotateSprite();
        DeathCheck();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        float rangeX = Random.Range(-0.1f, +0.1f);
        float rangeY = Random.Range(-0.1f, +0.1f);

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
        _rigidbody.velocity = NextDir.normalized * _ballShottingPow;
    }


    private void RotateSprite()
    {
        Vector2 dir = Vector2.zero - _rigidbody.velocity.normalized;
        float _rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _rotZ + 90);
        _sprite.flipX = Mathf.Abs(_rotZ) > 90f;
    }

    private void DeathCheck()
    {
        if (transform.position.y > -5)
            return;

        _trailRenderer.Clear();
        _moneyBag.SetActive(false);
        gameObject.SetActive(false);
        BallManager.I._disabledBalls.Enqueue(this);
        List<BallScript> _checkList = BallManager.I._balls;

        for (int i = 0; i < _checkList.Count; i++)
        {
            if (_checkList[i].gameObject.activeSelf == true && _checkList[i] != this)
                break;

            if (i == _checkList.Count - 1)
                GameManager.I.GameStart();
        }
    }

}
