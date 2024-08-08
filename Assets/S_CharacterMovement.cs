using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float walkSpeed = 6f;
    public float sprintSpeed = 12f;
    public float jumpSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    /*[SerializeField] */
    private Vector3 previousPos;
    /*[SerializeField] */
    private int movingStatusTracker = 0;
    /*[SerializeField] */ 
    private float movementSpeed;
    /*[SerializeField] */
    private int buffer = 0;
    private Rigidbody rb;
    private bool jumpBuffer = false;


    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting
    }
    void Start()
    {
        if (previousPos == null)
        {
            previousPos = transform.position;
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            //Debug.Log(rb);
        }
        //Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !jumpBuffer)
        {
            rb.AddForce(transform.up * 500f);
            jumpBuffer = true;
        }

        else
        {
            jumpBuffer = false;
        }


        if (!(buffer < 200))
        {
            //Debug.Log((Vector3.Distance(transform.position, previousPos)));
            if (Vector3.Distance(transform.position, previousPos) != 0f)
            {
                movingStatusTracker += 1;
            }
            else
            {
                movingStatusTracker = 0;
            }
            buffer = 0;
            previousPos = transform.position;
        }
        else
        {
            buffer += 1;
        }





        //character movment
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //grounded check
        //grounded = Physics.Raycast(transform.position, Vector3.down, );

        if (movingStatusTracker >= 20)
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }
        

        //character orientation
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);

        }

    }
    private void StateHandler()
    {
        //if grounded && Input.GetKey(KeyCode.LeftShift))
        //{

        //}
    }
}
