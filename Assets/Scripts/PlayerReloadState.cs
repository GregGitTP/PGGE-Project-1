using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

public class PlayerReloadState : State
{
    Animator anim;

    float elapTime = 0f;

    public PlayerReloadState(FSM _fsm, Animator _anim) : base(_fsm){
        anim = _anim;
    }

    public override void Enter(){
        Debug.Log("Reloading");

        elapTime = 0f;

        anim.SetTrigger("Reload");
    }

    public override void Exit(){
        Debug.Log("Ready to shoot");

        fsm.GetState(1).currentAmmunitionCount = fsm.GetState(1).maxAmmunitionCount;
    }

    public override void Update(){}

    public override void FixedUpdate(){}

    public override void LateUpdate(){
        if(elapTime >= anim.GetCurrentAnimatorClipInfo(0)[0].clip.length) fsm.SetCurrentState(fsm.GetState(0));
        else elapTime += Time.deltaTime;
    }
}
