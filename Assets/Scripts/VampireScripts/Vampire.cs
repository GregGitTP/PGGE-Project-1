using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using PGGE;

public class Vampire : MonoBehaviour
{
    [Header("Component references")]
    public Transform camera;
    public Transform player;
    public CharacterController cc;
    public Animator anim;

    [Header("Values for character movement")]
    [Space(10)]
    public float movementSpeed = 2f;
    public float rotationSpeed = 240f;
    public float runMultiplier = 2f;
    public float gravity = -20f;
    public float jumpForce = 8f;

    [Header("The X, Z and Z axis offsets for the third person camera")]
    public float xOffset;
    public float yOffset;
    public float zOffset;

    FSM fsm = new FSM();
    State moveState, attackState, reloadState;

    private void Start(){
        moveState = new VampireMovementState(fsm, camera, player, this, cc, anim, movementSpeed, rotationSpeed, runMultiplier, gravity, jumpForce, xOffset, yOffset, zOffset);

        fsm.Add(0, moveState);

        fsm.SetCurrentState(moveState);
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
