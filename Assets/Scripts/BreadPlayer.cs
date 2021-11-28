using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadPlayer : MonoBehaviour
{

    public float rotationSpeed = 450.0f;
    private float maxRotationSpeed = Mathf.PI * 150.0f;
    private float maxSpeed = 100.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(FindObjectOfType<Respawner>())
        {
            transform.position = FindObjectOfType<Respawner>().GetBreadPos();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //float rotation = Input.GetAxis("Vertical") * rotationSpeed;
        float rotation = -1.0f * Input.GetAxis("Horizontal") * rotationSpeed;

        rotation *= Time.deltaTime;

        rb.AddTorque(rotation);
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.angularVelocity) >= maxRotationSpeed)
        {
            rb.angularVelocity = maxRotationSpeed * Mathf.Sign(rb.angularVelocity);
        }

        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }


    }
}
