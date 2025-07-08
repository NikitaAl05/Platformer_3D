using UnityEngine;

public class SetTriggerEveryNSecond : MonoBehaviour
{
    public float Period = 7f;
    public Animator Animator;
    private float _timer;

    public string TriggerName = "Attack";
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > Period)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
