using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public Image buttonImage;
    public Image itemImage;
    public GameObject checkImage;
    public static BuyItem[] selectedItem = new BuyItem[2];
    public ItemType itemType; // 아이템 종류

    bool isItemDark = false;
    public void clickBtn()
    {
        // 현재 아이템이 볼 아이템인 경우
         if (itemType == ItemType.Ball)
        {
            selectItem(0);
            if(selectedItem[0] !=null) DataManager.DMinstance.selectedballImage = selectedItem[0].itemImage.sprite;
        } 
         // 현재 아이템이 paddle 아이템인 경우
        else if (itemType == ItemType.Paddle)
        {
            selectItem(1);
            if (selectedItem[1] != null) DataManager.DMinstance.selectedPaddleImage = selectedItem[1].itemImage.sprite;
        }
    }
    private void selectItem(int num)
    {
        if (selectedItem[num] != null && selectedItem[num] != this)
        {
            selectedItem[num].checkImage.SetActive(false);
            selectedItem[num] = null;
        }
        if (selectedItem[num] != this)
        {
            // 아이템 어두운 상태에 따라 이미지 색상을 조절
            if (!isItemDark)
            {
                buttonImage.color = Color.gray; // 아이템을 어둡게 표현
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
        else
        {   // 이미 선택된 아이템을 다시 클릭한 경우 선택 해제
            checkImage.SetActive(false);
            DataManager.DMinstance.setBaseImage();
            selectedItem[num] = null;
        }
    }
}
