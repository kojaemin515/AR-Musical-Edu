using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class initUIcontroller : MonoBehaviour
{
    // ĵ���� ���
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
            // Canvas�� �ʱ� ���¿� ���� �����մϴ�.
            InitCanvas.SetActive(true);
            SelectInstCanvas.SetActive(false);
            //CanvasSetting.SetActive(false);
            //CanvasConfirmExit.SetActive(false);
            //CanvasSelectInstrument.SetActive(false);
            //CanvasPlaying.SetActive(false);

            //// �׵θ� (��ü UI) -> ��� ĵ������ ��Ȱ��ȭ �� ��Ȱ��ȭ.
            //CanvasPanel.SetActive(true);

            // �ʱ� ĵ���� = ����
            currentCanvas = (int)Canvases.InitCanvas;
        }
    }

    // ��ư Ŭ�� �̺�Ʈ ó�� �Լ�
    public void ActivateCanvas(int canvasToToggle)
    {
        // ��� Canvas�� ��Ȱ��ȭ
        InitCanvas.SetActive(false);
        SelectInstCanvas.SetActive(false);

        // ������ Canvas�� Ȱ��ȭ & ���� ĵ���� ����
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
        // ��� Canvas�� ��Ȱ��ȭ
        InitCanvas.SetActive(false);
        SelectInstCanvas.SetActive(false);
        //CanvasSetting.SetActive(false);
        //CanvasConfirmExit.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasPlaying.SetActive(false);

        //CanvasPanel.SetActive(false);

        // ���� UI�� Playing���� ����
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
        // ��� Canvas�� ��Ȱ��ȭ
        InitCanvas.SetActive(false);
        SelectInstCanvas.SetActive(false);
        //CanvasSetting.SetActive(false);
        //CanvasConfirmExit.SetActive(false);
        //CanvasSelectInstrument.SetActive(false);
        //CanvasPlaying.SetActive(false);

        //CanvasPanel.SetActive(false);
    }
}
