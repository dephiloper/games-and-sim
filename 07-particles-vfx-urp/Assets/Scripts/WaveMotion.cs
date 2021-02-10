using UnityEngine;

public class WaveMotion : MonoBehaviour
{
    private Vector3 localPos = Vector3.zero;
    private float elapsedTime = 0f;
    private Quaternion defaultRotation;

    void Start() {
        defaultRotation = transform.rotation;
    }

    void Update()
    {  
        elapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.Euler(2 * Mathf.Cos(Time.time * 1.5f), defaultRotation.eulerAngles.y, 4 * Mathf.Sin(Time.time * 3f));
    }
}
