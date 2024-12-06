using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using JetBrains.Annotations;
//using UnityEngine.SocialPlatforms.GameCenter;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI TITLE;
    public TextMeshProUGUI MainText;

    private string TitleText_SnareDrum = "���׾� �巳 Ʃ�丮��";
    private string TitleText_Timpani = "";
    private string TitleText_Cymbals = "";
    private string TitleText_Rainstick = "";

    private string SnareDrumText0
        = "���� ��ƽ�� �ٸ��� ��� ����� �˷��帱�Կ�.";
    private string SnareDrumText1
        = "�չٴ� ������ �Ʒ��� ���ϵ��� ��ƽ�� ����ϴ�.";
    private string SnareDrumText2
        = "�Ȱ� �տ� ���� ���ϴ�. Ư��, �տ� ���� �־� �����Ű�� �ʴ� ���� �߿��մϴ�.";
    private string SnareDrumText3
        = "���� �ùٸ��� �����ϴ� ����� �˷��帱�Կ�.";
    private string SnareDrumText4
        = "�巳�� ĥ ��, �� ��ü�� �ֵθ��� ���� �ƴ϶�, �ո��� ������ ����Ͽ� �����մϴ�.";
    private string SnareDrumText5
        = "�տ� ���� �ʿ��̻����� �־� �巳�� �ʹ� ���� ġ�� �ʵ��� �����մϴ�.";
    private string SnareDrumText6
        = "�ڿ������� �巳�� ġ��, ��ƽ�� �������� �ݵ��� Ȱ���Ͽ� ��ġ �󱸰��� �帮���ϵ��� �����մϴ�.";
    private string SnareDrumText7
        = "�����մϴ�! ���׾� �巳�� ���� ���ʸ� ������ϴ�!";

    public int SnareTextNum = 0;
    private int TimpaniTextNum = 0;
    private int CymbalTextNum = 0;
    private int RainstickTextNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetInitPanel()
    {
        switch (GamePlayManager.GetGamemode())
        {
            case 0: // ���׾�巳
                MainText.text = SnareDrumText0;
                TITLE.text = TitleText_SnareDrum;
                break;
            case 1: // ���Ĵ�
                break;
            case 2: // �ɹ���
                break;
            case 3: // ���ν�ƽ
                break;
            default:
                break;
        }
    }

    private void ChageMainText(string text)
    {
        if(MainText != null)
        {
            MainText.text = text;
        }
        else
        {
            Debug.Log("MainText�� �����ϴ�.");
        }
    }

    private void ChangeTitle(string text)
    {
        if (TITLE != null)
        {
            TITLE.text = text;
        }
        else
        {
            Debug.Log("TITLE�� �����ϴ�.");
        }
    }

    private void ToNextText_Snare()
    {
        switch (SnareTextNum)
        {
            case 0:
                ChageMainText(SnareDrumText1);
                SnareTextNum++;
                break;
            case 1:
                ChageMainText(SnareDrumText2);
                SnareTextNum++;
                break;
            case 2:
                ChageMainText(SnareDrumText3);
                SnareTextNum++;
                break;
            case 3:
                ChageMainText(SnareDrumText4);
                SnareTextNum++;
                break;
            case 4:
                ChageMainText(SnareDrumText5);
                SnareTextNum++;
                break;
            case 5:
                ChageMainText(SnareDrumText6);
                SnareTextNum++;
                break;
            case 6:
                ChageMainText(SnareDrumText7);
                SnareTextNum++;
                break;
            case 7:
                Debug.Log("���� ������ �����ϴ�.");
                break;
            default:
                break;
        }
    }

    private void ToPrevText_Snare()
    {
        switch (SnareTextNum)
        {
            case 0:
                Debug.Log("���� ������ �����ϴ�.");
                break;
            case 1:
                ChageMainText(SnareDrumText0);
                --SnareTextNum;
                break;
            case 2:
                ChageMainText(SnareDrumText1);
                --SnareTextNum;
                break;
            case 3:
                ChageMainText(SnareDrumText2);
                --SnareTextNum;
                break;
            case 4:
                ChageMainText(SnareDrumText3);
                --SnareTextNum;
                break;
            case 5:
                ChageMainText(SnareDrumText4);
                --SnareTextNum;
                break;
            case 6:
                ChageMainText(SnareDrumText5);
                --SnareTextNum;
                break;
            case 7:
                ChageMainText(SnareDrumText6);
                --SnareTextNum;
                break;
            default:
                break;
        }
    }

    public void ToNextText()
    {
        switch (GamePlayManager.GetGamemode())
        {
            case 0: // ���׾�
                ToNextText_Snare();
                break;
            case 1: // ���Ĵ�
                break;
            case 2: // �ɹ���
                break;
            case 3: // ���ν�ƽ
                break;
            default:
                break;
        }
    }

    public void ToPrevText()
    {
        switch (GamePlayManager.GetGamemode())
        {
            case 0: // ���׾�
                ToPrevText_Snare();
                break;
            case 1: // ���Ĵ�
                break;
            case 2: // �ɹ���
                break;
            case 3: // ���ν�ƽ
                break;
            default:
                break;
        }
    }
}
