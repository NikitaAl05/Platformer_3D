using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 10f;
    public float ShotPeriod = 0.2f;
    private float _timer;

    public AudioSource ShotSound;
    public GameObject Flash;

    public ParticleSystem ShotEffect;

    void Update()
    {
        // созадем пулую каждую ShotPeriod секунду
        _timer += Time.unscaledDeltaTime;
        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                Shot();
            }

        }
    }

    public virtual void Shot()
    {
        GameObject newBulet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBulet.GetComponent<Rigidbody>().linearVelocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();

        Flash.SetActive(true);
        // вызывем скрипт HideFlash через 0.12 секунды
        Invoke("HideFlash", 0.12f);
        ShotEffect.Play();
    }
    public void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets){}
}
