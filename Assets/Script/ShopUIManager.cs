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
    public GameObject[] background;
    public GameObject parentTransform;
    public TMP_Text labelTxt;

    private Animator anim;

    private void Start()
    {
        int buffIndex = 0;
        int skinIndex = 0;

        foreach (var item in ItemList)
        {
            if (item.itemType == ItemType.Buff)
            {
                createItem(item, buffIndex, background[0].transform);
                buffIndex++;
            }
            else if (item.itemType == ItemType.Skin)
            {
                createItem(item, skinIndex, background[1].transform);
                skinIndex++;
            }
        }
        labelTxt.text = "�� ��Ų";

        anim = parentTransform.GetComponent<Animator>();
    }

    private void createItem(ShopUIData ItemData, int i,Transform pos)
    {
                float posY = 600 - ((i / 2) * 600);
                float posX = ((i % 2) * 500) - 250;
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
    
    public void next()
    {
        parentTransform.SetActive(true);
        StartCoroutine(ChangeList());
        
    }

    public void prev()
    {
        parentTransform.SetActive(true);
        StartCoroutine(ChangeList());
    }
    IEnumerator ChangeList()
    {
        // �ִϸ��̼� ��� �� ���
        yield return new WaitForSeconds(0.4f);
        if (background[0].activeSelf)
        {
            labelTxt.text = "�е� ��Ų";
            background[0].SetActive(false);
            background[1].SetActive(true);
        }
        else if (background[1].activeSelf)
        {
            labelTxt.text = "�� ��Ų";
            background[0].SetActive(true);
            background[1].SetActive(false);
        }      
    }
}


