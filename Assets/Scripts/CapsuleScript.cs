using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{
    protected Vector3 movementVariation = new Vector3(10, 0, 0);
    float smoothness = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //capsule moves side to side until it reaches the edge of the screen
        //created to fullfil vector math requirement
        if (transform.position.x > 47)
        {
            movementVariation = new Vector3(-10, 0, 0);
        }
        if (transform.position.x < -47)
        {
            movementVariation = new Vector3(10, 0, 0);
        }

        transform.position = Vector3.Lerp(transform.position, transform.position + movementVariation, Time.deltaTime * smoothness);

    }
}
