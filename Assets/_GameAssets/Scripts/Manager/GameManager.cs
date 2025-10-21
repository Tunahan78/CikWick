using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnCountEgg;
    public static event Action OnCollectedMaxEgg;
    [SerializeField] private int maxEggCollectibles = 5;

    private int currnetEggCollect = 0;


    private void OnEnable()
    {
        Egg.OnCollectEgg += EggCollected;
    }

    private void OnDisable()
    {
        Egg.OnCollectEgg -= EggCollected;
    }

    private void EggCollected()
    {
        currnetEggCollect++;
        Debug.Log("Toplanan yumurta sayısı : " + currnetEggCollect);
        OnCountEgg?.Invoke(currnetEggCollect);


        if (currnetEggCollect == maxEggCollectibles)
        {
            //ToDo : Oyun bitirme ekranı yapılacak
            OnCollectedMaxEgg?.Invoke();
            Debug.Log("Game Win!!");
        }
    }
}
