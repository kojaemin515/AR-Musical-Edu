using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    private int collisionCount = 0;


    // ī��Ʈ Ƚ���� ǥ���� ������Ʈ�� ��������.
    public CollisionCountDisplay collisionCountDisplay;

    private void OnCollisionEnter(Collision collision)
    {
        collisionCount++;
        Debug.Log("���� �浹 Ƚ�� : " + collisionCount);

        // ǥ�� ������Ʈ�� �浹 Ƚ�� ����
        if (collisionCountDisplay != null)
        {
            collisionCountDisplay.UpdateCollisionCount(collisionCount);
        }
        else
        {
            Debug.Log("ǥ�� ������Ʈ�� ã�� �� ����.");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        collisionCountDisplay = FindObjectOfType<CollisionCountDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
