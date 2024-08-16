using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float sprintSpeed = 12f;
    public float jumpSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting
    }
    // Update is called once per frame
    void Update()
    {
        //character movment
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //grounded check
        //grounded = Physics.Raycast(transform.position, Vector3.down, )

        

        //character orientation
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

    }
    private void StateHandler()
    {
        //if grounded && Input.GetKey(KeyCode.LeftShift))
        {

        }
    }
}
