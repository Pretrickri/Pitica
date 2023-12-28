using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTest : MonoBehaviour
{
    CharacterController _control;
    Vector3 moveDirection;
    private bool landed;

    public float gravity = -0.5f;
    public float jumpHeight = 50f;
    public float speed = 5f;

    void Awake()
    {
        _control = GetComponent<CharacterController>();
    }

   
    void Update() //TODO : fix weird physics
    {

        /* READ MOVEMENT */
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), moveDirection.y, Input.GetAxisRaw("Vertical")).normalized; //how to normalize this bro?

        ApplyGravity();

        if (Input.GetKey(KeyCode.Space) && _control.isGrounded) ApplyJump(); // JUMP

        ApplyMovement();
    }

    void ApplyJump()
    {
        moveDirection.y = 0f;
        moveDirection.y = jumpHeight;
    }

    void ApplyGravity()
    {
        if (_control.isGrounded) moveDirection.y = -3f;
        else moveDirection.y += gravity;
    }

    void ApplyMovement()
    {
        _control.Move(moveDirection * Time.deltaTime);
    }
}
