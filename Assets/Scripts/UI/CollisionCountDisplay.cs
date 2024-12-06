using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionCountDisplay : MonoBehaviour
{
    // 충돌횟수 표시하는 텍스트
    public TextMeshPro collisionCountText;

    public void UpdateCollisionCount (int count)
    {
        // UI 텍스트를 업데이트하는 함수
        if (collisionCountText != null)
        {
            collisionCountText.text = "Count : " + count;
        }
        else
        {
            Debug.Log("충돌 횟수 표시 텍스트를 찾을 수 없습니다.");
        }
    }
}
