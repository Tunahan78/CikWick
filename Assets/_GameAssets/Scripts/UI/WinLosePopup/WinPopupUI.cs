using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WinPopupUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;


    private void OnEnable()
    {
        // Geçen süreyi göster
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        // TimeUI'dan geçen süreyi al (veya kendi zamanını tut)
        // Burada örnek olarak 10 saniye gösterelim
        float elapsedTime = 10f; // Gerçek zamanı buradan alabilirsin
        int minute = Mathf.FloorToInt(elapsedTime / 60);
        int second = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    public void OnOneMoreButton()
    {
        // Oyunu yeniden başlat
        GameManager.Instance.SetChangeState(GameState.Play);
        WinLosePopupUI.Instance.HidePopup(); // Ana arka planı kapat
        SceneManager.LoadScene("SampleScene"); // Gerçek oyun için
    }
    public void OnMainMenuButton()
    {
        // Ana menüye dön
        GameManager.Instance.SetChangeState(GameState.GameOver);
        WinLosePopupUI.Instance.HidePopup(); // Ana arka planı kapat
        // SceneManager.LoadScene("MainMenu");
    }
}