#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float DistanceToActivate;
    private bool _isActive = true;
    private Activator _activator;
    private void Start()
    {
        // добавляет объекты в список
        _activator = FindFirstObjectByType<Activator>();
        _activator.ObjectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > DistanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }

    }
    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    // При уничтожении ужадяет объекты из списка
    private void OnDestroy()
    {
        _activator.ObjectsToActivate.Remove(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.black;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif
}
