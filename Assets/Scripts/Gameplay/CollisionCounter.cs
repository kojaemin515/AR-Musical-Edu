using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    private int collisionCount = 0;


    // 카운트 횟수를 표시할 오브젝트에 참조접근.
    public CollisionCountDisplay collisionCountDisplay;

    private void OnCollisionEnter(Collision collision)
    {
        collisionCount++;
        Debug.Log("현재 충돌 횟수 : " + collisionCount);

        // 표시 오브젝트에 충돌 횟수 전달
        if (collisionCountDisplay != null)
        {
            collisionCountDisplay.UpdateCollisionCount(collisionCount);
        }
        else
        {
            Debug.Log("표시 오브젝트를 찾을 수 없음.");
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
