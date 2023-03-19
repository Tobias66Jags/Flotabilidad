using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVFX : MonoBehaviour
{
    Rigidbody rb;
    public PlayerController playerController;
    public List<GameObject> sails;

    [SerializeField] ParticleSystem _hurtParticle;
    [SerializeField] private float _velocity=2;
    private void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        SailEffect();

       
    }


    private void SailEffect()
    {      
        if (rb.velocity.magnitude > _velocity)
        {
            Debug.Log("si");
            foreach (var sail in sails)
            {
                sail.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else 
        {
            foreach (var sail in sails)
            {
                sail.transform.localScale = new Vector3(1, 0.2f, 1);
            }
        }
    }


}
