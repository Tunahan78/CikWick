using UnityEngine;

public class GoldWheat : MonoBehaviour , ICollectibels
{
    [SerializeField] PlayerController playerController;

    [SerializeField] float movementIncreaseSpeed;
    [SerializeField] float resetBoostDuration;
    public void Collect()
    {
        playerController.SetMovementSpeed(movementIncreaseSpeed, resetBoostDuration);
        Destroy(gameObject);
    }
}
