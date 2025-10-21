using UnityEngine;
using TMPro;
using DG.Tweening;



public class TİmeUI : MonoBehaviour
{
    [SerializeField] private RectTransform timeRotatible;
    [SerializeField] private TMP_Text textMesh;

    [Header("Settings")]
    [SerializeField] private float rotationSpeed; // Ne kadar hızda dönüceği
    [SerializeField] private float elapsedTime = 0f; // Geçen süre için
    private bool isRunnig; // İleride oyunu durdurduğumuzda işimize yarayacak

    private void Start()
    {
        StartTime();
    }

    private void StartTime()
    {
        isRunnig = true;
        elapsedTime = 0;
        UpdateTimeDisplay(); // Başlangıçta text'i güncelle
        RotateClockHand(); // Saat dönmeye başla
    }

    private void RotateClockHand()
    {
        if (!isRunnig) return;

        timeRotatible.DORotate(new Vector3(0f, 0f, -rotationSpeed), 1f, RotateMode.FastBeyond360)
          .SetLoops(-1, LoopType.Incremental) // Sonsuza kadar devam et
          .SetEase(Ease.Linear); // Doğrusal dön
    }

    private void Update()
    {
        if (!isRunnig) return;

        elapsedTime += Time.deltaTime;
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        int minute = Mathf.FloorToInt(elapsedTime / 60);
        int seconde = Mathf.FloorToInt(elapsedTime % 60);

        textMesh.text = string.Format("{0:00}: {1:00} ", minute, seconde);
    }
}
