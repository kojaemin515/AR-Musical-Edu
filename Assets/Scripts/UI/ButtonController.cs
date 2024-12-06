using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // 캔버스 목록
    public GameObject CanvasBeforeStart; // 0
    public GameObject CanvasPlaying; // 1
    public GameObject CanvasConfirmExit; // 2
    public GameObject CanvasConfirmGoTitle; // 3
    public GameObject CanvasSetting; // 4
    //public GameObject CanvasSelectInstrument;
    //public GameObject CanvasSelectGamemode;

    public GameObject CanvasUIBackground;

    // private bool isPlayingContents = false;

    public enum canvases{
        CanvasBeforeStart, CanvasPlaying, CanvasConfirmExit, CanvasConfirmGoTitle, CanvasSetting
            //, CanvasSelectInstrument, CanvasPlaying
    }

    public int currentCanvas = 0;

    void Start()
    {
        // Canvas를 초기 상태에 따라 설정합니다.
        CanvasBeforeStart.SetActive(true);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);
        
        // 테두리 (전체 UI) -> 모든 캔버스가 비활성화 시 비활성화.
        CanvasUIBackground.SetActive(true);

        // 초기 캔버스 = BeforeStart
        currentCanvas = (int)canvases.CanvasBeforeStart;
    }

    // 버튼 클릭 이벤트 처리 함수
    public void ActivateCanvas(GameObject canvasToToggle)
    {
        // 모든 Canvas를 비활성화
        CanvasBeforeStart.SetActive(false);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);
        
        // 선택한 Canvas를 활성화.
        canvasToToggle.SetActive(true);
        // 현재 Canvas update.
        if (canvasToToggle == CanvasBeforeStart) { currentCanvas = (int)canvases.CanvasBeforeStart; }
        else if (canvasToToggle == CanvasPlaying) { currentCanvas = (int)canvases.CanvasPlaying; }
        else if (canvasToToggle == CanvasConfirmExit) { currentCanvas = (int)canvases.CanvasConfirmExit; }
        else if (canvasToToggle == CanvasConfirmGoTitle) { currentCanvas = (int)canvases.CanvasConfirmGoTitle; }
        else if (canvasToToggle == CanvasSetting) { currentCanvas = (int)canvases.CanvasSetting; }

        //else if (canvasToToggle == CanvasSelectInstrument) { currentCanvas = (int)canvases.CanvasSelectInstrument; }
        //else if (canvasToToggle == CanvasSelectGamemode) { currentCanvas = (int)canvases.CanvasSelectGamemode; }
        
        
    }

    public void DeactivateCanvases()
    {
        // 모든 Canvas를 비활성화
        CanvasBeforeStart.SetActive(false);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);

        CanvasUIBackground.SetActive(false);

        // 현재 UI를 Playing으로 변경
        currentCanvas = (int)(canvases.CanvasPlaying);
    }

    public void ReactivateCurrentCanvas()
    {
        CanvasUIBackground.SetActive(true);

        switch (currentCanvas)
        {
            case 0: CanvasBeforeStart.SetActive(true); break;
            case 1: CanvasPlaying.SetActive(true); break;
            case 2: CanvasConfirmExit.SetActive(true); break;
            case 3: CanvasConfirmGoTitle.SetActive(true); break;
            case 4: CanvasSetting.SetActive(true); break;
            
            //case 4: CanvasSelectInstrument.SetActive(true); break;
            //case 5: CanvasSelectGamemode.SetActive(true); break;
        }
    }

    public void OffCanvases()
    {
        // 모든 Canvas를 비활성화
        CanvasBeforeStart.SetActive(false);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);

        CanvasUIBackground.SetActive(false);
    }
}
