using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Buff, // 아이템 종류: 버프
    Skin, // 아이템 종류: 스킨
}
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ShopUIData : ScriptableObject
{
    // 아이템 데이터 필드
    public ItemType itemType; // 아이템의 타입 (버프, 스킨 등)
    public Sprite itemImage; // 아이템의 이미지
    public string itemName; // 아이템의 이름
}
