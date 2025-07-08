using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        // проверяет есть ли на объекте rigidbody
        if (collision.rigidbody)
        {
            // проверяет есть ли на объекте Bullet
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                // вызываем у скрипта EnemyHealth метод TakeDamage
                EnemyHealth.TakeDamage(1);
            }
        }
        // если в инспекторе стоит галочка то урон наносится объекту от любого объекта
        if (DieOnAnyCollision == true)
        {
            EnemyHealth.TakeDamage(1);
        }
    }
}
