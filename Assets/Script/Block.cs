using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Block : MonoBehaviour
{
    //변경점(스크립터블 오브젝트)
    public BlockData blockData;
    [SerializeField] GameObject buffPrefab;

    [SerializeField] Animator anim;

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

            anim.SetTrigger("isColl");

            if(hp < 1)
            {
                anim.SetBool("isBreak", true);
                hp = 0;

                //드랍 아이템
                bool drop = Random.Range(0.0f, 1.0f) > (1 - dropPer);
                if (drop == true)
                {
                    var buffItem = Instantiate(buffPrefab).GetComponent<SetBuffItem>();
                    float posX = gameObject.transform.position.x;
                    float posY = gameObject.transform.position.y;
                    buffItem.transform.position = new Vector3(posX, posY, 0);
                }

                GameManager.I.score += score;
                OffBlock();
            }
        }
    }
    private void OffBlock()
    {
        gameObject.SetActive(false);
        CheckBlock();
    }
    private void CheckBlock()
    {
        int count = DataManager.DMinstance.level*10 + 19;
        int end = 0;
        {
            for(int index = 0; index < count; index++)
            {
                bool notEnd = GameObject.Find("BlockSpawner").transform.GetChild(index).gameObject.activeSelf;
                if (notEnd == true)
                {
                    end++;
                }
            }
            if (end == 0)
            {
                GameManager.I.EndGame();
            }
        }
    }
}
