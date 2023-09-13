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
    public ItemType itemType; // ������ ����

    bool isItemDark = false;
    public void clickBtn()
    {
        // ���� �������� �� �������� ���
         if (itemType == ItemType.Ball)
        {
            selectItem(0);
            if(selectedItem[0] !=null) DataManager.DMinstance.selectedballImage = selectedItem[0].itemImage.sprite;
        } 
         // ���� �������� paddle �������� ���
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
            // ������ ��ο� ���¿� ���� �̹��� ������ ����
            if (!isItemDark)
            {
                buttonImage.color = Color.gray; // �������� ��Ӱ� ǥ��
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
        else
        {   // �̹� ���õ� �������� �ٽ� Ŭ���� ��� ���� ����
            checkImage.SetActive(false);
            DataManager.DMinstance.setBaseImage();
            selectedItem[num] = null;
        }
    }
}
