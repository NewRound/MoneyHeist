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
        // ������ ��ο� ���¿� ���� �̹��� ������ ����
        if (!isItemDark)
        {
            itemImage.color = Color.gray; // �������� ��Ӱ� ǥ��
            isItemDark = true;
        }
        //else
        //{
        //    itemImage.color = Color.white; // �������� ���� ���·� ����
        //}
    }
}
