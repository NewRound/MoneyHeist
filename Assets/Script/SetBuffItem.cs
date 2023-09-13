using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBuffItem : MonoBehaviour
{
    public ShopUIData[] buffItem;
    // Start is called before the first frame update
    void Start()
    {
        // �����ϰ� BuffItemData �迭���� �ϳ��� �����͸� ����
        int randomIndex = Random.Range(0, buffItem.Length);
        ShopUIData randomData = buffItem[randomIndex];

        // ���õ� �����͸� ����Ͽ� ���� ������Ʈ�� �̸��� �����մϴ�.
        gameObject.name = randomData.itemName;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && randomData.itemImage != null)
        {
            // ���õ� �������� ��������Ʈ�� �����մϴ�.
            spriteRenderer.sprite = randomData.itemImage;
        }
    }
}
