using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RightBoostersUIManager : MonoBehaviour
{
    [Header("Boosters")]
    public Image speedActive;
    public Image speedPassive;

    public Image jumpActive;
    public Image jumpPassive;

    public Image slowActive;
    public Image slowPassive;

    [Header("Animation Settings")]
    public float animationDuration = 0.4f;
    public Ease easeType = Ease.OutBack;

    // Başlangıç x pozisyonlarını sakla
    private float speedStartX;
    private float jumpStartX;
    private float slowStartX;

    private void OnEnable()
    {
        GoldWheat.OnCollectWheat += OnWheatCollected;
        HolyWheat.OnCollectWheat += OnWheatCollected;
        RottenWheat.OnCollectWheat += OnWheatCollected;

        // Başlangıç x pozisyonlarını kaydet
        speedStartX = speedActive.rectTransform.anchoredPosition.x;
        jumpStartX = jumpActive.rectTransform.anchoredPosition.x;
        slowStartX = slowActive.rectTransform.anchoredPosition.x;
    }

    private void OnDisable()
    {
        GoldWheat.OnCollectWheat -= OnWheatCollected;
        HolyWheat.OnCollectWheat -= OnWheatCollected;
        RottenWheat.OnCollectWheat -= OnWheatCollected;
    }

    private void OnWheatCollected(string wheatType)
    {
        switch (wheatType)
        {
            case "GoldWheat":
                ActivateBooster(speedActive, speedPassive, 5f);
                break;
            case "HolyWheat":
                ActivateBooster(jumpActive, jumpPassive, 5f);
                break;
            case "RottenWheat":
                ActivateBooster(slowActive, slowPassive, 5f);
                break;
        }
    }

    private void ActivateBooster(Image activeImg, Image passiveImg, float duration)
    {
        // Pasif görünür, aktif görünmez → aktife geç
        passiveImg.gameObject.SetActive(false);
        activeImg.gameObject.SetActive(true);

        // Animasyon: x pozisyonunu -25'e getir (y pozisyonu sabit kalır)
        Vector2 targetPos = new Vector2(-50f, activeImg.rectTransform.anchoredPosition.y);
        activeImg.rectTransform.DOAnchorPos(targetPos, animationDuration).SetEase(easeType);

        // DOTween ile delay verip sonra pasife dön
        DOVirtual.DelayedCall(duration, () =>
        {
            DeactivateBooster(activeImg, passiveImg);
        });
    }

    private void DeactivateBooster(Image activeImg, Image passiveImg)
    {
        // Aktif görünür, pasif görünmez → pasife geç
        activeImg.gameObject.SetActive(false);
        passiveImg.gameObject.SetActive(true);

        // Animasyon: x pozisyonunu başlangıç değerine döndür (y pozisyonu sabit kalır)
        float startX = GetStartX(activeImg); // Hangi UI'nin başlangıç x'i?
        Vector2 targetPos = new Vector2(startX, activeImg.rectTransform.anchoredPosition.y);
        activeImg.rectTransform.DOAnchorPos(targetPos, animationDuration).SetEase(Ease.InBack);
    }

    private float GetStartX(Image img)
    {
        if (img == speedActive) return speedStartX;
        if (img == jumpActive) return jumpStartX;
        if (img == slowActive) return slowStartX;
        return 4f; // Varsayılan
    }
}