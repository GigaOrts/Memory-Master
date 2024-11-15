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
            firstCard.FlipCard(); // ����������� ������ �����
        }
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            secondCard.FlipCard(); // ����������� ������ �����

            // ��������� ����������
            CheckForMatch();
        }
    }

    private void CheckForMatch()
    {
        if (firstCard.Id == secondCard.Id)
        {
            // ���� ���������, ���������� �����
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else
        {
            // ���� �� ���������, ������� ����� ������� ����� ��������� �����
            firstCard.ResetCard();
            secondCard.ResetCard();
        }

        // �������� ��������� �����
        firstCard = null;
        secondCard = null;
    }
}