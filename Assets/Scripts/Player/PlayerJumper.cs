using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15;

    private CharacterController _characterController;
    private Vector3 _verticalVelocity = Vector3.zero;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        if (_characterController == null)
            return;

        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _verticalVelocity = Vector3.up * _jumpForce;
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime;
        }

        Vector3 horizontalVelocity = _characterController.velocity;
        horizontalVelocity.y = 0;
        _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
    }
}
