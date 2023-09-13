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

    private void Start()
    {
        if (itemType == ItemType.Ball)
        {
            if (itemImage.sprite == DataManager.DMinstance.selectedballImage)
            {
                checkImage.SetActive(true);
            }
        }
        else if (itemType == ItemType.Paddle)
        {
            if (itemImage.sprite == DataManager.DMinstance.selectedPaddleImage)
            {
                checkImage.SetActive(true);
            }
        }
    }
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
                selectedItem[num] = this;
                checkImage.SetActive(true);
        }
        else
        {   // 이미 선택된 아이템을 다시 클릭한 경우 선택 해제
            checkImage.SetActive(false);
            DataManager.DMinstance.setBaseImage();
            selectedItem[num] = null;
        }
    }
}
