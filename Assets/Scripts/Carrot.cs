using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        // находит в иерархии объект со скриптом playerMove
        Transform playerTransform = FindFirstObjectByType<PlayerMove>().transform;
        // расчитывает расстояние до player
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        // постоянная скорость
        Rigidbody.linearVelocity = toPlayer * Speed;
        
        Destroy(gameObject, 4f);
    }

}
