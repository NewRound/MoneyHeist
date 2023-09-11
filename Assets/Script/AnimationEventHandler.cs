using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    // 이 함수는 애니메이션 이벤트에서 호출됩니다.
    public void DeactivateGameObject()
    {
        // 이 함수는 GameObject를 비활성화합니다.
        gameObject.SetActive(false);
    }
}
