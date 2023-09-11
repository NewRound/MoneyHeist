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
        labelTxt.text = "버프 아이템";

        anim = parentTransform.GetComponent<Animator>();
    }

    private void createItem(ShopUIData ItemData, int i,Transform pos)
    {
                float posY = +750 - ((i / 3) * 500);
                float posX = ((i % 3) * 350) - 350;
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
        // 애니메이션 재생 중 대기
        yield return new WaitForSeconds(0.4f);
        if (background[0].activeSelf)
        {
            labelTxt.text = "스킨 아이템";
            background[0].SetActive(false);
            background[1].SetActive(true);
        }
        else if (background[1].activeSelf)
        {
            labelTxt.text = "버프 아이템";
            background[0].SetActive(true);
            background[1].SetActive(false);
        }      
    }
}


