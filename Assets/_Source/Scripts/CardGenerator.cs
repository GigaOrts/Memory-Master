using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public Card cardPrefab; // ������ ��������
    public GameObject cardSlotPrefab; // ������ �����
    public RectTransform board;
    public int rows = 4;          // ���������� �����
    public int cols = 10;         // ���������� ��������
    public float cardSpacing = 10f; // ���������� ����� ����������
    public float startXSpacing = 200f; // ���������� ����� ����������
    public float startYSpacing = 200f; // ���������� ����� ����������

    private GameObject[,] cardSlots; // ��������� ������ ��� �������� ��������
    private Queue<int> numbers;
    private List<int> numbersArray;

    void Start()
    {
        GenerateEmptySlots();
        GenerateCards();
    }

    public void GenerateEmptySlots()
    {
        ClearSlots();

        // ������������� ������� ��������
        cardSlots = new GameObject[rows, cols];

        float canvasWidth = board.rect.width;
        float canvasHeight = board.rect.height;

        // ��������� �������
        float startX = -canvasWidth / 2 + (cardSpacing / 2) + startXSpacing;
        float startY = canvasHeight / 2 - (cardSpacing / 2) - startYSpacing;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // ������� ��������
                GameObject cardSlot = Instantiate(cardSlotPrefab);
                RectTransform rectTransform = cardSlot.GetComponent<RectTransform>();
                rectTransform.SetParent(board, false);

                // ������������� ������� ��������
                rectTransform.anchoredPosition = new Vector2(startX + j * (rectTransform.rect.width + cardSpacing), startY - i * (rectTransform.rect.height + cardSpacing));

                // ��������� �������� � ������
                cardSlots[i, j] = cardSlot;
            }
        }
    }

    public void GenerateCards()
    {
        // ������� ������ ��������
        ClearCards();
        GenerateNumbers();
        ShuffleNumbers();

        // ������� �������� �� ���������
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // ������� ��������
                Card card = Instantiate(cardPrefab);
                card.Init(numbers.Dequeue());
                RectTransform cardTransform = card.GetComponent<RectTransform>();
                cardTransform.SetParent(cardSlots[i, j].GetComponent<RectTransform>(), false);
            }
        }
    }

    private void ShuffleNumbers()
    {
        numbersArray = new List<int>(numbers);

        int n = numbersArray.Count;

        for (int i = n - 1; i > 0; i--)
        {
            // ���������� ��������� ������
            int j = UnityEngine.Random.Range(0, i + 1);
            // ������ �������� �������
            int temp = numbersArray[i];
            numbersArray[i] = numbersArray[j];
            numbersArray[j] = temp;
        }

        numbers = new Queue<int>(numbersArray);
    }

    private void GenerateNumbers()
    {
        numbers = new Queue<int>();
        for (int i = 0; i < (rows * cols) / 2; i++)
        {
            numbers.Enqueue(i);
            numbers.Enqueue(i);
        }
    }

    private void ClearSlots()
    {
        // ������� ��� ��������
        foreach (Transform child in board)
        {
            if (child.name.EndsWith("CardSlot(")) // ��������������, ��� �������� ����� ���, ������������ � "CardPrefab"
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void ClearCards()
    {
        // ������� ��� ��������
        foreach (Transform child in board)
        {
            foreach (Transform item in child)
            {
                if (item.name.StartsWith("Card(")) // ��������������, ��� �������� ����� ���, ������������ � "CardPrefab"
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
