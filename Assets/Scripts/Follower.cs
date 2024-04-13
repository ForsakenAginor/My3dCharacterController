using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _offset;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        _rigidbody.velocity = Vector3.zero;
        Vector3 direction = _player.position - _transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        float gravityFactor = 2f;

        if (direction.magnitude > _offset)
            _rigidbody.velocity = (direction.normalized * _speed) + Vector3.down * gravityFactor;         
    }
}
