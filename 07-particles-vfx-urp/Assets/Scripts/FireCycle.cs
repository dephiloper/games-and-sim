using UnityEngine;
using UnityEngine.VFX;

public class FireCycle : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect;
    private float elapsedTime;
    private const float speed = 10f;

    private bool flameOn = false;

    private void Start() {
        var flameIntensity = visualEffect.GetFloat("FlameIntensity");
        visualEffect.SetFloat("FlameIntensity", Mathf.Max(flameIntensity -= Time.deltaTime, 0.0f));
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        var currentRotation = Mathf.Repeat(45 + elapsedTime * speed, 360.0f);
        var flameIntensity = visualEffect.GetFloat("FlameIntensity");

        if (currentRotation > 150 && !flameOn)
            flameOn = true;
        if (currentRotation < 150 && flameOn)
            flameOn = false;

        if (flameOn && flameIntensity < 2.0f)
            visualEffect.SetFloat("FlameIntensity", Mathf.Min(flameIntensity += Time.deltaTime, 2.0f));
        if (!flameOn && flameIntensity > 0.0f)
            visualEffect.SetFloat("FlameIntensity", Mathf.Max(flameIntensity -= Time.deltaTime, 0.0f));

    }
}
