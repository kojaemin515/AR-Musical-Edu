using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTSManager : MonoBehaviour
{
    // 스네어 드럼 튜토리얼을 설명하는 TTS오디오클립 리스트
    public List<AudioClip> clipList_snare = new List<AudioClip>();
    // 스네어 드럼 오디오클립을 재생할 오디오소스
    private AudioSource audioSource;
    // 재생할 오디오클립을 가리키는 색인
    private int snareIndex = 0;
    public void PlusSnareIndex()
    {
        if (snareIndex < 7)
        {
            ++snareIndex;
        }
    }
    public void MinusSnareIndex()
    {
        if (snareIndex > 0)
        {
            --snareIndex;
        }
    }

    private void Awake()
    {
        // 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
        {
            // AudioSource 컴포넌트가 없다면 추가해서 가져오기
            audioSource= gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayInitTTS_snare()
    {
        // 인덱스 범위에 문제가 없다면
        if (snareIndex >= 0 && snareIndex < clipList_snare.Count)
        {
            audioSource.clip = clipList_snare[snareIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("오디오클립 리스트 - 인덱스 범위 오류");
        }
    }
    public void PlayNextTTS_snare()
    {
        // 인덱스 범위에 문제가 없다면
        if (snareIndex >= 0 && snareIndex < clipList_snare.Count)
        {
            if(snareIndex < clipList_snare.Count - 1)
            {
                PlusSnareIndex();
                audioSource.clip = clipList_snare[snareIndex];
                audioSource.Play();
            }
            // 다음거가 없는 경우 아무것도 하지 않음
        }
        else
        {
            Debug.LogError("오디오클립 리스트 - 인덱스 범위 오류");
        }
    }

    public void PlayPreviousTTS_snare()
    {
        // 인덱스 범위에 문제가 없다면
        if (snareIndex >= 0 && snareIndex < clipList_snare.Count)
        {
            if (snareIndex > 0)
            {
                MinusSnareIndex();
                audioSource.clip = clipList_snare[snareIndex];
                audioSource.Play();
            }
            // 이전거가 없는 경우 아무것도 하지 않음.
        }
        else
        {
            Debug.LogError("오디오클립 리스트 - 인덱스 범위 오류");
        }
    }
}
