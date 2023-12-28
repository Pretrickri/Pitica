using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform theCamera;

    public float speed = 6f;
    public float viewTurnTime = 0.1f; // the less the faster it will turn
    private float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // moved this from inside if

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + theCamera.eulerAngles.y; //make the angle follow the camera
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, viewTurnTime); //this function smoothes the turns when walking.

            // NOTES
            // when you pass an argument as a ref, you are passing the value's address. So, when the value is changed inside
            // the procedure, it changes outside too.
            //
            // the procedure SmoothDampAngle creates a angle that varies linearly and not abruptaly. So, you input the current angle you are in,
            // the angle you want to achieve, then a reference to the speed you want to turn, which the value should change based on the time that
            // it takes to go from angle to the other, and speaking of which the time the turn should take. Observe that the the velocity doesn't need
            // an initial input since it will be changed within the procedure depending on the turning time.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //move to the direction you're pointing

            controller.Move(movedirection.normalized * speed * Time.deltaTime);
        }


    }
}
