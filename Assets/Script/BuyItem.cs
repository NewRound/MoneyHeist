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

    public ItemType itemType; // ������ ����

    public void clickBtn()
    {
        // ���� �������� �� �������� ���
         if (itemType == ItemType.Ball)
        {
            BuyItemBtn(0);
        } 
         // ���� �������� paddle �������� ���
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
        // ������ ��ο� ���¿� ���� �̹��� ������ ����
        if (!isItemDark)
        {
            itemImage.color = Color.gray; // �������� ��Ӱ� ǥ��
            isItemDark = true;
            checkImage.SetActive(true);
            selectedItem[num] = this;
        }
        else
        {
            // �̹� ��Ӱ� ���� �������� �ٽ� ���� �� checkImage�� Ȱ��ȭ
            selectedItem[num] = this;
            checkImage.SetActive(true);
        }
    }
}
