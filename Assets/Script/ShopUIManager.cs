using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.TextCore.Text;

public class ShopUIManager : MonoBehaviour
{
    public List<ShopUIData> ItemData;
    public Image imagePrefab;
    public Transform parentTransform;

    private void Start()
    {
        for (int i = 0; i < ItemData.Count; i++)
        {
            float posY = +750-((i/3)*500);
            float posX = ((i%3)*350)-350;
            // �̹��� UI ��� ����
            Image imageUI = Instantiate(imagePrefab, parentTransform);

            // �̹��� ��ġ ����
            RectTransform rectTransform = imageUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(posX, posY);

            // ������ �����ͷ� UI ������Ʈ (��: �̹��� ��������Ʈ ����)
            Image[] childImages = imageUI.GetComponentsInChildren<Image>(); // �ڽ� ������Ʈ���� ��� Image ������Ʈ ��������
            foreach (Image childImage in childImages)
            {
                if (childImage.name == "itemImage")
                {
                    childImage.sprite = ItemData[i].itemImage;
                    break; // �̹����� ã������ ���� ����
                }
            }

            TMP_Text childText = imageUI.GetComponentInChildren<TMP_Text>(); // �ڽ� ������Ʈ���� text ������Ʈ ã��
            if (childText != null)
            {
                childText.text = ItemData[i].itemName; // itemName ����
            }
        }
    }
}
