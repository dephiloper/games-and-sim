using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MovementSpeed = 2000;
    private const int RotationSpeed = 2;
    private Rigidbody _rigidbody;

    private float _angle;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _angle = _rigidbody.rotation.eulerAngles.y; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var inputDir = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
        var force = inputDir * MovementSpeed * Time.fixedDeltaTime;
        _angle += Input.GetAxis("Horizontal") * RotationSpeed;

        _rigidbody.MoveRotation(Quaternion.Euler(new Vector3(0.0f, _angle, 0.0f)));
        _rigidbody.AddRelativeForce(force);

        if (_rigidbody.velocity.magnitude > 10)
            _rigidbody.velocity = _rigidbody.velocity.normalized * 10;

        //transform.
    }
}
