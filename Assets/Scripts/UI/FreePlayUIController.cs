using UnityEngine;
using UnityEngine.UI;

public class FreePlayUIController : MonoBehaviour
{
    // ĵ���� ���

    public GameObject CanvasUIBackground; // �׻� ǥ�õǴ� ĵ����
    public GameObject CanvasBeforeStart; // �� ó�� ǥ�õǴ� ĵ����
    public GameObject CanvasGamePlayMenu;
    public GameObject CanvasConfirmExit;
    public GameObject CanvasConfirmGoTitle;
    public GameObject CanvasSettingMenu;

    private bool isGamePlayMenuOn = false;
    private bool isConfirmExitMenuOn = false;
    private bool isConfirmGoTitleMenuOn = false;
    private bool isSettingMenuOn = false;

    //public enum canvases
    //{
    //    CanvasBeforeStart, CanvasGamePlayMenu, CanvasConfirmExit, CanvasConfirmGoTitle, CanvasSettingMenu
    //}

    void Start()
    {
        // ��ü UI Ȱ��ȭ
        CanvasUIBackground.SetActive(true);
        // ������ Canvas�� �ʱ� ���¿� ���� �����մϴ�.
        CanvasBeforeStart.SetActive(true);
        CanvasGamePlayMenu.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSettingMenu.SetActive(false);
        // ���� �޴� ���� ǥ�� X
        isGamePlayMenuOn = false;
        isConfirmExitMenuOn = false;
        isConfirmGoTitleMenuOn = false;
        isSettingMenuOn = false;
    }

    // GameStartButton ���� �� ����� �Լ�. �ܼ� UI ��.
    public void GameStartButtonKiller()
    {
        CanvasBeforeStart.SetActive(false);
    }

    // �޴���۹�ư�� ����� ����Լ�.
    public void ToggleGamePlayMenu()
    {
        if (isGamePlayMenuOn)
        {
            CanvasGamePlayMenu.SetActive(false);
            CanvasConfirmExit.SetActive(false);
            CanvasConfirmGoTitle.SetActive(false);

            isGamePlayMenuOn = false;
        }
        else
        {
            CanvasGamePlayMenu.SetActive(true);

            isGamePlayMenuOn = true;
        }
    }

    // ���� Ȯ�� ��۹�ư�� ����� ����Լ� // X��ư�� ��밡��? ����
    public void ToggleCanvasConfrimExit()
    {
        if(isConfirmExitMenuOn)
        {
            CanvasConfirmExit.SetActive(false);
            isConfirmExitMenuOn = false;
        }
        else
        {
            CanvasConfirmExit.SetActive(true);
            isConfirmExitMenuOn = true;
        }
    }

    // Ÿ��Ʋ Ȯ�� ��۹�ư�� ����� ����Լ� // X��ư�� ��밡��? ����
    public void ToggleCanvasConfirmGoTitle()
    {
        if(isConfirmGoTitleMenuOn)
        {
            CanvasConfirmGoTitle.SetActive(false);
            isConfirmGoTitleMenuOn = false;
        }
        else
        {
            CanvasConfirmGoTitle.SetActive(true);
            isConfirmGoTitleMenuOn = true;
        }
    }

    // ���� ��ư�� ����� ����Լ�
    public void ToggleCanvasSettingMenu()
    {
        if (isSettingMenuOn)
        {
            CanvasSettingMenu.SetActive(false);
            isSettingMenuOn = false;
        }
        else
        {
            CanvasSettingMenu.SetActive(true);
            isSettingMenuOn = true;
        }
    }
}