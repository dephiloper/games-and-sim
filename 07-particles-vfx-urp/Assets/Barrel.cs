using UnityEngine;
using UnityEngine.VFX;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect;
    private bool isBurning;

    private void Start()
    {
        visualEffect.Stop();

    }

    public void Burn()
    {
        if (isBurning) return;
        visualEffect.Play();
    }
}
