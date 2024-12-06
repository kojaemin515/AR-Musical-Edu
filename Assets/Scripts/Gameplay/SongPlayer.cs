using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Principal;

public class SongPlayer : MonoBehaviour
{
    public AudioSource audioSource; // 재생할 동요 오디오소스
    private float delay = 3.0f; // 시작버튼 누르고 노래재생까지의 딜레이
    private float particleDelay = 0.8f; // 노래와 파티클 싱크맞추기용 딜레이
    public TextMeshProUGUI lyricsText; // 재생할 가사


    private List<LyricsLine> lyricsLines; // 가사 리스트
    private int currentLineIndex = 0; // 인덱스

    public ParticleSpawner particleSpawner; // 파티클 스포너 참조변수

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // 오디오소스초기화


        lyricsLines = new List<LyricsLine>
        {
            new LyricsLine(0.1f, "전주 중.."),
            new LyricsLine(8.0f, "곰 세마리가 한 집에 있어"),
            new LyricsLine(12.0f, "아빠곰 엄마곰 애기곰"),
            new LyricsLine(16.0f, "아빠곰은 뚱뚱해"),
            new LyricsLine(20.0f, "엄마곰은 날씬해"),
            new LyricsLine(24.0f, "애기곰은 너무귀여워"),
            new LyricsLine(28.0f, "히쭉히쭉 잘한다")

            // 필요한 만큼 추가
        };
    }

    public IEnumerator PlaySong()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(DisplayLyrics()); // 노래 재생과 동시에 가사 시작
            
            // particleDelay만큼 기다린 후 파티클 생성 시작
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
            // 현재 보여줄 가사
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
