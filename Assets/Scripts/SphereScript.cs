using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    float thrust = 15;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(Vector3.back * forceAmount, ForceMode.Impulse);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
