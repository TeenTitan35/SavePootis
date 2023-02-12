using System.Collections;

public interface IDamageable
{
    void RecieveDamage(float damage);
    IEnumerator VisualizeDamage();
}
