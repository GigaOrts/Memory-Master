using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на текст UI
    private int score; // Текущий счёт
    private int addScore;

    public void Init()
    {
        score = 0; // Инициализируем счёт
        UpdateScoreText(); // Обновляем отображение счёта
    }

    public void AddScore()
    {
        score += addScore; // Добавляем очки
        UpdateScoreText(); // Обновляем отображение счёта
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Обновляем текст на UI
    }

    internal void Init(object cards)
    {
        throw new NotImplementedException();
    }
}