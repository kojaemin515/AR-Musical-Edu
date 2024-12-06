using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    private ButtonController buttonController;
    private bool UIOpened = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObjectA = GameObject.Find("UICanvasManager");
        if (gameObjectA == null )
        {
            Debug.Log("UICanvasManager 오브젝트를 찾을 수 없습니다.");
        }
        else
        {
            buttonController = gameObjectA.GetComponent<ButtonController>();
            if (buttonController == null)
            {
                Debug.Log("ButtonController 컴포넌트를 찾을 수 없습니다.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<UITrigger>() != null)
        {
            if (buttonController != null)
            {
                if (UIOpened)
                {
                    buttonController.OffCanvases();
                    Debug.Log("UI : OFF");
                    UIOpened = false;
                }
                else
                {
                    buttonController.ReactivateCurrentCanvas();
                    Debug.Log("UI : ON");
                    UIOpened = true;
                }
            }
            else
            {
                Debug.LogWarning("ButtonController를 찾을 수 없습니다.");
            }
        }
    }
}
