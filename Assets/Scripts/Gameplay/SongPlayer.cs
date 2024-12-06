using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Principal;

public class SongPlayer : MonoBehaviour
{
    public AudioSource audioSource; // ����� ���� ������ҽ�
    private float delay = 3.0f; // ���۹�ư ������ �뷡��������� ������
    private float particleDelay = 0.8f; // �뷡�� ��ƼŬ ��ũ���߱�� ������
    public TextMeshProUGUI lyricsText; // ����� ����


    private List<LyricsLine> lyricsLines; // ���� ����Ʈ
    private int currentLineIndex = 0; // �ε���

    public ParticleSpawner particleSpawner; // ��ƼŬ ������ ��������

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // ������ҽ��ʱ�ȭ


        lyricsLines = new List<LyricsLine>
        {
            new LyricsLine(0.1f, "���� ��.."),
            new LyricsLine(8.0f, "�� �������� �� ���� �־�"),
            new LyricsLine(12.0f, "�ƺ��� ������ �ֱ��"),
            new LyricsLine(16.0f, "�ƺ����� �׶���"),
            new LyricsLine(20.0f, "�������� ������"),
            new LyricsLine(24.0f, "�ֱ���� �ʹ��Ϳ���"),
            new LyricsLine(28.0f, "�������� ���Ѵ�")

            // �ʿ��� ��ŭ �߰�
        };
    }

    public IEnumerator PlaySong()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(DisplayLyrics()); // �뷡 ����� ���ÿ� ���� ����
            
            // particleDelay��ŭ ��ٸ� �� ��ƼŬ ���� ����
            yield return new WaitForSeconds(particleDelay);
            particleSpawner.SetInitParticles();
        }
    }

    public void PlaySongWithDelay()
    {
        StartCoroutine(PlaySongAfterDelay());
    }

    private IEnumerator PlaySongAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(PlaySong());
    }

    IEnumerator DisplayLyrics()
    {
        while (currentLineIndex < lyricsLines.Count)
        {
            // ���� ������ ����
            LyricsLine line = lyricsLines[currentLineIndex];
            yield return new WaitForSeconds(line.time - audioSource.time);
            lyricsText.text = line.text;
            ++currentLineIndex;
        }
    }

    private class LyricsLine
    {
        public float time;
        public string text;

        public LyricsLine(float time, string text)
        {
            this.time = time;
            this.text = text;
        }
    }
}
