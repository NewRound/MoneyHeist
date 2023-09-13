using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBuffItem : MonoBehaviour
{
    public ShopUIData[] buffItem;
    // Start is called before the first frame update
    void Start()
    {
        // 랜덤하게 BuffItemData 배열에서 하나의 데이터를 선택
        int randomIndex = Random.Range(0, buffItem.Length);
        ShopUIData randomData = buffItem[randomIndex];

        // 선택된 데이터를 사용하여 게임 오브젝트의 이름을 설정합니다.
        gameObject.name = randomData.itemName;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && randomData.itemImage != null)
        {
            // 선택된 데이터의 스프라이트를 설정합니다.
            spriteRenderer.sprite = randomData.itemImage;
        }
    }
}
