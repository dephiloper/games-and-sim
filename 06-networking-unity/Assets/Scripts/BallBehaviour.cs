using Mirror;
using UnityEngine;

public class BallBehaviour : NetworkBehaviour
{
    [SerializeField]
    private float bounceForce = 2;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            _rigidBody.AddExplosionForce(bounceForce, contact.point, 2, 0, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (isServer)
        {
            if (collision.gameObject.CompareTag("Goal"))
            {
                _rigidBody.velocity = Vector3.zero;
                _rigidBody.position = new Vector3(Random.Range(-3.0f, 3.0f), 3.0f, Random.Range(-3.0f, 3.0f));
            }
        }
    }
}
