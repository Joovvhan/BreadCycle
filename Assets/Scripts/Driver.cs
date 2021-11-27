using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float speed = 1000.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = speed * 1.0f;
        translation *= Time.deltaTime;
        rb.AddRelativeForce(new Vector2(translation, 0f));
    }
}
