using UnityEngine;

[RequireComponent(typeof(IInputService))]
public class PlayerCombat : MonoBehaviour
{
    private IInputService _input;
   
    [SerializeField] private Bat _bat;
    
    private void Start()
    {
        _input = GetComponent<IInputService>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _bat.PerformAttack();

        if (_input.GetActionPressed(InputAction.AlternateAttack))
            _bat.PerformAlternateAttack();
    }
}
