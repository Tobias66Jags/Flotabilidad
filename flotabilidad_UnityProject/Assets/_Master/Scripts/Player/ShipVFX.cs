using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVFX : MonoBehaviour
{
    public Rigidbody rb;
    public Health health;  
    public List<GameObject> sails;
    public GameObject[] damageParticles = new GameObject[3]; 
    [SerializeField] private float _velocity=2;
   
    private void Update()
    {
        SailEffect();
        HurtEffects();
    }


    private void SailEffect()
    {      
        if (rb.velocity.magnitude > _velocity)
        {
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
    private void HurtEffects()
    {
     
        if (health.maxHealth<=70)
        {
            damageParticles[0].SetActive(true);
        }
        else
        {
            damageParticles[0].SetActive(false);
        }
        
        if (health.maxHealth<=40)
        {
            damageParticles[0].SetActive(false);
            damageParticles[1].SetActive(true);
          //  damageParticles[2].SetActive(false);
        }

        else
        {
            damageParticles[1].SetActive(false);
        }
        if (health.maxHealth<=20)
        {
           // damageParticles[0].SetActive(false);
         //   damageParticles[1].SetActive(false);
            damageParticles[2].SetActive(true);
        }
        else
        {
            damageParticles[2].SetActive(false);
        }
    }


}
