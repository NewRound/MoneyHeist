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
        labelTxt.text = "공 스킨";

        anim = parentTransform.GetComponent<Animator>();
    }


    private void createItem(ShopUIData ItemData, int i, Transform pos, ItemType itemType)
    {
        float posY = 700 - ((i / 2) * 600);
        float posX = ((i % 2) * 500) - 250;
        // 이미지 UI 요소 생성
        Image imageUI = Instantiate(imagePrefab, pos);

        // 이미지 위치 설정
        RectTransform rectTransform = imageUI.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(posX, posY);

        // 아이템 데이터로 UI 업데이트 (예: 이미지 스프라이트 설정)
        Image[] childImages = imageUI.GetComponentsInChildren<Image>(); // 자식 오브젝트에서 모든 Image 컴포넌트 가져오기
        foreach (Image childImage in childImages)
        {
            if (childImage.name == "itemImage")
            {
                childImage.sprite = ItemData.itemImage;
                break; // 이미지를 찾았으면 루프 종료
            }
        }

        TMP_Text childText = imageUI.GetComponentInChildren<TMP_Text>(); // 자식 오브젝트에서 text 컴포넌트 찾기
        if (childText != null)
        {
            childText.text = ItemData.itemName; // itemName 변경
        }

        // 아이템의 itemType 설정
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
        // 애니메이션 재생 중 대기
        yield return new WaitForSeconds(0.4f);
        // 현재 활성화된 background
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
            // 현재 활성화된 background를 비활성화
            activeBackground.SetActive(false);

            // 다음 인덱스를 계산
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

            // 다음 background를 활성화
            background[index].SetActive(true);

            // labelTxt를 업데이트
            if (index == 0)
            {
                labelTxt.text = "공 스킨";
            }
            else if (index == 1)
            {
                labelTxt.text = "패들 스킨";
            }
            else if (index == 2)
            {
                labelTxt.text = "능력치";
            }
        }
    }
}


