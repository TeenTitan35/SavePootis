using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private IAlternateAttackWeapon _weapon;

    private void Start()
    {
        _weapon = GetComponentInChildren<IAlternateAttackWeapon>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _weapon.PerformAttack();

        if (Input.GetMouseButtonDown(1))
            _weapon.PerformAlternateAttack();
    }
}
