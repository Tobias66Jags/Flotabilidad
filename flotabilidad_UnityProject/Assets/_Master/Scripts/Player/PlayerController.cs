using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public ShootManager shoot;


    Rigidbody rb;

    [Header("Player Values")]
    [SerializeField] private float _speed=3;
    [SerializeField] private float _rotationSpeed = 3;


    [Header("Shoot Values")]
    [SerializeField] private float _camRotationValue = 60;
    [SerializeField] private float _timeBetweenShoots = 2;
    [SerializeField] private float _currentTime = 0;
    [SerializeField] private Transform _leftReference;
    [SerializeField] private Transform _rightReference;
    [SerializeField] private CinemachineVirtualCamera vCam;

    [Header("Physic Values")]
    [SerializeField] private float _knockBackForce=10;
    
    private float _angleRotate;

    private float _movement;
    
  



    void Start()
    {
       
 
        rb = GetComponent<Rigidbody>();  
    }

    void FixedUpdate()
    {

        rb.AddForce(transform.forward * NewMovement() * _speed);
        rb.AddTorque(0, NewRotation(), 0);     
    }
    private void Update()
    {
         _currentTime += Time.deltaTime;
        var body = vCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        if (Input.GetButtonDown("Fire1")&& body.m_XAxis.Value<=-_camRotationValue)
        {
            StartCoroutine(shoot.ShootBall(_leftReference));
            rb.AddForce(new Vector3(1,2,0) * _knockBackForce);
            _currentTime = 0;
        }
        else if (Input.GetButtonDown("Fire1") && body.m_XAxis.Value >= _camRotationValue)
        {
            StartCoroutine(shoot.ShootBall(_rightReference));
            rb.AddForce(new Vector3(-1,2,0)*_knockBackForce);
            _currentTime = 0;
        }
    }

    private float NewRotation()
    {
        _angleRotate = Input.GetAxis("Horizontal")*_rotationSpeed;
        return _angleRotate;
    }

    private float NewMovement()
    {
        _movement = Input.GetAxis("Vertical");
        return _movement;
    }
}
