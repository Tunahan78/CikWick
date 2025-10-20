
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class HealtUI : MonoBehaviour
{
    [Serializable]
    public struct HealthSlot
    {
        public Image healthActive;      // Aktif can simgesi
        public Image healthInactive;    // Pasif (hasarlı) can simgesi
    }

    [Header("Health Slots")]
     [SerializeField] private HealthSlot[] healthSlots;

    [SerializeField] private Image healtInActive;

    // ToDo : Oyun bittiğinde gösterilecek "öldü" ekranı (veya simge)

    [Header("Animation Settings")]
    [SerializeField] private float animationDuration;
    [SerializeField] private Ease easeType = Ease.OutBack;

    private void OnEnable()
    {
        HealtManager.OnPlayerDamage += UpdateHealthUI;
        HealtManager.OnPlayerDead += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        HealtManager.OnPlayerDamage -= UpdateHealthUI;
        HealtManager.OnPlayerDead -= HandlePlayerDeath;
    }

   private void HandlePlayerDeath()
    {
        // ✅ Tüm canları pasife çevir (zaten UpdateHealthUI zaten bunu yapıyor ama emin olmak için tekrar çalıştır)
        for (int i = 0; i < healthSlots.Length; i++)
        {
            healthSlots[i].healthActive.gameObject.SetActive(false);
            healthSlots[i].healthInactive.gameObject.SetActive(true);

            // ✅ Animasyon ekle (tekrar)
            healthSlots[i].healthInactive.rectTransform.localScale = Vector3.zero;
            healthSlots[i].healthInactive.DOFade(1f, animationDuration).SetEase(easeType);
            healthSlots[i].healthInactive.rectTransform.DOScale(1f, animationDuration).SetEase(easeType);
        }

        // ✅ Log mesajı
        Debug.Log("OYUNCU ÖLDÜ! Game Over.");
    }

    private void UpdateHealthUI(float currentHealth)
    {
        // ✅ Tüm slotları dolaş
        for (int i = 0; i < healthSlots.Length; i++)
        {
            if (i < currentHealth)
            {
                // ✅ Bu can hala var → Active göster, Inactive gizle
                healthSlots[i].healthActive.gameObject.SetActive(true);
                healthSlots[i].healthInactive.gameObject.SetActive(false);

                // ✅ Eğer daha önce gizlenmişse, küçükten büyümeye geri dön
                healthSlots[i].healthActive.rectTransform.localScale = Vector3.zero;
                healthSlots[i].healthActive.DOFade(1f, animationDuration).SetEase(easeType);
                healthSlots[i].healthActive.rectTransform.DOScale(1f, animationDuration).SetEase(easeType);
            }
            else
            {
                // ✅ Bu can yok → Active gizle, Inactive göster
                healthSlots[i].healthActive.gameObject.SetActive(false);
                healthSlots[i].healthInactive.gameObject.SetActive(true);

                // ✅ Inactive'e animasyon ekle: küçükten büyümeye + solma
                healthSlots[i].healthInactive.rectTransform.localScale = Vector3.zero;
                healthSlots[i].healthInactive.DOFade(1f, animationDuration).SetEase(easeType);
                healthSlots[i].healthInactive.rectTransform.DOScale(1f, animationDuration).SetEase(easeType);
            }
        }
    }
    
    
}
