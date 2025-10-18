using UnityEngine;

public class PlayerIntreractionController : MonoBehaviour
{ 
     private PlayerController _playerController;
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<ICollectibels>(out var collectibel))
        {
            collectibel.Collect();
        }

    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<IBoosters>(out var booster))
        {
            booster.Boost(_playerController);
        }
    }
}
