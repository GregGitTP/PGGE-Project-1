using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using PGGE;

public class Vampire : MonoBehaviour
{
    FSM fsm = new FSM();
    State moveState, attackState, reloadState;

    private void Start(){

    }

    private void Update(){
        fsm.Update();
    }

    private void FixedUpdate(){
        fsm.FixedUpdate();
    }

    private void LateUpdate(){
        fsm.LateUpdate();
    }
}
