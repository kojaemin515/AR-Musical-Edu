using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class initUIcontroller : MonoBehaviour
{
    // 캔버스 목록
    public GameObject InitCanvas; // 0
    public GameObject SelectInstCanvas; // 1
    //public GameObject CanvasSetting; // 2
    //public GameObject CanvasConfirmExit; // 3
    //public GameObject CanvasSelectInstrument; // 4
    //public GameObject CanvasPlaying; // 5

    //public GameObject CanvasPanel;

    // private bool isPlayingContents = false;

    public enum Canvases
    {
        InitCanvas, SelectInstCanvas// , CanvasSetting, CanvasConfirmExit, CanvasSelectInstrument, CanvasPlaying
    }

    public int currentCanvas = 0;

    void Start()
    {
        if (SceneController.isChangeInstInFreePlay)
        {
            ActivateCanvas(1);
            SceneController.isChangeInstInFreePlay = false;
        }
        else
        {
            // Canvas를 초기 상태에 따라 설정합니다.
            InitCanvas.SetActive(true);
            SelectInstCanvas.SetActive(false);
            //CanvasSetting.SetActive(false);
            //CanvasConfirmExit.SetActive(false);
            //CanvasSelectInstrument.SetActive(false);
            //CanvasPlaying.SetActive(false);

            //// 테두리 (전체 UI) -> 모든 캔버스가 비활성화 시 비활성화.
            //CanvasPanel.SetActive(true);

            // 초기 캔버스 = 메인
            currentCanvas = (int)Canvases.InitCanvas;
        }
    }

    // 버튼 클릭 이벤트 처리 함수
    public void ActivateCanvas(int canvasToToggle)
    {
        // 모든 Canvas를 비활성화
        InitCanvas.SetActive(false);
        SelectInstCanvas.SetActive(false);

        // 선택한 Canvas를 활성화 & 현재 캔버스 저장
        switch (canvasToToggle)
        {
            case 0:
                InitCanvas.SetActive(true);
                currentCanvas = (int)Canvases.InitCanvas;
                break;
            case 1:
                SelectInstCanvas.SetActive(true);
                currentCanvas = (int)Canvases.SelectInstCanvas;
                break;
        }
    }

    public void DeactivateCanvases()
    {
        // 모든 Canvas를 비활성화
        InitCanvas.SetActive(false);
        SelectInstCanvas.SetActive(false);
        //CanvasSetting.SetActive(false);
        //CanvasConfirmExit.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasPlaying.SetActive(false);

        //CanvasPanel.SetActive(false);

        // 현재 UI를 Playing으로 변경
        // currentCanvas = (int)(canvases.CanvasPlaying);
    }

    public void ReactivateCurrentCanvas()
    {
        //CanvasPanel.SetActive(true);

        switch (currentCanvas)
        {
            case 0: InitCanvas.SetActive(true); break;
            case 1: SelectInstCanvas.SetActive(true); break;
            //case 2: CanvasSetting.SetActive(true); break;
            //case 3: CanvasConfirmExit.SetActive(true); break;
            //case 4: CanvasSelectInstrument.SetActive(true); break;
            //case 5: CanvasPlaying.SetActive(true); break;
        }
    }

    public void OffCanvases()
    {
        // 모든 Canvas를 비활성화
        InitCanvas.SetActive(false);
        SelectInstCanvas.SetActive(false);
        //CanvasSetting.SetActive(false);
        //CanvasConfirmExit.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasPlaying.SetActive(false);

        //CanvasPanel.SetActive(false);
    }
}
