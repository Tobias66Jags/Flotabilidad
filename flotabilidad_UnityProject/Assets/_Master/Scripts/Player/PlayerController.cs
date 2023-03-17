using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   Rigidbody rb;

    [Header("Player Values")]
    [SerializeField] private float _speed=3;

    [SerializeField] private float _rotationSpeed = 3;
    private float _angleRotate;

    private float movement;
   

  



    void Start()
    {
       rb = GetComponent<Rigidbody>();  
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
      // rb.velocity += Vector3.forward*NewMovement()*_speed;  
        rb.AddForce(transform.forward * NewMovement() * _speed);
        rb.AddTorque(0, NewRotation(), 0);     
    }


    private float NewRotation()
    {
        _angleRotate = Input.GetAxis("Horizontal")*_rotationSpeed;
        return _angleRotate;
    }

    private float NewMovement()
    {
        movement = Input.GetAxis("Vertical");
        return movement;
    }
}
