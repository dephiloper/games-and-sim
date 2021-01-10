using TMPro;
using UnityEngine;
using Mirror;

public class GoalBehaviour : NetworkBehaviour
{
    [SerializeField]
    private TextMeshPro text;

    [SyncVar(hook = nameof(UpdateCount))]
    private int count = 0;

    private void Start()
    {
        text.text = count.ToString();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (isServer) count++;
    }

    private void UpdateCount(int oldValue, int newValue) {
        text.text = count.ToString();
    }
}
