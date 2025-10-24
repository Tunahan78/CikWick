using UnityEngine;
using DG.Tweening;

public class WinLosePopupUI : MonoBehaviour
{
    public static WinLosePopupUI Instance { get; private set; }
    [SerializeField] private GameObject winPopup;
    [SerializeField] private GameObject losePopup;
    [SerializeField] private GameObject winLoseBacround;

    [Header("Animation Settings")]
    [SerializeField] private float openDuration = 0.4f;
    [SerializeField] private float closeDuration = 0.3f;

    private CanvasGroup backgroundCanvasGroup;
    private CanvasGroup winCanvasGroup;
    private CanvasGroup loseCanvasGroup;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        backgroundCanvasGroup = EnsureCanvasGroup(winLoseBacround);
        winCanvasGroup = EnsureCanvasGroup(winPopup);
        loseCanvasGroup = EnsureCanvasGroup(losePopup);

        // Başlangıçta gizle
        winPopup.SetActive(false);
        losePopup.SetActive(false);
        winLoseBacround.SetActive(false);
    }

    private CanvasGroup EnsureCanvasGroup(GameObject obj)
    {
        var cg = obj.GetComponent<CanvasGroup>();
        if (cg == null) cg = obj.AddComponent<CanvasGroup>();
        return cg;
    }

    private void OnEnable()
    {
        GameManager.OnCollectedMaxEgg += CallWinPopup;
        HealtManager.OnPlayerDead += CallLosePopup;
    }

    private void OnDisable()
    {
        GameManager.OnCollectedMaxEgg -= CallWinPopup;
        HealtManager.OnPlayerDead -= CallLosePopup;

        // ❗️ Objeden ayrılınca animasyonları temizle
        KillAllAnimations();
    }

    private void KillAllAnimations()
    {
        if (backgroundCanvasGroup != null) backgroundCanvasGroup.DOKill();
        if (winCanvasGroup != null) winCanvasGroup.DOKill();
        if (loseCanvasGroup != null) loseCanvasGroup.DOKill();
        if (winPopup != null) winPopup.transform.DOKill();
        if (losePopup != null) losePopup.transform.DOKill();
        if (winLoseBacround != null) winLoseBacround.transform.DOKill();
    }

    private void CallWinPopup()
    {
        OpenPopup(winPopup, winCanvasGroup);
    }

    private void CallLosePopup()
    {
        OpenPopup(losePopup, loseCanvasGroup);
    }

    private void OpenPopup(GameObject popup, CanvasGroup cg)
    {
        // ❗️ Eski animasyonları temizle
        KillAllAnimations();

        // Arka planı göster
        winLoseBacround.SetActive(true);
        backgroundCanvasGroup.alpha = 0f;
        backgroundCanvasGroup.DOFade(0.7f, openDuration).SetEase(Ease.OutQuad);

        // Popup'ı göster
        popup.SetActive(true);
        cg.alpha = 0f;
        popup.transform.localScale = Vector3.zero;

        cg.DOFade(1f, openDuration).SetEase(Ease.OutQuad);
        popup.transform.DOScale(1.5f, openDuration).SetEase(Ease.OutBack);
    }

    public void HidePopup()
    {
        // ❗️ Animasyonları temizle
        KillAllAnimations();

        // Popup'ları gizle
        winPopup.SetActive(false);
        losePopup.SetActive(false);

        // Arka planı kapat
        if (winLoseBacround.activeInHierarchy)
        {
            backgroundCanvasGroup.DOFade(0f, closeDuration).SetEase(Ease.InQuad)
                .OnComplete(() =>
                {
                    winLoseBacround.SetActive(false);
                });
        }
        else
        {
            winLoseBacround.SetActive(false);
        }
    }
}
