using UnityEngine;

public class HolyWheat : MonoBehaviour , ICollectibels
{
    [SerializeField] PlayerController playerController;

    [SerializeField] float jumpIncreaseSpeed;
    [SerializeField] float resetBoostDuration;
    public void Collect()
    {
        playerController.SetJumpForce(jumpIncreaseSpeed, resetBoostDuration);
        Destroy(gameObject);
    }
}
