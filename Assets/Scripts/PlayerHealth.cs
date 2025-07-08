using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;

    // неуязвимость
    private bool _invulnerable = false;

    public AudioSource AddHealthSound;

    public HealthUI healthUI;

    public UnityEvent EventOnTakeDamage;
    private void Start()
    {
        healthUI.Setup(MaxHealth);
        healthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue){

        if (_invulnerable == false){
            Health -= damageValue;

            if ( Health <= 0){
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);

            healthUI.DisplayHealth(Health);

            EventOnTakeDamage.Invoke();
        }
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }
    public void AddHealth(int healthValue){
        Health += healthValue;
        if (Health > MaxHealth){
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        healthUI.DisplayHealth(Health);
    }
    void Die()
    {
        Debug.Log("You Lose");
    }
}
