using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{

    public Vector3 LeftEuler;
    public Vector3 RightEuler;

    public float RotationSpeed = 5f;
    private Transform _playerTransform;
    private Vector3 _targetEuler;
    void Start()
    {
        _playerTransform = FindFirstObjectByType<PlayerMove>().transform;
    }

    void Update()
    {
        if (transform.position.x < _playerTransform.position.x)
        {
            //повернутся вправо
            _targetEuler = RightEuler;
        }
        else
        {
            // повернутся влево
            _targetEuler = LeftEuler;

        }

        // Quaternion.Euler -  переводит Vector3 в Quaternion
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
