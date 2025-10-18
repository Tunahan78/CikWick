using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Camera References")]
    [SerializeField] private Transform _playertransform;
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private Transform _playerVisualTransform;

    [Header("Camera Settings")]
    [SerializeField] private float cameraspeed;

    private void Update()
    {

        Vector3 viewdirection = _playertransform.position - new Vector3(transform.position.x, _playertransform.position.y, transform.position.z);

        _orientationTransform.forward = viewdirection.normalized;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = _orientationTransform.forward * verticalInput + _orientationTransform.right * horizontalInput;
        if (inputDirection != Vector3.zero)
        {
            _playerVisualTransform.forward = Vector3.Slerp(_playerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * cameraspeed);
        }
    }












}
