using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
      
     
    private Rigidbody rb;

    // Input from script
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float steering = 2f;
    public float dragFactor = 0.1f;

     public float currentSpeed = 0f;

    
    private float speed = 0f;
    private float direction = 0f;
    float extraDrag  = 0f;

    // Die Methode, die beim Start des Skripts aufgerufen wird
    private void Start()
    {
        // Den Rigidbody zuweisen
        rb = GetComponent<Rigidbody>();
    }

private void Update()
{
// Get Input from keyboard 
        float verticalInput = Input.GetAxis("Vertical"); // W oder S
        float horizontalInput = Input.GetAxis("Horizontal"); // A oder D

        // Calcualte speed and direction
        speed += verticalInput * acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        direction += horizontalInput * steering * Time.deltaTime;

// Increase drag depending actual velocity
        float extraDrag = rb.velocity.magnitude * dragFactor;
}
    
    private void FixedUpdate()
    {
        

        // set speed and direction to car 
        rb.velocity = transform.forward * speed;
        rb.MoveRotation(Quaternion.Euler(0, direction, 0));

        if(extraDrag!=0){
        rb.drag = extraDrag;
        }

        // Debug 
        // Set current velocity to rigidbody 
        currentSpeed = rb.velocity.magnitude;
    }

  
}
