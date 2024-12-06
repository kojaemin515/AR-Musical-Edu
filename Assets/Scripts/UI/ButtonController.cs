using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // ĵ���� ���
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
        // Canvas�� �ʱ� ���¿� ���� �����մϴ�.
        CanvasBeforeStart.SetActive(true);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);
        
        // �׵θ� (��ü UI) -> ��� ĵ������ ��Ȱ��ȭ �� ��Ȱ��ȭ.
        CanvasUIBackground.SetActive(true);

        // �ʱ� ĵ���� = BeforeStart
        currentCanvas = (int)canvases.CanvasBeforeStart;
    }

    // ��ư Ŭ�� �̺�Ʈ ó�� �Լ�
    public void ActivateCanvas(GameObject canvasToToggle)
    {
        // ��� Canvas�� ��Ȱ��ȭ
        CanvasBeforeStart.SetActive(false);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);
        
        // ������ Canvas�� Ȱ��ȭ.
        canvasToToggle.SetActive(true);
        // ���� Canvas update.
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
        // ��� Canvas�� ��Ȱ��ȭ
        CanvasBeforeStart.SetActive(false);
        CanvasPlaying.SetActive(false);
        CanvasConfirmExit.SetActive(false);
        CanvasConfirmGoTitle.SetActive(false);
        CanvasSetting.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasSelectGamemode.SetActive(false);

        CanvasUIBackground.SetActive(false);

        // ���� UI�� Playing���� ����
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
        // ��� Canvas�� ��Ȱ��ȭ
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
