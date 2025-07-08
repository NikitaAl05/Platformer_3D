using Unity.VisualScripting;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;
    private SpringJoint _springJoint;
    public Transform RopeStart;
    private float _lenght;

    public RopeState CurrentRopeState;

    public RopeRenderer RopeRenderer;

    public PlayerMove PlayerMove;
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }

        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 20f)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentRopeState == RopeState.Active)
            {
                if (PlayerMove.Grounded == false)
                    PlayerMove.Jump();
            }
            DestroySpring();
        }

        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _lenght);
        }
    }

    void Shot()
    {
        _lenght = 1f;
        if (_springJoint)
            Destroy(_springJoint);

        Hook.gameObject.SetActive(true);

        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.linearVelocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
        
    }

    public void CreateSpring()
    {
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = Hook.Rigidbody;
            _springJoint.anchor = RopeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 100f;
            _springJoint.damper = 5f;

            _lenght = Vector3.Distance(RopeStart.position, Hook.transform.position);
            _springJoint.maxDistance = _lenght;

            CurrentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
