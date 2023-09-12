using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public Image itemImage;
    private bool isItemDark = false;

    public void BuyItemBtn()
    {
        // 아이템 어두운 상태에 따라 이미지 색상을 조절
        if (!isItemDark)
        {
            itemImage.color = Color.gray; // 아이템을 어둡게 표현
            isItemDark = true;
        }
        //else
        //{
        //    itemImage.color = Color.white; // 아이템을 원래 상태로 복원
        //}
    }
}
