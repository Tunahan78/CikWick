using System;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public static event Action<float> OnPlayerDamage;
    public static event Action OnPlayerDead;
    [SerializeField] private float maxHealt;

    private float currentHealt;

    private void Start()
    {
        currentHealt = maxHealt;
    }
    public void Damage(float damageAmount)
    {
        if (currentHealt > 0)
        {
            currentHealt -= damageAmount;
            OnPlayerDamage?.Invoke(currentHealt);
            //ToDo:UI da canı azaltma animasyonunu ekle

            if (currentHealt <= 0)
            {
                OnPlayerDead?.Invoke();
                //ToDo:Ölme fonksiyonu yaz
            }
        }
    }

    public void Heal(float healAmount)
    {
        if (currentHealt < maxHealt)
        {
            currentHealt = Mathf.Min(currentHealt + healAmount, maxHealt);
            //ToDo:UI da canı arttırma yap
        }

    }
    
    // Kontrol amaçlı koda bir faydası yok 
    
     private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Damage(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            OnPlayerDead();
        }
    }
    
}
