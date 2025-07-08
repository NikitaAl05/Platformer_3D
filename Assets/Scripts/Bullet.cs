using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
