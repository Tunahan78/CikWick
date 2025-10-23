using UnityEngine;
using DG.Tweening;

public class SettingsPopupUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsBacround;
    [SerializeField] private float openDuration = 0.3f;
    [SerializeField] private float closeDuration = 0.2f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = settingsBacround.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = settingsBacround.AddComponent<CanvasGroup>();

        // Başlangıçta gizle
        settingsBacround.SetActive(false);
    }

    private void OnEnable()
    {
        // ✅ Sadece state değiştiğinde tetiklenir
        GameManager.OnChangeState += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnChangeState -= OnGameStateChanged;
    }

    // ✅ Sadece bir kez çağrılır (state değiştiğinde)
    private void OnGameStateChanged(GameState newState)
    {
        if (newState == GameState.Pause)
        {
            OpenBackdrop();
        }
        else if (newState == GameState.Play)
        {
            CloseBackdrop();
        }
    }

    private void OpenBackdrop()
    {
        settingsBacround.SetActive(true);

        // Mevcut animasyonları durdur (güvenlik önlemi)
        canvasGroup.DOKill();
        settingsBacround.transform.DOKill();

        // Başlangıç değerlerini sıfırla
        canvasGroup.alpha = 0f;
        settingsBacround.transform.localScale = Vector3.zero;

        // Animasyon başlat
        canvasGroup.DOFade(1f, openDuration).SetEase(Ease.OutQuad);
        settingsBacround.transform.DOScale(1f, openDuration).SetEase(Ease.OutBack);
    }

    private void CloseBackdrop()
    {
        // Mevcut animasyonları durdur
        canvasGroup.DOKill();
        settingsBacround.transform.DOKill();

        // Animasyonla kapat
        canvasGroup.DOFade(0f, closeDuration).SetEase(Ease.InQuad);
        settingsBacround.transform.DOScale(0.8f, closeDuration).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                settingsBacround.SetActive(false);
            });
    }
}