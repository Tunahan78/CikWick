using System;
using UnityEngine;

public class HolyWheat : MonoBehaviour , ICollectibels
{
    public static event Action<string> OnCollectWheat;
    [SerializeField] PlayerController playerController;

    [SerializeField] float jumpIncreaseSpeed;
    [SerializeField] float resetBoostDuration;
    public void Collect()
    {
        playerController.SetJumpForce(jumpIncreaseSpeed, resetBoostDuration);
        OnCollectWheat?.Invoke("HolyWheat");
        Destroy(gameObject);
    }
}
