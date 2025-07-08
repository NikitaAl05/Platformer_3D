using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private Transform _playerTransform;
    public float Speed = 3f;
    public float TimeToReachSpeed = 1f;

    private void Start()
    {
        //_playerTransform = FindObjectOfType<PlayerMove>().transform;
        // замена FindObjectOfType
        _playerTransform = FindFirstObjectByType<PlayerMove>()?.transform;


    }

    void FixedUpdate()
    {
        // чем курица дальше тем растояние будет длинее (ToPlayer) если не normalized
        // норамлизуем чтоб вектор был всегда 1
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.linearVelocity) / TimeToReachSpeed;

        Rigidbody.AddForce(force);

    }
    
}
