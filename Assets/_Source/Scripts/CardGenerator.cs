using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public Card cardPrefab; // Префаб карточки
    public GameObject cardSlotPrefab; // Префаб слота
    public RectTransform board;
    public int rows = 4;          // Количество строк
    public int cols = 10;         // Количество столбцов
    public float cardSpacing = 10f; // Расстояние между карточками
    public float startXSpacing = 200f; // Расстояние между карточками
    public float startYSpacing = 200f; // Расстояние между карточками

    private GameObject[,] cardSlots; // Двумерный массив для хранения пустышек
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

        // Инициализация массива пустышек
        cardSlots = new GameObject[rows, cols];

        float canvasWidth = board.rect.width;
        float canvasHeight = board.rect.height;

        // Начальные позиции
        float startX = -canvasWidth / 2 + (cardSpacing / 2) + startXSpacing;
        float startY = canvasHeight / 2 - (cardSpacing / 2) - startYSpacing;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Создаем пустышку
                GameObject cardSlot = Instantiate(cardSlotPrefab);
                RectTransform rectTransform = cardSlot.GetComponent<RectTransform>();
                rectTransform.SetParent(board, false);

                // Устанавливаем позицию пустышки
                rectTransform.anchoredPosition = new Vector2(startX + j * (rectTransform.rect.width + cardSpacing), startY - i * (rectTransform.rect.height + cardSpacing));

                // Сохраняем пустышку в массив
                cardSlots[i, j] = cardSlot;
            }
        }
    }

    public void GenerateCards()
    {
        // Удаляем старые карточки
        ClearCards();
        GenerateNumbers();
        ShuffleNumbers();

        // Спавним карточки на пустышках
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Создаем карточку
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
            // Генерируем случайный индекс
            int j = UnityEngine.Random.Range(0, i + 1);
            // Меняем элементы местами
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
        // Удаляем все карточки
        foreach (Transform child in board)
        {
            if (child.name.EndsWith("CardSlot(")) // Предполагается, что карточки имеют имя, начинающееся с "CardPrefab"
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void ClearCards()
    {
        // Удаляем все карточки
        foreach (Transform child in board)
        {
            foreach (Transform item in child)
            {
                if (item.name.StartsWith("Card(")) // Предполагается, что карточки имеют имя, начинающееся с "CardPrefab"
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
