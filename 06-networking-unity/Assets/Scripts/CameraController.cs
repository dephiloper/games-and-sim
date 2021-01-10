using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform target;

    private float _mouseX, _mouseY;

    public float Offset { set; private get; }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        _mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        _mouseY = Mathf.Clamp(_mouseY, -35, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(_mouseY, _mouseX + Offset, 0);
        player.rotation = Quaternion.Euler(0, _mouseX + Offset, 0);
    }
}
