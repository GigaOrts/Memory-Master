using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject cardPrefab; // ������ ��������
    public RectTransform board;
    public int rows = 4;          // ���������� �����
    public int cols = 10;         // ���������� ��������
    public float cardSpacing = 10f; // ���������� ����� ����������
    public float startXSpacing = 200f; // ���������� ����� ����������
    public float startYSpacing = 200f; // ���������� ����� ����������

    void Start()
    {
        GenerateCards();
    }

    public void GenerateCards()
    {
        // ������� ������ ��������
        ClearCards();

        float canvasWidth = board.rect.width;
        float canvasHeight = board.rect.height;

        // ��������� �������
        float startX = -canvasWidth / 2 + (cardSpacing / 2) + startXSpacing;
        float startY = canvasHeight / 2 - (cardSpacing / 2) - startYSpacing;

        Debug.Log($"startX {startX}");
        Debug.Log($"startY {startY}");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // ������� ��������
                GameObject card = Instantiate(cardPrefab);
                RectTransform rectTransform = card.GetComponent<RectTransform>();
                rectTransform.SetParent(board, false);

                // ������������� ������� ��������
                rectTransform.anchoredPosition = new Vector2(startX + j * (rectTransform.rect.width + cardSpacing), startY - i * (rectTransform.rect.height + cardSpacing));
            }
        }
    }

    private void ClearCards()
    {
        // ������� ��� �������� ������� �� board
        foreach (Transform child in board)
        {
            Destroy(child.gameObject);
        }
    }
}
