using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTSManager : MonoBehaviour
{
    // ���׾� �巳 Ʃ�丮���� �����ϴ� TTS�����Ŭ�� ����Ʈ
    public List<AudioClip> clipList_snare = new List<AudioClip>();
    // ���׾� �巳 �����Ŭ���� ����� ������ҽ�
    private AudioSource audioSource;
    // ����� �����Ŭ���� ����Ű�� ����
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
        // ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
        {
            // AudioSource ������Ʈ�� ���ٸ� �߰��ؼ� ��������
            audioSource= gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayInitTTS_snare()
    {
        // �ε��� ������ ������ ���ٸ�
        if (snareIndex >= 0 && snareIndex < clipList_snare.Count)
        {
            audioSource.clip = clipList_snare[snareIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("�����Ŭ�� ����Ʈ - �ε��� ���� ����");
        }
    }
    public void PlayNextTTS_snare()
    {
        // �ε��� ������ ������ ���ٸ�
        if (snareIndex >= 0 && snareIndex < clipList_snare.Count)
        {
            if(snareIndex < clipList_snare.Count - 1)
            {
                PlusSnareIndex();
                audioSource.clip = clipList_snare[snareIndex];
                audioSource.Play();
            }
            // �����Ű� ���� ��� �ƹ��͵� ���� ����
        }
        else
        {
            Debug.LogError("�����Ŭ�� ����Ʈ - �ε��� ���� ����");
        }
    }

    public void PlayPreviousTTS_snare()
    {
        // �ε��� ������ ������ ���ٸ�
        if (snareIndex >= 0 && snareIndex < clipList_snare.Count)
        {
            if (snareIndex > 0)
            {
                MinusSnareIndex();
                audioSource.clip = clipList_snare[snareIndex];
                audioSource.Play();
            }
            // �����Ű� ���� ��� �ƹ��͵� ���� ����.
        }
        else
        {
            Debug.LogError("�����Ŭ�� ����Ʈ - �ε��� ���� ����");
        }
    }
}
