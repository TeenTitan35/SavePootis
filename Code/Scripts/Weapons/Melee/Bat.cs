using UnityEngine;

public class Bat : MonoBehaviour, IAlternateAttackWeapon
{
    [SerializeField] private float _range;
    [SerializeField] private float _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private LayerMask _enemyLayer;

    public float FireRate => _fireRate;

    public void PerformAlternateAttack()
    {
        throw new System.NotImplementedException();
    }

    public void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, _range, _enemyLayer);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<IDamageable>()?.RecieveDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
