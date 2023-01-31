using System;
using System.Collections;
using UnityEngine;

public class SentryTurret : MonoBehaviour, IDamageable
{
    [Header("Combat")]
    [SerializeField] private float _damage;
    [SerializeField] private float _rangeOfView;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private MachineGun _weapon;
    [SerializeField] private bool _facingRight;

    [Header("Health and damaging")]
    [SerializeField] private float _health;
    [SerializeField] private float _timeToBlink;
    [SerializeField] private Color _stockColor;
    [SerializeField] private Color _damagedColor;
    private SpriteRenderer _spriteRenderer;

    private StateRunner _stateRunner;

    public event Action OnSentryDown;
    public event Action OnSentryShoot;

    private void Start()
    {
        _stateRunner = new StateRunner(new IdleState());
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _weapon = GetComponentInChildren<MachineGun>();
        Physics2D.queriesStartInColliders = false;
    }

    private void OnDisable()
    {
        OnSentryDown?.Invoke();
    }

    private void Update()
    {
        _stateRunner.CurrentState.Update();

        if (SearchPlayer() && _stateRunner.CurrentState is IdleState)
            _stateRunner.ChangeState(new AttackState(_weapon, OnSentryShoot));

        if (SearchPlayer() == false && _stateRunner.CurrentState is AttackState)
            _stateRunner.ChangeState(new IdleState());
    }

    public void RecieveDamage(float damage)
    {
        _health -= damage;
        StartCoroutine(nameof(BlinkAfterDamaging));
        if (_health <= 0)
            Destroy(gameObject);
        
    }

    public IEnumerator BlinkAfterDamaging()
    {
        _spriteRenderer.color = _damagedColor;
        yield return new WaitForSeconds(_timeToBlink);
        _spriteRenderer.color = _stockColor;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + (_facingRight ? Vector3.right : Vector3.left) * _rangeOfView);
    }

    private bool SearchPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _facingRight ? Vector2.right : Vector2.left, _rangeOfView);
        if (hit)
        {
            if (hit.collider.GetComponent<PlayerCombat>())
                return true;
        }
        return false;
    }
}
