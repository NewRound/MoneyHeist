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
                selectedItem[num] = this;
                checkImage.SetActive(true);
        }
        else
        {   // �̹� ���õ� �������� �ٽ� Ŭ���� ��� ���� ����
            checkImage.SetActive(false);
            DataManager.DMinstance.setBaseImage();
            selectedItem[num] = null;
        }
    }
}
