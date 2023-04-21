using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]


public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;

    [field: SerializeField]
    public MovementData MovementDataS { get; set; }

    [SerializeField]
    protected float currentVelocity = 3;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }


    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent (Vector2 movementInput)
    {

        movementDirection = movementInput;
        currentVelocity = CalculateSpeed(movementInput);
    
       

        if (movementInput.magnitude > 0)
        {
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);

    }

    private float CalculateSpeed(Vector2 movementInput)
    {
      if(movementInput.magnitude > 0)
        {
            currentVelocity += MovementDataS.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementDataS.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementDataS.maxSpeed);

    }

   

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);


        rigidbody2d.velocity = currentVelocity * movementDirection.normalized;


    }
}
