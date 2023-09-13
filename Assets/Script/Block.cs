using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //변경점(스크립터블 오브젝트)
    public BlockData blockData;

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

    //교체할 것.
    int playerScore = 0;
    

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            hp -= DataManager.DMinstance.ballDamage;

            if(hp <= 1)
            {
                hp = 0;

                //드랍 아이템
                bool drop = Random.Range(0.0f, 1.0f) > (1 - dropPer);
                if (drop == true)
                {
                    //Call dropItem
                    //SpawnDropItem(gameObject.transform.position);

                    //Set ItemPos

                    //Item Drop

                    //Item Release

                    //Item Use
                }

                GameManager.I.score += score;
                Destroy(gameObject, 1.0f);
            }
        }
    }

}
