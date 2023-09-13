using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public enum BlockType { Won1000, Won5000, Won10000, Won50000, WonGold }

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private List<BlockData> blockDatas;
    [SerializeField]
    private GameObject blockPrefab;
    
    private void Start()
    {
        //���� ȣ��Ǵ��� ���� ���� �߻� ���ɼ��� ����.
        //�ٵ� �Ƹ��� �� ������Ʈ�� ���� ������ ��(���ξ����� �̵����� ��) ȣ�� �� ��.
        int level = DataManager.DMinstance.level;
        switch (level)
        {
            case 1:
                //level = 1, blockCount == 30 (5 * 6)
                //50000 * 5, 10000 * 10, 5000 * 5, 1000 * 10(�ӽ�)
                {
                    int count = 0;
                    int[] blockNum = new int[30];
                    while (count < 10)
                    {
                        blockNum[count] = 0;
                        count++;
                    }
                    while (count < 15)
                    {
                        blockNum[count] = 1;
                        count++;
                    }
                    while (count < 25)
                    {
                        blockNum[count] = 2;
                        count++;
                    }
                    while (count < 30)
                    {
                        blockNum[count] = 3;
                        count++;
                    }
                    blockNum = blockNum.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

                    for (int i = 0; i < blockNum.Length; i++)
                    {
                        float posX = (i % 5) * 0.84f - 1.68f;
                        float posY = 3.20f - (i / 5) * 0.54f;
                        float size = 0.22f;
                        SpawnBlock(blockNum[i], posX, posY, size);
                    }
                }
                break;
            case 2:
                //level = 2, blockCount == 40(5 * 8)
                //50000 * 10, 10000 * 20, 5000 * 6, 1000 * 4(�ӽ�)
                {
                    int count = 0;
                    int[] blockNum = new int[40];
                    while (count < 4)
                    {
                        blockNum[count] = 0;
                        count++;
                    }
                    while (count < 10)
                    {
                        blockNum[count] = 1;
                        count++;
                    }
                    while (count < 30)
                    {
                        blockNum[count] = 2;
                        count++;
                    }
                    while (count < 40)
                    {
                        blockNum[count] = 3;
                        count++;
                    }

                    blockNum = blockNum.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

                    for (int i = 0; i < blockNum.Length; i++)
                    {
                        float posX = (i % 5) * 0.84f - 1.68f;
                        float posY = 3.20f - (i / 5) * 0.54f;
                        float size = 0.22f;
                        SpawnBlock(blockNum[i], posX, posY, size);
                    }
                }
                break;
            case 3:
                //level = 3, blockCount == 50
                //50000 * 20, 10000 * 25, 5000 * 4, 1000 * 1(�ӽ�)
                {
                    int count = 0;
                    int[] blockNum = new int[50];
                    while (count < 1)
                    {
                        blockNum[count] = 0;
                        count++;
                    }
                    while (count < 5)
                    {
                        blockNum[count] = 1;
                        count++;
                    }
                    while (count < 30)
                    {
                        blockNum[count] = 2;
                        count++;
                    }
                    while (count < 50)
                    {
                        blockNum[count] = 3;
                        count++;
                    }

                    blockNum = blockNum.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

                    for (int i = 0; i < blockNum.Length; i++)
                    {
                        float posX = (i % 5) * 0.84f - 1.68f;
                        float posY = 3.20f - (i / 5) * 0.54f;
                        float size = 0.22f;
                        SpawnBlock(blockNum[i], posX, posY, size);
                    }
                }
                break;
        }
        
    }
    public void SpawnBlock(int _typeNum , float _posX, float _posY, float size)
    {
        var newBlock = Instantiate(blockPrefab).GetComponent<Block>();
        //find ��ü �ʿ�
        newBlock.transform.parent = GameObject.Find("BlockSpawner").transform;

        //��ũ���ͺ� ������Ʈ ������ ����.
        newBlock.blockData = blockDatas[_typeNum];
        newBlock.name = newBlock.blockData.blockName;

        //��� ������ ����
        newBlock.transform.position = new Vector2(_posX, _posY);
        newBlock.transform.localScale = new Vector2(size, size);
    }

}
