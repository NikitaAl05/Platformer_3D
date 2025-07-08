using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}
public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public float Speed;
    public float StopTime;
    public Direction CurrentDirection;
    private bool _isStoped;
    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;
    public Transform RayStart;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }
    void Update()
    {
        // запускаем код когда свин не стоит на месте
        if (_isStoped == true) { return; }

        // если идет влево
        if (CurrentDirection == Direction.Left)
        {
            // идет влево
            transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
            // если уже больше чем LeftTarget то 
            if (transform.position.x < LeftTarget.position.x)
            {
                // то идет вправо
                CurrentDirection = Direction.Right;
                // остановка
                _isStoped = true;
                // через StopTime идет вдругую сторону
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStoped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget.Invoke();
            }
        }

        // создаем луч
        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStoped = false;
    }
}
