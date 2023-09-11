using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int score;
    [SerializeField] double dropPer;

    //replace with teamate's variable
    int playerScore = 0;
    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "")
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
                    //Call dropItemFunc
                }

                playerScore += score;
                Destroy(gameObject);
            }
        }
    }
}
