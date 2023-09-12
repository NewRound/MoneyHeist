using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public Image itemImage;
    public GameObject checkImage;
    public bool isItemDark = false;
    public static BuyItem[] selectedItem = new BuyItem[2];

    public ItemType itemType; // 아이템 종류

    public void clickBtn()
    {
        // 현재 아이템이 볼 아이템인 경우
         if (itemType == ItemType.Ball)
        {
            BuyItemBtn(0);
        } 
         // 현재 아이템이 paddle 아이템인 경우
        else if (itemType == ItemType.Paddle)
        {
            BuyItemBtn(1);
        }
    }
    public void BuyItemBtn(int num)
    {
        if (selectedItem[num] != null && selectedItem[num] != this)
        {
            selectedItem[num].checkImage.SetActive(false);
            selectedItem[num] = null;
        }
        // 아이템 어두운 상태에 따라 이미지 색상을 조절
        if (!isItemDark)
        {
            itemImage.color = Color.gray; // 아이템을 어둡게 표현
            isItemDark = true;
            checkImage.SetActive(true);
            selectedItem[num] = this;
        }
        else
        {
            // 이미 어둡게 변한 아이템을 다시 누를 때 checkImage를 활성화
            selectedItem[num] = this;
            checkImage.SetActive(true);
        }
    }
}
