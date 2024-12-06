using UnityEngine;
using UnityEngine.UI;

public class FreePlayUIController : MonoBehaviour
{
    // 캔버스 목록

    public GameObject CanvasUIBackground; // 항상 표시되는 캔버스
    public GameObject CanvasBeforeStart; // 맨 처음 표시되는 캔버스
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
        // 전체 UI 활성화
        CanvasUIBackground.SetActive(true);
        // 나머지 Canvas를 초기 상태에 따라 설정합니다.
        CanvasBeforeStart.SetActive(true);
        CanvasGamePlayMenu.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSettingMenu.SetActive(false);
        // 현재 메뉴 세부 표시 X
        isGamePlayMenuOn = false;
        isConfirmExitMenuOn = false;
        isConfirmGoTitleMenuOn = false;
        isSettingMenuOn = false;
    }

    // GameStartButton 누글 시 사용할 함수. 단순 UI 끔.
    public void GameStartButtonKiller()
    {
        CanvasBeforeStart.SetActive(false);
    }

    // 메뉴토글버튼에 사용할 토글함수.
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

    // 종료 확인 토글버튼에 사용할 토글함수 // X버튼에 사용가능? 가능
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

    // 타이틀 확인 토글버튼에 사용할 토글함수 // X버튼에 사용가능? 가능
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

    // 설정 버튼에 사용할 토글함수
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