using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2 : MonoBehaviour 
{
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    private float verticalInput;

    void FixedUpdate()
    {

        verticalInput = Input.GetAxis("Vertical");
       // verticalInput = Mathf.Clamp(verticalInput, 0, 1);

        float translation = verticalInput * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}