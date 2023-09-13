using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //변경점(스크립터블 오브젝트)
    public BlockData blockData;
    [SerializeField] GameObject buffPrefab;

    [SerializeField]
    private Animator anim;

    public int hp;
    public int score;
    public double dropPer;

    private void Start()
    {
        hp = blockData.hp;
        score = blockData.score;
        dropPer = blockData.dropPer;

        gameObject.GetComponent<SpriteRenderer>().sprite = blockData.blockImage;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            hp -= DataManager.DMinstance.ballDamage;
            anim.SetBool("isColl", true);

            if(hp < 1)
            {
                hp = 0;

                //드랍 아이템
                bool drop = Random.Range(0.0f, 1.0f) > (1 - dropPer);
                if (drop == true)
                {
                    var buffItem = Instantiate(buffPrefab).GetComponent<SetBuffItem>();
                }
                
                GameManager.I.score += score;
                GameManager.I.blockCount--;
                Destroy(gameObject, 1.0f);

                Debug.Log(GameManager.I.blockCount);

                if(GameManager.I.blockCount == 0)
                {
                    GameManager.I.EndGame();
                }
            }
        }
    }

}
