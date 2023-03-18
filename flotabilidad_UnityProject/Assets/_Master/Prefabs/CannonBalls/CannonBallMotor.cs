using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMotor : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(transform.forward * _speed,ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            rb.AddExplosionForce(_explosionForce, Vector3.forward, _explosionRadius);
            this.gameObject.SetActive(false);
        }
       
    }
}
