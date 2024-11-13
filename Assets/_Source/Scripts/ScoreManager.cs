using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на текст UI
    private int score; // Текущий счёт

    void Start()
    {
        score = 0; // Инициализируем счёт
        UpdateScoreText(); // Обновляем отображение счёта
    }

    public void AddScore(int points)
    {
        score += points; // Добавляем очки
        UpdateScoreText(); // Обновляем отображение счёта
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Обновляем текст на UI
    }
}