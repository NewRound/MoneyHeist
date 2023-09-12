using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.TextCore.Text;
using System.Reflection;

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
        int ballIndex = 0;
        int paddleIndex = 0;

        foreach (var item in ItemList)
        {
            if (item.itemType == ItemType.Ball)
            {
                createItem(item, ballIndex, background[0].transform, ItemType.Ball);
                ballIndex++;
            }
            else if (item.itemType == ItemType.Paddle)
            {
                createItem(item, paddleIndex, background[1].transform, ItemType.Paddle);
                paddleIndex++;
            }
        }
        labelTxt.text = "�� ��Ų";

        anim = parentTransform.GetComponent<Animator>();
    }


    private void createItem(ShopUIData ItemData, int i, Transform pos, ItemType itemType)
    {
        float posY = 700 - ((i / 2) * 600);
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

        // �������� itemType ����
        BuyItem buyItem = imageUI.GetComponent<BuyItem>();
        if (buyItem != null)
        {
            buyItem.itemType = itemType;
        }

    }

    public void next()
    {
        parentTransform.SetActive(true);
        StartCoroutine(ChangeList(true));
        
    }

    public void prev()
    {
        parentTransform.SetActive(true);
        StartCoroutine(ChangeList(false));
    }
    IEnumerator ChangeList(bool isNext)
    {
        // �ִϸ��̼� ��� �� ���
        yield return new WaitForSeconds(0.4f);
        // ���� Ȱ��ȭ�� background
        GameObject activeBackground = null;
        for (int i = 0; i < background.Length; i++)
        {
            if (background[i].activeSelf)
            {
                activeBackground = background[i];
                break;
            }
        }

        if (activeBackground != null)
        {
            // ���� Ȱ��ȭ�� background�� ��Ȱ��ȭ
            activeBackground.SetActive(false);

            // ���� �ε����� ���
            int currentIndex = Array.IndexOf(background, activeBackground);
            int index = 0;
            if (isNext)
            {
                index = (currentIndex + 1) % background.Length;
            }
            else
            {
                index = (currentIndex - 1 + background.Length) % background.Length;
            }

            // ���� background�� Ȱ��ȭ
            background[index].SetActive(true);

            // labelTxt�� ������Ʈ
            if (index == 0)
            {
                labelTxt.text = "�� ��Ų";
            }
            else if (index == 1)
            {
                labelTxt.text = "�е� ��Ų";
            }
            else if (index == 2)
            {
                labelTxt.text = "�ɷ�ġ";
            }
        }
    }
}


