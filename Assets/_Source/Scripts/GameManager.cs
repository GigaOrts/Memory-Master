using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Card firstCard;
    private Card secondCard;
    private List<Card> cards = new List<Card>();

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
    }
}