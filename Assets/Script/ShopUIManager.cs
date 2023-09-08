using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.TextCore.Text;

public class ShopUIManager : MonoBehaviour
{
    public ShopUIData[] ItemList;
    public Image imagePrefab;
    public GameObject[] parentTransform;

    private void Start()
    {
        int buffIndex = 0;
        int skinIndex = 0;

        foreach (var item in ItemList)
        {
            if (item.itemType == ItemType.Buff)
            {
                createItem(item, buffIndex, parentTransform[0].transform);
                buffIndex++;
            }
            else if (item.itemType == ItemType.Skin)
            {
                createItem(item, skinIndex, parentTransform[1].transform);
                skinIndex++;
            }
        }
    }

    private void createItem(ShopUIData ItemData, int i,Transform pos)
    {
                float posY = +750 - ((i / 3) * 500);
                float posX = ((i % 3) * 350) - 350;
                // �̹��� UI ��� ����
                Image imageUI = Instantiate(imagePrefab, pos);

                // �̹��� ��ġ ����
                RectTransform rectTransform = imageUI.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(posX, posY);

                // ������ �����ͷ� UI ������Ʈ (��: �̹��� ��������Ʈ ����)
                Image[] childImages = imageUI.GetComponentsInChildren<Image>(); // �ڽ� ������Ʈ���� ��� Image ������Ʈ ��������
                foreach (Image childImage in childImages)
                {
                    if (childImage.name == "itemImage")
                    {
                        childImage.sprite = ItemData.itemImage;
                        break; // �̹����� ã������ ���� ����
                    }
                }

                TMP_Text childText = imageUI.GetComponentInChildren<TMP_Text>(); // �ڽ� ������Ʈ���� text ������Ʈ ã��
                if (childText != null)
                {
                    childText.text = ItemData.itemName; // itemName ����
                }
        
    }
}


