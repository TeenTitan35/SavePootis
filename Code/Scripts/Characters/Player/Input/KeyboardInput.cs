using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputService
{
    private const string _jumpButton = "Jump";
    private const KeyCode _runButton = KeyCode.LeftShift;
    private const int _regularAttackId = 0;
    private const int _alternateAttackId = 1;

    private HashSet<InputAction> _requestedActions = new HashSet<InputAction>();

    public bool GetActionPressed(InputAction action)
    {
        return _requestedActions.Contains(action);
    }

    public float GetAxis(Axis axis)
    {
        return Input.GetAxisRaw(axis.ToUnityAxis());
    }

    private void Update()
    {
        CaptureInput();
    }

    private void CaptureInput()
    {
        if (Input.GetButtonDown(_jumpButton))
            _requestedActions.Add(InputAction.Jump);
        if (Input.GetButtonUp(_jumpButton))
            _requestedActions.Remove(InputAction.Jump);

        if (Input.GetKey(_runButton))
            _requestedActions.Add(InputAction.Run);
        if (Input.GetKeyUp(_runButton))
            _requestedActions.Remove(InputAction.Run);

        if(Input.GetMouseButtonDown(_regularAttackId))
            _requestedActions.Add(InputAction.RegularAttack);
        if (Input.GetMouseButtonUp(_regularAttackId))
            _requestedActions.Remove(InputAction.RegularAttack);

        if (Input.GetMouseButtonDown(_alternateAttackId))
            _requestedActions.Add(InputAction.AlternateAttack);
        if (Input.GetMouseButtonUp(_alternateAttackId))
            _requestedActions.Remove(InputAction.AlternateAttack);
    }
}