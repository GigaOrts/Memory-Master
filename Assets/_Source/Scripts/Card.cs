using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image image;
    public Color flippedColor;
    public Color defaultColor;
    public Color matchColor;
    public Color dismatchColor;
    public int Id { get; private set; }
    public TextMeshProUGUI textMesh;
    
    bool isFlipped;

    GameManager gameManager;

    private void Awake()
    {
        defaultColor = image.color;
        gameManager = FindObjectOfType<GameManager>(); // Найти GameManager в сцене
    }

    public void Init(int id)
    {
        Id = id;
        textMesh.text = Id.ToString();
        UpdateView();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.OnCardClicked(this); // Уведомить GameManager о клике
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isFlipped)
        {
            image.color = Color.gray;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isFlipped)
        {
            image.color = defaultColor;
        }
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;
        UpdateView();
    }

    private void UpdateView()
    {
        image.color = isFlipped ? Color.yellow : defaultColor; // Меняем цвет в зависимости от состояния
        textMesh.gameObject.SetActive(isFlipped);
    }

    public void DestroyCard()
    {
        StartCoroutine(DestroyCardRoutine());
    }

    public void ResetCard()
    {
        StartCoroutine(ResetCardRoutine());
    }

    private IEnumerator ResetCardRoutine()
    {
        image.color = dismatchColor;
        yield return new WaitForSeconds(1f);
        isFlipped = false;
        UpdateView();
    }

    private IEnumerator DestroyCardRoutine()
    {
        image.color = matchColor;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
