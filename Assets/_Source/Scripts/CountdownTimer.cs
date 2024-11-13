using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ������ �� ����� UI
    public float countdownTime = 60f; // ��������� �������� ������� � ��������
    private float timeRemaining; // ���������� �����
    private bool timerRunning = false; // ���� ��� ��������� �������

    void Start()
    {
        timeRemaining = countdownTime; // ������������� ���������� �����
        timerRunning = true; // ��������� ������
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // ��������� ���������� �����
            }
            else
            {
                timeRemaining = 0; // ������������� � 0, ����� ������ ��������
                timerRunning = false; // ������������� ������
                // ����� ����� �������� ��������, ������� �����������, ����� ������ ��������
            }

            // ��������� ����� ������� � ������� 00:00
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}