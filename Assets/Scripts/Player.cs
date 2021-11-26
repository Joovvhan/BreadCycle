using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 500.0f;
    public float rotationSpeed = 1500.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        float rotation = Input.GetAxis("Vertical") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //rb.velocity = new Vector2(rb.velocity.x + translation, rb.velocity.y);
        //rb.angularVelocity = rb.angularVelocity + rotation;

        rb.AddRelativeForce(new Vector2(translation, 0f));
        rb.AddTorque(rotation);

        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);
    }
}
