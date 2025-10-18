using System.Runtime.CompilerServices;
using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoosters
{
    [Header("Animator")]
    [SerializeField] private Animator _spatulaanimator; // sonradan ekledim
    [Header("Booster Settings")]
    [SerializeField] private float _jumpForce;

    private bool _isActivated;

    public void Boost(PlayerController playerController)
    {
        if (_isActivated) return; //
        PlayerBoostAnimaton();//
        Rigidbody playerRigidbody = playerController.GetPlayerRigidbody();


        playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z);
        playerRigidbody.AddForce((transform.forward) * _jumpForce, ForceMode.Impulse);
        _isActivated = true; //
}

 private void PlayerBoostAnimaton() {//
        _spatulaanimator.SetTrigger("IsSpatulaJumping");//
        Invoke("ResetBoostAnim", 0.2f);//
    }
    private void ResetBoostAnim()
    {
        _isActivated = false;
    }

}
