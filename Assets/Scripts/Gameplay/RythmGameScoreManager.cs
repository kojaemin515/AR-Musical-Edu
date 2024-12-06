using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RythmGameScoreManager : MonoBehaviour
{
    private uint score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
        
    void Awake()
    {
        score = 0;
        UpdateScoreUI();
    }

    public uint GetScore()
    {
        return score;
    }
    public void AddScore(bool isperfect)
    {
        if (isperfect)
        {
            score += 100;
        }
        else
        {
            score += 50;
        }
        UpdateScoreUI();
    }
    public void ClearScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // UI에 점수 업데이트
        if (scoreText != null)
        {
            scoreText.text = "점수\n" + score.ToString();
        }
        if (finalScoreText != null)
        {
            finalScoreText.text = "점수 : " + score.ToString() + "점";
        }
    }
}
