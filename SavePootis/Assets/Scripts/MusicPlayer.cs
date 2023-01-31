using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private float _cutValue;
    [SerializeField] private AudioClip[] _musics;
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        StartCoroutine(SwitchMusic());
    }

    private IEnumerator SwitchMusic()
    {
        for (int i = 0; i < _musics.Length; i++)
        {
            _source.PlayOneShot(_musics[i]);
            yield return new WaitForSeconds(_musics[i].length - _cutValue);
        }
        _source.clip = _musics[_musics.Length - 1];
        _source.loop = true;
        _source.Play();
    }
}
