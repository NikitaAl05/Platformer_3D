using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int GunIndex;
    public int NumberOfBullets;
    private void OnTriggerEnter(Collider other)
    {
        PlayerArmory playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();
        if (playerArmory)
        {
            playerArmory.AddBullets(GunIndex, NumberOfBullets); // addBullets
            Destroy(gameObject);
        }
    }
}
