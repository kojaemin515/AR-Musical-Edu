using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCanvasManager : MonoBehaviour
{
    // �뷡�� ������ Ȱ��ȭ�� UIĵ����
    public GameObject GameEndUI;
    // �ƹ�ư ��������

    // Start is called before the first frame update
    void Awake()
    {
        if (GameEndUI != null)
        {
            GameEndUI.SetActive(false);
        }
    }

    public void SetUIOn()
    {
        if(this.GameEndUI != null)
        {
            this.GameEndUI.SetActive(true);
        }
        
    }
}
