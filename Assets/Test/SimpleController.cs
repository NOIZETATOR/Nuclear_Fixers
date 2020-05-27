using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
   //movement speed in units per second
    private float movementSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        GetComponent<Rigidbody2D>().velocity = (transform.forward) * movementSpeed * Time.fixedDeltaTime;
    }
}
