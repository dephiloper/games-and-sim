using UnityEngine;
using UnityEngine.VFX;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private CameraController _cameraController;

    private Rigidbody _rigidbody;

    private bool isPlaying;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void HandleMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical);
        var positionOffset = transform.position + transform.TransformDirection(direction.normalized * Time.fixedDeltaTime * 5);
        _rigidbody.MovePosition(positionOffset);
    }

    void FixedUpdate()
    {
        HandleMovement();

        if (Input.GetKey("space"))
        {
            if (!isPlaying)
            {
                visualEffect.Play();
                isPlaying = true;
            }
        }
        else
        {
            visualEffect.Stop();
            isPlaying = false;
        }

        if (isPlaying)
        {
            visualEffect.SetVector3("Position", transform.position);
            visualEffect.SetVector3("Velocity", transform.forward * 10);

            if (Physics.Raycast(transform.position, transform.forward, out var hit, 20))
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent(out Barrel barrel))
                        barrel.Invoke("Burn", 0.5f);
                }
        }
    }
}
