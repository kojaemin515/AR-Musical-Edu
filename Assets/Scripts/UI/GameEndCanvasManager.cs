using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCanvasManager : MonoBehaviour
{
    // 노래가 끝나면 활성화할 UI캔버스
    public GameObject GameEndUI;
    // 아무튼 참조변수

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
