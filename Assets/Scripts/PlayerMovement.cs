using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float rotationSpeed = 240f;
    public float runMultiplier = 2f;

    [SerializeField] CharacterController cc;
    [SerializeField] Animator anim;

    bool running = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) running = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) running = false;

        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        if (running && !(vert < 0)) vert *= runMultiplier;

        Vector3 move = transform.forward * vert * movementSpeed;

        anim.SetFloat("PosX", hori/2);
        anim.SetFloat("PosY", vert/2);

        transform.Rotate(0f, hori*rotationSpeed*.3f*Time.deltaTime, 0f);
        cc.Move(move*Time.deltaTime);
    }
}
