using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //������(��ũ���ͺ� ������Ʈ)
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

    //��ü�� ��.
    int playerScore = 0;
    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            if(hp > 0)
            {
                hp--;
            }
            else        
            {
                //hp == 0

                //
                bool drop = Random.Range(0.0f, 1.0f) > (1 - dropPer);
                if (drop == true)
                {
                    //Call dropItem

                    //Set ItemPos

                    //Item Drop

                    //Item Release

                    //Item Use
                }

                playerScore += score;
                Destroy(gameObject);
            }
        }
    }


}
