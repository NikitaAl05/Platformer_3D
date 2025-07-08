using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxRotationSpeed;
    void Start()
    {
        //  запускаем орех
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        // закручиваем орех
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed),
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed),
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed)
        );
    }

}
