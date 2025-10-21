using System;
using UnityEngine;

public class Egg : MonoBehaviour, ICollectibels

{
    public static event Action OnCollectEgg;
    public void Collect()
    {
        Debug.Log("Egg collect");
        OnCollectEgg?.Invoke();
        Destroy(gameObject);
    }
}
