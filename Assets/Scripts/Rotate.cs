using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 RotationSpeed;
    void Update()
    {
        // вращает объект по выбранной оси в инспекторе
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }
}
