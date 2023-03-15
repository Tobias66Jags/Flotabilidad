using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BouyancyBase : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0f;
    public float floatingPower = 15f;

    public float waterHeight = 0f;

    Rigidbody rb;

    bool underwater;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if (difference < 0)
        {
            rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true; SwithState(underwater);
            }
        }
        else if (underwater)
        {
            underwater = false;
            SwithState(underwater);
        }
    }

    void SwithState(bool isUnderwater)
    {
        if(isUnderwater)
        {
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }

    }
}
