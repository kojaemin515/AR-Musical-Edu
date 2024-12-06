using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    enum InstrumentsList
    {
        Drum, Timpani, Cymbals, Rainstick
    }

    enum GamemodeList
    {
        Tutorial, RythmGame, FreePlay
    }

    private static int selectedInstruments = 0;
    private static int selectedGamemode = 0;

    public void SetInstrument(int Instrument)
    {
        switch (Instrument)
        {
            case 0: selectedInstruments = (int)InstrumentsList.Drum; break;
            case 1: selectedInstruments = (int)InstrumentsList.Timpani; break;
            case 2: selectedInstruments = (int)InstrumentsList.Cymbals; break;
            case 3: selectedInstruments = (int)InstrumentsList.Rainstick; break;
            default: Debug.Log("잘못된 악기 입력"); break;
        }
    }

    public static int GetInstrument()
    {
        return selectedInstruments;
    }

    public void SetGamemode(int Gamemode)
    {
        switch(Gamemode)
        {
            case 0: selectedGamemode = (int)GamemodeList.Tutorial; break;
            case 1: selectedGamemode = (int)GamemodeList.RythmGame; break;
            case 2: selectedGamemode = (int)GamemodeList.FreePlay; break;
            default: Debug.Log("잘못된 게임모드 입력"); break;
        }
    }

    public static int GetGamemode()
    {
        return selectedGamemode;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameShutdown()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
