using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadPlayer : MonoBehaviour
{

    public float rotationSpeed = 50.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Vertical") * rotationSpeed;

        rotation *= Time.deltaTime;

        rb.AddTorque(rotation);
    }
}
