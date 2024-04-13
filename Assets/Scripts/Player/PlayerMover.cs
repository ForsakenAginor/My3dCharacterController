using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _strafeSpeed = 1.0f;
    [SerializeField] private Camera _camera;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_characterController == null)
            return;

        if (_characterController.isGrounded)
        {
            Vector3 forward = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_camera.transform.right, Vector3.up).normalized;
            Vector3 direction;
            direction = forward * Input.GetAxis(Vertical) * _speed + right * Input.GetAxis(Horizontal) * _strafeSpeed;

            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))            
                direction = Vector3.ProjectOnPlane(direction, hitInfo.normal).normalized * direction.magnitude;            

            direction += Vector3.down * 5;
            _characterController.Move(direction * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        var player = GetComponent<CharacterController>();

        Gizmos.color = Color.red;
        Vector3 size = new Vector3(1, player.height, 1);
        Gizmos.DrawCube(transform.position, size);
    }
}
