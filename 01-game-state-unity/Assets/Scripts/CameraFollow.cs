using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private Vector3 _cameraOffset;


    void Start() {
    }

    void FixedUpdate()
    {
        //transform.RotateAround(_player.transform.position, Vector3.up, _player.Angle * Time.deltaTime);
    }
}
