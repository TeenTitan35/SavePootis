using System.Collections;

public interface IDamageable
{
    public void RecieveDamage(float damage);
    public IEnumerator BlinkAfterDamaging();
}