using UnityEngine;

public class RottenWheat : MonoBehaviour , ICollectibels
{
    [SerializeField] PlayerController playerController;

    [SerializeField] float movementDecrimentSpeed;
    [SerializeField] float resetBoostDuration;
    public void Collect()
    {
        playerController.SetMovementSpeed(movementDecrimentSpeed, resetBoostDuration);
        Destroy(gameObject);
    }
}
