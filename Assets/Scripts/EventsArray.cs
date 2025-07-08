using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] Events;

    // добавил Event в Insprctor
    public void StartEvent(int eventIndex)
    {
        Events[eventIndex].Invoke();
    }
}
