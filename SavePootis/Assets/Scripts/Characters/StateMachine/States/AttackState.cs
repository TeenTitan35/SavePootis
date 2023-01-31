using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AttackState : State
{
    private IWeapon _weapon;
    public event Action _someEvent;

    public AttackState(IWeapon weapon)
    {
        _weapon = weapon;
    }
    public AttackState(IWeapon weapon, Action action)
    {
        _weapon = weapon;
        _someEvent = action;
    }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        _weapon.PerformAttack();
        _someEvent?.Invoke();
    }
}
