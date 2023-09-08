using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ShopUIData : ScriptableObject
{
    // 아이템 데이터 필드
    public Sprite itemImage;
    public string itemName;
}
