 using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public class Pointer : MonoBehaviour
{

    public Transform Aim;
    public Camera PlayerCamera;
    public Transform Body;
    float _yEuler;

    void LateUpdate()
    {
        //Создаем луч
        // Input.mousePosition - показывает где находится курсор 
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        //Рисует луч
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

        //Создаем плоскость (Куда смотрит нормаль и проходит чезер 0 кординат
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        // находим Пересечение луча и плоскости
        //сохраняет расстояние которое должен пройти луч перед тем как врезаться в плоскость
        float distance;
        // позволяет выстрелить в плоскость лучем ( какой именно луч)
        plane.Raycast(ray, out distance);
        //GetPoint - возваращает точку которая находится на какому-то расстояние в доль этого луча
        Vector3 point = ray.GetPoint(distance);

        Aim.position = point;

        // gun следует за прицелом 
        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        // поворот туловища
        if (toAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8f);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8f);
        }
        Body.localEulerAngles = new Vector3(0f, _yEuler, 0f);
        
    }
}