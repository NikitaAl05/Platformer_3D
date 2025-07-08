using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;

    public void SetMusicEnabled(bool value)
    {
        Music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
