using UnityEngine;

public class ScreamBehaviour : SpeakBase
{
    public ScreamBehaviour(AudioSource source, AudioClip clip) : base(source, clip)
    {
    }
    public override void Speak()
    {
        audioSource.PlayOneShot(clip);
    }
}
