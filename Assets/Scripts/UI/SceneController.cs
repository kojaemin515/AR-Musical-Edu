using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public string TutorialScene;
    public string RythmGameScene;
    public string FreePlayScene;

    public static bool isChangeInstInFreePlay = false;

    //// 오브젝트 참조변수
    //public initUIcontroller initUIcontroller;
    // public GamePlayManager gamePlayManager;

    // 씬을 로드하는 함수
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 버튼 클릭 시 호출될 함수
    public void ChangeScene()
    {
        switch(GamePlayManager.GetGamemode())
        {
            case 0: LoadScene(TutorialScene); break;
            case 1: LoadScene(RythmGameScene); break;
            case 2: LoadScene(FreePlayScene); break;
            default: Debug.Log("로드할 씬이 없습니다."); break;
        }
    }

    public void ChangeToInitScene()
    {
        LoadScene("InitScene");
    }

    public void ChangeToInstSelectUI()
    {
        isChangeInstInFreePlay = true;
        ChangeToInitScene();
    }
}