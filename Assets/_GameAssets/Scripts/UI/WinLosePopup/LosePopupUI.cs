using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LosePopupUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;

    private void OnEnable()
    {
        // Geçen süreyi göster
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        // TimeUI'dan geçen süreyi al
        float elapsedTime = 10f; // Gerçek zamanı buradan alabilirsin
        int minute = Mathf.FloorToInt(elapsedTime / 60);
        int second = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    public void OnTryAgainButton()
    {
        // Oyunu yeniden başlat
        GameManager.Instance.SetChangeState(GameState.Play);
        WinLosePopupUI.Instance.HidePopup();
        SceneManager.LoadScene("SampleScene"); // Gerçek oyun için
    }

    public void OnMainMenuButton()
    {
        // Ana menüye dön
        GameManager.Instance.SetChangeState(GameState.GameOver);
        WinLosePopupUI.Instance.HidePopup();
        // SceneManager.LoadScene("MainMenu");
    }
    
}
