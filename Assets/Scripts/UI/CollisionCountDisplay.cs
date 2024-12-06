using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionCountDisplay : MonoBehaviour
{
    // �浹Ƚ�� ǥ���ϴ� �ؽ�Ʈ
    public TextMeshPro collisionCountText;

    public void UpdateCollisionCount (int count)
    {
        // UI �ؽ�Ʈ�� ������Ʈ�ϴ� �Լ�
        if (collisionCountText != null)
        {
            collisionCountText.text = "Count : " + count;
        }
        else
        {
            Debug.Log("�浹 Ƚ�� ǥ�� �ؽ�Ʈ�� ã�� �� �����ϴ�.");
        }
    }
}
