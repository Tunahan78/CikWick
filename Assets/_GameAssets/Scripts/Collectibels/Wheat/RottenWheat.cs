using System;
using UnityEngine;

public class RottenWheat : MonoBehaviour , ICollectibels

{
    public static event Action<string> OnCollectWheat;
    [SerializeField] PlayerController playerController;

    [SerializeField] float movementDecrimentSpeed;
    [SerializeField] float resetBoostDuration;
    public void Collect()
    {
        playerController.SetMovementSpeed(movementDecrimentSpeed, resetBoostDuration);
        OnCollectWheat?.Invoke("RottenWheat");
        Destroy(gameObject);
    }
    
}
