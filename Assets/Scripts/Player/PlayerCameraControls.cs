using UnityEngine;

public class PlayerCameraControls : MonoBehaviour
{
    private const string AxisMouseX = "Mouse X";
    private const string AxisMouseY = "Mouse Y";

    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalMouseSensitivity = 5;
    [SerializeField] private float _verticalMouseSensitivity = 10;

    private float _maxVerticalCameraAngle = 89;
    private float _minVerticalCameraAngle = -89;
    private float _currentVerticalCameraAngle = 0;

    private void Awake()
    {
        _currentVerticalCameraAngle = _cameraTransform.rotation.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        _currentVerticalCameraAngle -= Input.GetAxis(AxisMouseY) * _verticalMouseSensitivity;
        _currentVerticalCameraAngle = Mathf.Clamp(_currentVerticalCameraAngle, _minVerticalCameraAngle, _maxVerticalCameraAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _currentVerticalCameraAngle;
        transform.Rotate(Input.GetAxis(AxisMouseX) * _horizontalMouseSensitivity * Vector3.up);
    }
}
