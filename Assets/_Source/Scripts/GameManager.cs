using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Card firstCard;
    private Card secondCard;
    public CardGenerator cardGenerator;
    public ScoreManager scoreManager;
    public Canvas finishGameUI;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        cardGenerator.Init();
        foreach (Card card in cardGenerator.Cards)
        {
            card.Destroyed += scoreManager.AddScore;
        }

        scoreManager.Init();
    }

    public void OnCardClicked(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            firstCard.FlipCard(); // Перевернуть первую карту
        }
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            secondCard.FlipCard(); // Перевернуть вторую карту

            // Проверить совпадение
            CheckForMatch();
        }
    }

    private void CheckForMatch()
    {
        if (firstCard.Id == secondCard.Id)
        {
            firstCard.Destroyed -= scoreManager.AddScore;
            secondCard.Destroyed -= scoreManager.AddScore;
            // Если совпадают, уничтожить карты
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else
        {
            // Если не совпадают, вернуть карты обратно через некоторое время
            firstCard.ResetCard();
            secondCard.ResetCard();
        }

        // Сбросить выбранные карты
        firstCard = null;
        secondCard = null;

        if(cardGenerator.Cards.Count == 0)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        finishGameUI.gameObject.SetActive(true);
    }
}