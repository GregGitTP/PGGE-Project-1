using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

public class PlayerAttackState : State
{
    Transform player;
    Animator anim;

    public PlayerAttackState(FSM _fsm, Transform _player, Animator _anim) : base(_fsm){
        player = _player;
        anim = _anim;
    }

    public override void Enter(){}

    public override void Exit(){}

    public override void Update(){

    }

    public override void FixedUpdate(){}

    public override void LateUpdate(){}
}
