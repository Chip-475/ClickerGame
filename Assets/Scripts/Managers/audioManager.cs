using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public static audioManager manager;
    public AudioSource source;
    public AudioMixer mixer;

    void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
    }

    public void playSFX(AudioClip clip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(source, spawn.position, Quaternion.identity); ;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void setMaster(float volume)
    {
        mixer.SetFloat("master", Mathf.Log10(volume) * 20);
    }
    public void setSFX(float volume)
    {
        mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
    public void setBGM(float volume)
    {
        mixer.SetFloat("bgm", Mathf.Log10(volume) * 20);
    }
}