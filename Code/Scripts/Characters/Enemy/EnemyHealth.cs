using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private Unit _unit;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private float _health;

    public event Action OnUnitDown;

    private void Start()
    {
        _health = _unit.Config.Health;    
    }

    public void RecieveDamage(float damage)
    {
        _health -= damage;
        StartCoroutine(VisualizeDamage());
        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnUnitDown?.Invoke();
    }

    public IEnumerator VisualizeDamage()
    {
        _spriteRenderer.color = _unit.Config.DamagedColor;
        yield return new WaitForSeconds(_unit.Config.TimeToBlink);
        _spriteRenderer.color = _unit.Config.DefaultColor;
    }
}
