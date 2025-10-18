using UnityEngine;


public class AnimationController : MonoBehaviour
{
    
    [SerializeField] private Animator _playerAnimator;
    private PlayerController _playerController;
    private StateController _stateController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _stateController = GetComponent<StateController>();
    }
    private void Update()
    {
        SetAnimation();
        float speed = _playerController.GetCurrentSpeed();
        _playerAnimator.SetFloat("Speed", speed);
    }


    private void SetAnimation()
    {

        var _currentState = _stateController.GetCurrentState();
        {
            switch (_currentState)
            {
                case PlayerState.Idle:
                    _playerAnimator.SetBool("IsSliding", false);
                    _playerAnimator.SetFloat("Speed", 0.01f);
                    _playerAnimator.SetBool("IsJumping", false);
                    
                    break;
                case PlayerState.Move:
                    _playerAnimator.SetFloat("Speed", 0.01f);
                    _playerAnimator.SetBool("IsSliding", false);
                    _playerAnimator.SetBool("IsJumping", false);
                    
                    break;
                case PlayerState.SlideIdle:
                    _playerAnimator.SetBool("IsSliding", true);
                    _playerAnimator.SetFloat("Speed", 0.01f);
                    _playerAnimator.SetBool("IsJumping", false);
                    
                    break;
                case PlayerState.Slide:
                    _playerAnimator.SetBool("IsSliding", true);
                    _playerAnimator.SetBool("IsMoving", true);
                    _playerAnimator.SetBool("IsJumping", false);
                    
                    break;
                case PlayerState.Jump:
                    _playerAnimator.SetBool("IsJumping", true);
                    break;
            }
        }
    }
    

}
