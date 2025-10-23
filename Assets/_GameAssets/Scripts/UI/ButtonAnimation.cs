using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover Settings")]
    public float hoverScale = 1.1f;      // Hover'da büyüme oranı
    public float hoverDuration = 0.15f;  // Animasyon süresi
    public Color hoverColor = Color.white; // Hover rengi

    private RectTransform rectTransform;
    private Color originalColor;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        var image = GetComponent<UnityEngine.UI.Image>();
        if (image != null)
            originalColor = image.color;
    }

    // ✅ Fare butonun üzerine geldiğinde
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Scale animasyonu
        rectTransform.DOScale(hoverScale, hoverDuration).SetEase(Ease.OutQuad);

        // Renk animasyonu (isteğe bağlı)
        var image = GetComponent<UnityEngine.UI.Image>();
        if (image != null)
            image.DOColor(hoverColor, hoverDuration);
    }

    // ✅ Fare butondan ayrıldığında
    public void OnPointerExit(PointerEventData eventData)
    {
        // Scale animasyonu
        rectTransform.DOScale(1f, hoverDuration).SetEase(Ease.InQuad);

        // Renk animasyonu
        var image = GetComponent<UnityEngine.UI.Image>();
        if (image != null)
            image.DOColor(originalColor, hoverDuration);
    }
}

