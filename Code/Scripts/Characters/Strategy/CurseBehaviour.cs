using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class CurseBehaviour : ISpeak
{
    private readonly AudioSource _source;
    private readonly AudioClip _startClip;
    private readonly AudioClip[] _clips;
    private CancellationTokenSource token;

    private int count = 10;

    public CurseBehaviour(AudioSource source, AudioClip startClip, AudioClip[] clips)
    {
        _source = source;
        _startClip = startClip;
        _clips = clips;
    }

    public void Speak()
    {
        if (_source.isPlaying)
            _source.Stop();

        token = new CancellationTokenSource();
        _source.PlayOneShot(_startClip);
        Curse(token.Token);
    }

    private async void Curse(CancellationToken token)
    {
        if (count > 0)
        {
            count--;
            var audio = GetRandomClip();
            _source.PlayOneShot(audio);
            await Task.Delay(System.TimeSpan.FromSeconds(audio.length), token);
            Curse(token);
        }
    }

    public void StopCursing() => token?.Cancel();

    private AudioClip GetRandomClip()
    {
        var audio = _clips[Random.Range(0, _clips.Length)];
        return audio;
    }
}
