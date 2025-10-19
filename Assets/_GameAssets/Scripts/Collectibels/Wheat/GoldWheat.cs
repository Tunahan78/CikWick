using System;
using UnityEngine;

public class GoldWheat : MonoBehaviour , ICollectibels
{
    public static event Action<string> OnCollectWheat;
    [SerializeField] PlayerController playerController;

    [SerializeField] float movementIncreaseSpeed;
    [SerializeField] float resetBoostDuration;
    public void Collect()
    {
        playerController.SetMovementSpeed(movementIncreaseSpeed, resetBoostDuration);
        OnCollectWheat?.Invoke("GoldWheat");
        Destroy(gameObject);
    }
}
