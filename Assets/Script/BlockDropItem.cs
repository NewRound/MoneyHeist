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

        //find ��ü �ʿ�.
        dropItem.transform.parent = GameObject.Find("BlockSpawner").transform;

        //�̹���,�̸�
        int index = Random.Range(0, dropItemDatas.Count);
        dropItem.name = dropItemDatas[index].itemName;
        dropItem.GetComponent<SpriteRenderer>().sprite = dropItemDatas[index].itemImage;


        //��ġ�� ũ��
        dropItem.transform.position = vecPos;
        dropItem.transform.localScale = new Vector3(0.22f, 0.22f, 1);
    }
    private void Update()
    {
        if(gameObject.transform.position.y < -1485.19f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Paddle")
        {
            //ȿ�� ����


            Destroy(gameObject);
        }
    }
}

