using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager manager;
    public AudioSource source;

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
}