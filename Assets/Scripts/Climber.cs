using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Climber : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Transform _stepCheck;
    [SerializeField] private float _maxStepSize;

    private BoxCollider _boxCollider;
    private float _colliderFront;
    private float _colliderBottom;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        float sizeMultiplier = 2f;
        _colliderFront = _boxCollider.size.x / sizeMultiplier;
        _colliderBottom = -_boxCollider.size.y / sizeMultiplier;
        _groundChecker.localPosition = new Vector3(0, _colliderBottom,0);
        _stepCheck.localPosition = new Vector3(0, _colliderBottom + _maxStepSize, 0);
    }

    private void FixedUpdate()
    {
        float scanDistance = 0.05f;

        if (Physics.Raycast(_groundChecker.transform.position, transform.TransformDirection(Vector3.forward), _colliderFront + scanDistance)
            && (Physics.Raycast(_stepCheck.transform.position, transform.TransformDirection(Vector3.forward), _colliderFront + scanDistance) == false))
                transform.position += new Vector3(0, _maxStepSize, 0) * Time.deltaTime;
    }
}
