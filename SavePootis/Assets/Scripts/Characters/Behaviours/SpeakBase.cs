using UnityEngine;

public class SpeakBase : ISpeakable
{
    protected AudioSource audioSource;
    protected AudioClip[] clips;
    protected AudioClip clip;

    public SpeakBase(AudioSource source, AudioClip[] clips)
    {
        audioSource = source;
        this.clips = clips;
    }
    public SpeakBase(AudioSource source, AudioClip clip)
    {
        audioSource = source;
        this.clip = clip;
    }

    public virtual void Speak()
    {
        if (audioSource.isPlaying)
            return;
        audioSource.PlayOneShot(clips[GetRandomAudio(clips.Length)]);
    }

    protected int GetRandomAudio(int length)
    {
        return Random.Range(0, length);
    }
}
