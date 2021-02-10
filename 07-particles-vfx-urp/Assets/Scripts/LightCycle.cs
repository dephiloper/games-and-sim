using UnityEngine;

public class LightCycle : MonoBehaviour
{
    private float elapsedTime;
    private const float speed = 10f; 

    void Update()
    {
        elapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.Euler(Mathf.Repeat(45 + elapsedTime * speed, 360.0f) , 130.0f, 90.0f);
    }
}
