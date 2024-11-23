using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ �� ����� UI
    private int score; // ������� ����
    private int addScore;

    public void Init()
    {
        score = 0; // �������������� ����
        UpdateScoreText(); // ��������� ����������� �����
    }

    public void AddScore()
    {
        score += addScore; // ��������� ����
        UpdateScoreText(); // ��������� ����������� �����
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // ��������� ����� �� UI
    }

    internal void Init(object cards)
    {
        throw new NotImplementedException();
    }
}