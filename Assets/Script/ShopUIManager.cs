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
        for (int i = 0; i < ItemData.Count / 3; i++)
        {
            float posY = 750 - (500 * i);
            for (int j = 0; j < 3; j++)
            {
                float posX = -350 + (350 * j);
                // 이미지 UI 요소 생성
                Image imageUI = Instantiate(imagePrefab, parentTransform);

                // 이미지 위치 설정
                RectTransform rectTransform = imageUI.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(posX, posY);

                // 아이템 데이터로 UI 업데이트 (예: 이미지 스프라이트 설정)
                Image[] childImages = imageUI.GetComponentsInChildren<Image>(); // 자식 오브젝트에서 모든 Image 컴포넌트 가져오기
                foreach (Image childImage in childImages)
                {
                    if (childImage.name == "itemImage")
                    {
                        childImage.sprite = ItemData[(i * 3) + j].itemImage;
                        break; // 이미지를 찾았으면 루프 종료
                    }
                }

                TMP_Text childText = imageUI.GetComponentInChildren<TMP_Text>(); // 자식 오브젝트에서 text 컴포넌트 찾기
                if (childText != null)
                {
                    childText.text = ItemData[(i * 3) + j].itemName; // itemName 변경
                }
            }
        }
    }
}
