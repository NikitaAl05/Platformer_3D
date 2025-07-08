using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;

    private void OnTriggerEnter(Collider other)
    {

        // смотрит к какому rigidbody он закреплен
        if (other.attachedRigidbody)
        {
            // проверяет есть ли на объекте Bullet
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                // вызываем у скрипта EnemyHealth метод TakeDamage
                EnemyHealth.TakeDamage(1);
            }
        }
        // если в инспекторе стоит галочка то урон наносится объекту от любого объекта
        if (DieOnAnyCollision == true)
        {
            // если он не тригер, то только в этом случае отнимаем здоровье
            if (other.isTrigger == false)
            {
                EnemyHealth.TakeDamage(100);
            }
        }
    }
}
