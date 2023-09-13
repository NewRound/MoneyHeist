using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropItem : MonoBehaviour
{
    [SerializeField]
    private List<ShopUIData> dropItemDatas;
    [SerializeField]
    private GameObject DropItemPrefab;

    public void SpawnDropItem(Vector3 vecPos)
    {
        var dropItem = Instantiate(DropItemPrefab).GetComponent<Block>();
        //find 대체 필요. 시리얼라이즈로 파일 받고? 부모로?
        dropItem.transform.parent = GameObject.Find("BlockSpawner").transform;

        dropItem.name = "졸려";
        
        
        dropItem.transform.position = vecPos;
        dropItem.transform.localScale = new Vector3(0.22f, 0.22f, 1);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Paddle")
        {
            //효과 적용

            Destroy(gameObject);
        }
    }
}

