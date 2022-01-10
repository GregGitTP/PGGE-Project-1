using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float rotationSpeed = 240f;
    public float runMultiplier = 2f;
    public float gravity = -20f;
    public float jumpForce = 8f;

    [SerializeField] CharacterController cc;
    [SerializeField] Animator anim;

    Vector3 velocity = Vector3.zero;
    bool running = false;
    bool jump = false;
    bool crouch = false;

    private void Update()
    {
        HandleInputs();
        Move();
    }

    private void FixedUpdate(){
        ApplyGravity();
    }

    private void HandleInputs(){
        if (Input.GetKeyDown(KeyCode.LeftShift)) running = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) running = false;
        if(Input.GetKeyDown(KeyCode.Space)) jump = true;
        if(Input.GetKeyUp(KeyCode.Space)) jump = false;
        if(Input.GetKeyDown(KeyCode.Tab)){
            crouch = !crouch;
            Crouch();
        }  
    }

    private void Move(){
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        if (running && !(vert < 0)) vert *= runMultiplier;

        Vector3 move = transform.forward * vert * movementSpeed;

        cc.Move(move*Time.deltaTime);

        transform.Rotate(0f, hori*rotationSpeed*.3f*Time.deltaTime, 0f);

        anim.SetFloat("PosX", hori/2);
        anim.SetFloat("PosY", vert/2);

        if(jump && anim.GetCurrentAnimatorStateInfo(0).IsName("GroundMovement")) StartCoroutine(Jump()); 
    }

    private void ApplyGravity(){
        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);

        if(cc.isGrounded && velocity.y < 0f) velocity.y = 0f;
    }

    private IEnumerator Jump(){
        anim.SetTrigger("Jump");
        yield return new WaitForSeconds(.2f);
        velocity.y += jumpForce;
    }

    private void Crouch(){
        anim.SetBool("Crouch", crouch);
    }
}


