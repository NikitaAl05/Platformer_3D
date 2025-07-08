using UnityEngine;

public class Rocket : MonoBehaviour
{

    public float Speed;
    public float RotationSpeed;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindFirstObjectByType<PlayerMove>().transform;
    }

    void Update()
    {
        // чтоб ракета стримилась к 0z
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
        // постоянаня скорость вдоль своей оси Z
        transform.position += Time.deltaTime * transform.forward * Speed;

        // вектор от ракеты к игроку
        Vector3 toPlayer = _playerTransform.position - transform.position;

        //поворачиваем ракету по направлению к игроку
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        // ракета приследует игрока и мгновенно поворачивается по напрвлению игрока
        // если доабвить Quaternion.Lerp - то ракета будет постепенно поворачиватся к игроку
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
}
