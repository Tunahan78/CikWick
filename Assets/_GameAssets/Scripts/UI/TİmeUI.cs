using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private RectTransform timeRotatible;
    [SerializeField] private TMP_Text textMesh;

    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 6f; // 6°/saniye
    private float elapsedTime = 0f;
    private bool isRunning = false;

    private void Start()
    {
        StartTime();
    }

    private void OnEnable()
    {
        GameManager.OnChangeState += PauseTime;
    }

    private void OnDisable()
    {
        GameManager.OnChangeState -= PauseTime;
    }

    private void PauseTime(GameState state)
    {
        isRunning = (state == GameState.Play);
        Debug.Log("TimeUI: " + state);
    }

    private void StartTime()
    {
        isRunning = true;
        elapsedTime = 0f;
        UpdateTimeDisplay();
        // DOTween kullanmıyoruz
    }

    private void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;
        UpdateTimeDisplay();

        // ✅ Saat elini her frame döndür
        timeRotatible.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }

    private void UpdateTimeDisplay()
    {
        int minute = Mathf.FloorToInt(elapsedTime / 60);
        int second = Mathf.FloorToInt(elapsedTime % 60);
        textMesh.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
