using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    // �� �Լ��� �ִϸ��̼� �̺�Ʈ���� ȣ��˴ϴ�.
    public void DeactivateGameObject()
    {
        // �� �Լ��� GameObject�� ��Ȱ��ȭ�մϴ�.
        gameObject.SetActive(false);
    }
}
