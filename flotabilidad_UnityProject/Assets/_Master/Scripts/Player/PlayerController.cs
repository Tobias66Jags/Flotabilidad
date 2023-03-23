using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public ShootManager shoot;
    public Health health;

    Rigidbody rb;

    [Header("Player Values")]
    [SerializeField] private float _speed=3;
    [SerializeField] private float _rotationSpeed = 3;


    [Header("Shoot Values")]
    [SerializeField] public float _currentTime = 0;

    [SerializeField] private float _camRotationValue = 60;
    [SerializeField] private float _timeBetweenShoots = 2;
    [SerializeField] private Transform _leftReference;
    [SerializeField] private Transform _rightReference;
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private GameObject _shootIndicator;

    [Header("Physic Values")]
    [SerializeField] private float _knockBackForce=10;
    
    private float _angleRotate;

    private float _movement;

    [Header("Death")]
    public UnityEvent onDeath;


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
        if (body.m_XAxis.Value<=-_camRotationValue || body.m_XAxis.Value>=_camRotationValue)
        {
            _shootIndicator.SetActive(true);
        }
        else { _shootIndicator.SetActive(false); }
        if (Input.GetButtonDown("Fire1")&& body.m_XAxis.Value<=-_camRotationValue&& _currentTime>= _timeBetweenShoots)
        {
            StartCoroutine(shoot.ShootBall(_leftReference));
            rb.AddForce(new Vector3(1,2,0) * _knockBackForce);
            _currentTime = 0;
        }
        else if (Input.GetButtonDown("Fire1") && body.m_XAxis.Value >= _camRotationValue && _currentTime >= _timeBetweenShoots)
        {
            StartCoroutine(shoot.ShootBall(_rightReference));
            rb.AddForce(new Vector3(-1,2,0)*_knockBackForce);
            _currentTime = 0;
        }
        if (health.maxHealth<=0)
        {
            onDeath.Invoke();
            Cursor.lockState = CursorLockMode.None;
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
