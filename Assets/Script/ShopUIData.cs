using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Buff, // ������ ����: ����
    Skin, // ������ ����: ��Ų
}
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ShopUIData : ScriptableObject
{
    // ������ ������ �ʵ�
    public ItemType itemType; // �������� Ÿ�� (����, ��Ų ��)
    public Sprite itemImage; // �������� �̹���
    public string itemName; // �������� �̸�
}
