using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private CameraController _cameraController;

    [SerializeField]
    private Material player2Material;

    private Rigidbody _rigidbody;

    void Start() {
        if (!isLocalPlayer)
            _camera.gameObject.SetActive(false);


        if (isServer && hasAuthority) {
            GetComponent<MeshRenderer>().material = player2Material;
            transform.position = transform.position -= Vector3.left * 4;
            _cameraController.Offset = -90;
        }

        if (isClientOnly) {
            if (!hasAuthority)
               GetComponent<MeshRenderer>().material = player2Material;
    
            transform.position = transform.position += Vector3.left * 4;
            _cameraController.Offset = 90;
        }

        _rigidbody = GetComponent<Rigidbody>();
    }

    void HandleMovement()
    {
        if (!isLocalPlayer) return;

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical);
        var positionOffset = transform.position + transform.TransformDirection(direction.normalized * Time.fixedDeltaTime * 5);
        _rigidbody.MovePosition(positionOffset);
    }

    void FixedUpdate()
    {
        HandleMovement();
    }
}
