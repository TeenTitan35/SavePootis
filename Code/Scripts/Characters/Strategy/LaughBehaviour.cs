using UnityEngine;

public class LaughBehaviour : ISpeak
{
    private readonly AudioSource _source;
    private readonly AudioClip[] _clips;
    public LaughBehaviour(AudioSource source, AudioClip[] clips)
    {
        _source = source;
        _clips = clips;
    }

    public void Speak()
    {
        if(_source.isPlaying == false)
            _source.PlayOneShot(GetRandomClip());
    }

    private AudioClip GetRandomClip()
    {
        var audio = _clips[Random.Range(0, _clips.Length)];
        return audio;
    }
}
