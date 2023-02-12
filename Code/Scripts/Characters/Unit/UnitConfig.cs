using UnityEngine;

[CreateAssetMenu(fileName ="New unit", menuName = "New SO/Default Unit")]
public class UnitConfig : ScriptableObject
{
    [Header("Health & damaging")]
    [SerializeField] protected float _health;
    [SerializeField] protected float _timeToBlink;
    [SerializeField] protected Color _defaultColor;
    [SerializeField] protected Color _damagedColor;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    public float Health => _health;
    public float TimeToBlink => _timeToBlink;
    public Color DefaultColor => _defaultColor;
    public Color DamagedColor => _damagedColor;
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
}
