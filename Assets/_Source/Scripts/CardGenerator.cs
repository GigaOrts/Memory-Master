using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject cardPrefab; // Префаб карточки
    public RectTransform board;
    public int rows = 4;          // Количество строк
    public int cols = 10;         // Количество столбцов
    public float cardSpacing = 10f; // Расстояние между карточками
    public float startXSpacing = 200f; // Расстояние между карточками
    public float startYSpacing = 200f; // Расстояние между карточками

    void Start()
    {
        GenerateCards();
    }

    public void GenerateCards()
    {
        // Удаляем старые карточки
        ClearCards();

        float canvasWidth = board.rect.width;
        float canvasHeight = board.rect.height;

        // Начальные позиции
        float startX = -canvasWidth / 2 + (cardSpacing / 2) + startXSpacing;
        float startY = canvasHeight / 2 - (cardSpacing / 2) - startYSpacing;

        Debug.Log($"startX {startX}");
        Debug.Log($"startY {startY}");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Создаем карточку
                GameObject card = Instantiate(cardPrefab);
                RectTransform rectTransform = card.GetComponent<RectTransform>();
                rectTransform.SetParent(board, false);

                // Устанавливаем позицию карточки
                rectTransform.anchoredPosition = new Vector2(startX + j * (rectTransform.rect.width + cardSpacing), startY - i * (rectTransform.rect.height + cardSpacing));
            }
        }
    }

    private void ClearCards()
    {
        // Удаляем все дочерние объекты из board
        foreach (Transform child in board)
        {
            Destroy(child.gameObject);
        }
    }
}
