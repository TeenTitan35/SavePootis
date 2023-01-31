using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bat : MonoBehaviour, IAlternateAttackWeapon
{
    [Header("General stats")]
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _enemyLayers;
    
    [Header("Alternate attack stats")]
    [SerializeField] private Projectile _ball;

    [Header("Audio")]
    [SerializeField] private AudioClip _regularAttackSound;
    [SerializeField] private AudioClip _alternateAttackSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, _range, _enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<IDamageable>()?.RecieveDamage(_damage);
        }
        _audioSource.PlayOneShot(_regularAttackSound);
    }

    public void PerformAlternateAttack()
    {
        _audioSource.PlayOneShot(_alternateAttackSound);
        Instantiate(_ball, transform.position, transform.rotation);
        _ball.Damage = _damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
