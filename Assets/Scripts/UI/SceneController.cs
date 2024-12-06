using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public string TutorialScene;
    public string RythmGameScene;
    public string FreePlayScene;

    public static bool isChangeInstInFreePlay = false;

    //// ������Ʈ ��������
    //public initUIcontroller initUIcontroller;
    // public GamePlayManager gamePlayManager;

    // ���� �ε��ϴ� �Լ�
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void ChangeScene()
    {
        switch(GamePlayManager.GetGamemode())
        {
            case 0: LoadScene(TutorialScene); break;
            case 1: LoadScene(RythmGameScene); break;
            case 2: LoadScene(FreePlayScene); break;
            default: Debug.Log("�ε��� ���� �����ϴ�."); break;
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