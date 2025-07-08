using Unity.VisualScripting;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;

    public Collider Collider;
    public Collider PlayerCollider;
    public RopeGun RopeGun;

    private void Start()
    {
        // чтоб hook не ставлкивался с collider player
        Physics.IgnoreCollision(Collider, PlayerCollider);
    }
    void OnCollisionEnter(Collision collision)
    {
        // проверяем если ли joint на объекте
        if (_fixedJoint == null)
        {
            // добавляем joint к gamobject
            _fixedJoint = gameObject.AddComponent<FixedJoint>();

            // проверяем есть ли rigidbody на gamobject
            if (collision.rigidbody)
            {
                // connect rigidbody hook к gamobject
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            RopeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
