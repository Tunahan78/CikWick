using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;


public class LeftStateUI : MonoBehaviour
{
    [Header("WalkingUI")]
    [SerializeField] private Image walkingPassiveUI;
    [SerializeField] private Image walkingActiveUI;

    [Header("SlidingUI")]
    [SerializeField] private Image slidingPassiveUI;
    [SerializeField] private Image slidingActiveUI;

    [Header("Animation Settings")]
    [SerializeField] private float animationDuration = 0.25f;
    [SerializeField] Ease easeType = Ease.OutBack;

    private void OnEnable()
    {
        PlayerController.OnPlayerStateChange += OnStateChance;
        ResetToPassive();
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerStateChange -= OnStateChance;
    }

    private void ResetToPassive()
    {
        SetImageActive(walkingPassiveUI, walkingActiveUI);
        SetImageActive(slidingPassiveUI, slidingActiveUI);
    }

    private void OnStateChance(PlayerState state)
    {
        bool isMove = state == PlayerState.Move;
        bool isSliding = state == PlayerState.Slide || state == PlayerState.SlideIdle;

        if (isMove)
        {
            AnimateToActive(walkingActiveUI, walkingPassiveUI);
        }
        else
        {
            AnimateToPassive(walkingPassiveUI, walkingActiveUI);
        }

        if (isSliding)
        {
            AnimateToActive(slidingActiveUI, slidingPassiveUI);
        }

        else
        {
            AnimateToPassive(slidingPassiveUI, slidingActiveUI);
        }
    }

    
     private void AnimateToActive(Image activeImg, Image passiveImg)
    {
        // Pasif görünür, aktif görünmez → aktife geç
        passiveImg.gameObject.SetActive(false);
        activeImg.gameObject.SetActive(true);

        // Animasyon: scale ve fade
        activeImg.rectTransform.localScale = Vector3.zero;
        activeImg.DOFade(1f, animationDuration).SetEase(easeType);
        activeImg.rectTransform.DOScale(1f, animationDuration).SetEase(easeType);
    }

    private void AnimateToPassive(Image passiveImg, Image activeImg)
    {
        // Aktif görünür, pasif görünmez → pasife geç
        activeImg.gameObject.SetActive(false);
        passiveImg.gameObject.SetActive(true);

        // Pasif zaten görünür ama istersen animasyonla "vurgula"
        passiveImg.rectTransform.localScale = Vector3.one;
        passiveImg.DOFade(1f, animationDuration).SetEase(Ease.Linear);
    }

    
    
    private void SetImageActive(Image active, Image passive)
    {
        active.gameObject.SetActive(true);
        passive.gameObject.SetActive(false);
    }
}
