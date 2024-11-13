using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на текст UI
    public float countdownTime = 60f; // Начальное значение таймера в секундах
    private float timeRemaining; // Оставшееся время
    private bool timerRunning = false; // Флаг для состояния таймера

    void Start()
    {
        timeRemaining = countdownTime; // Устанавливаем оставшееся время
        timerRunning = true; // Запускаем таймер
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Уменьшаем оставшееся время
            }
            else
            {
                timeRemaining = 0; // Устанавливаем в 0, когда таймер истекает
                timerRunning = false; // Останавливаем таймер
                // Здесь можно добавить действия, которые выполняются, когда таймер истекает
            }

            // Обновляем текст таймера в формате 00:00
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}