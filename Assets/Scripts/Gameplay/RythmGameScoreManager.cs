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
        // UI�� ���� ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = "����\n" + score.ToString();
        }
        if (finalScoreText != null)
        {
            finalScoreText.text = "���� : " + score.ToString() + "��";
        }
    }
}
