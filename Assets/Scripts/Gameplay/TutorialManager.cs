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

    private string TitleText_SnareDrum = "스네어 드럼 튜토리얼";
    private string TitleText_Timpani = "";
    private string TitleText_Cymbals = "";
    private string TitleText_Rainstick = "";

    private string SnareDrumText0
        = "먼저 스틱을 바르게 잡는 방법을 알려드릴게요.";
    private string SnareDrumText1
        = "손바닥 방향이 아래로 향하도록 스틱을 잡습니다.";
    private string SnareDrumText2
        = "팔과 손에 힘을 뺍니다. 특히, 손에 힘을 주어 긴장시키지 않는 것이 중요합니다.";
    private string SnareDrumText3
        = "이제 올바르게 연주하는 방법을 알려드릴게요.";
    private string SnareDrumText4
        = "드럼을 칠 때, 팔 전체를 휘두르는 것이 아니라, 손목의 스냅을 사용하여 연주합니다.";
    private string SnareDrumText5
        = "손에 힘을 필요이상으로 주어 드럼을 너무 세게 치지 않도록 주의합니다.";
    private string SnareDrumText6
        = "자연스럽게 드럼을 치며, 스틱에 느껴지는 반동을 활용하여 마치 농구공을 드리블하듯이 연주합니다.";
    private string SnareDrumText7
        = "축하합니다! 스네어 드럼에 대한 기초를 배웠습니다!";

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
            case 0: // 스네어드럼
                MainText.text = SnareDrumText0;
                TITLE.text = TitleText_SnareDrum;
                break;
            case 1: // 팀파니
                break;
            case 2: // 심벌즈
                break;
            case 3: // 레인스틱
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
            Debug.Log("MainText가 없습니다.");
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
            Debug.Log("TITLE이 없습니다.");
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
                Debug.Log("다음 내용이 없습니다.");
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
                Debug.Log("이전 내용이 없습니다.");
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
            case 0: // 스네어
                ToNextText_Snare();
                break;
            case 1: // 팀파니
                break;
            case 2: // 심벌즈
                break;
            case 3: // 레인스틱
                break;
            default:
                break;
        }
    }

    public void ToPrevText()
    {
        switch (GamePlayManager.GetGamemode())
        {
            case 0: // 스네어
                ToPrevText_Snare();
                break;
            case 1: // 팀파니
                break;
            case 2: // 심벌즈
                break;
            case 3: // 레인스틱
                break;
            default:
                break;
        }
    }
}
