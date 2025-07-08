using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform Target;
    void Update()
    {
        transform.position = Target.position;
    }
}
