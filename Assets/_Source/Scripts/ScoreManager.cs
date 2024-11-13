using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ �� ����� UI
    private int score; // ������� ����

    void Start()
    {
        score = 0; // �������������� ����
        UpdateScoreText(); // ��������� ����������� �����
    }

    public void AddScore(int points)
    {
        score += points; // ��������� ����
        UpdateScoreText(); // ��������� ����������� �����
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // ��������� ����� �� UI
    }
}