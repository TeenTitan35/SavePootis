using System.Collections;
using UnityEngine;

public class Engineer : MonoBehaviour, IDamageable
{
    [Header("Health and damaging")]
    [SerializeField] private float _health;
    [SerializeField] private float _timeToBlink;
    [SerializeField] private Color _stockColor;
    [SerializeField] private Color _damagedColor;
    private SpriteRenderer _spriteRenderer;

    [Header("Strategy")]
    [SerializeField] private SentryTurret _sentry;
    [SerializeField] private ISpeakable _speakBehaviour;

    [Header("Audio")]
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _laughs;
    [SerializeField] private AudioClip[] _swears;
    [SerializeField] private AudioClip _sentryDownAudio;

    private void OnEnable()
    {
        _sentry.OnSentryShoot += Laugh;
        _sentry.OnSentryDown += Swear;
    }
    private void OnDisable()
    {
        _sentry.OnSentryShoot -= Laugh;
        _sentry.OnSentryDown -= Swear;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _speakBehaviour = new LaughBehaviour(_audioSource, _laughs);
    }

    private void Laugh()
    {
        _speakBehaviour.Speak();
    }

    public void Swear()
    {
        _speakBehaviour = new ScreamBehaviour(_audioSource, _sentryDownAudio);
        _speakBehaviour.Speak();
        _speakBehaviour = new SwearBehaviour(_audioSource, _swears);
    }

    public IEnumerator BlinkAfterDamaging()
    {
        _spriteRenderer.color = _damagedColor;
        yield return new WaitForSeconds(_timeToBlink);
        _spriteRenderer.color = _stockColor;
    }

    public void RecieveDamage(float damage)
    {
        _health -= damage;
        _speakBehaviour.Speak();
        StartCoroutine(nameof(BlinkAfterDamaging));
        if (_health <= 0)
            Destroy(gameObject);
    }
}
