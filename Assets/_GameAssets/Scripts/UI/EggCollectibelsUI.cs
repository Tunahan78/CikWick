using DG.Tweening;
using TMPro;
using UnityEngine;

public class EggCollectibelsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text eggCollectedText;

    [Header("Animation Settings")]
    [SerializeField] private float scaleDuration;
    private RectTransform textScale;

    private void Awake()
    {
        textScale = eggCollectedText.GetComponent<RectTransform>();
    }


    private void OnEnable()
    {
        GameManager.OnCollectedMaxEgg += OnAllEggsCollected;
        GameManager.OnCountEgg += UpdateEggCount;
    }
    private void OnDisable()
    {
        GameManager.OnCollectedMaxEgg -= OnAllEggsCollected;
        GameManager.OnCountEgg -= UpdateEggCount;
    }

    private void OnAllEggsCollected()
    {
        eggCollectedText.color = Color.green;
    textScale.DOScale(1.2f, scaleDuration).SetEase(Ease.OutBack)
        .OnComplete(() => textScale.DOScale(1f, scaleDuration).SetEase(Ease.InBack));
    }

    private void UpdateEggCount(int currnetEggCollect)
    {
        eggCollectedText.text = currnetEggCollect.ToString() + "/" + "5";
    }
}
