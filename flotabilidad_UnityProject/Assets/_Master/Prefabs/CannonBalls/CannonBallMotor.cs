using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMotor : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private float _timer;

    public float maxTime;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer>=maxTime)
        {
            _timer = 0;
            rb.velocity = Vector3.zero;
            this.gameObject.SetActive(false);

        }
        transform.position += transform.forward * _speed*Time.deltaTime;
     

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Explosion();
            rb.velocity = Vector3.zero;   
            this.gameObject.SetActive(false);
        }
       
    }

    void Explosion()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider target in _colliders)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius); 
            }
        }
    }
   
}
