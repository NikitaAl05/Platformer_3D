using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        // ищет collider у обекта
        if (other.attachedRigidbody)
        {
            // смотрит есть ли у gameobject script PlayerHealth
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(DamageValue);
            }
        }
    }
}
