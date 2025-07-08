using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _startFixedDeltaTime;
    public float TimeScale = 0.2f;
    void Start()
    {
        // сохраняем currency fixed timestep
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = TimeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
        // чтоб при замедление времени частота кадров была одинаковой и рывков не было
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
