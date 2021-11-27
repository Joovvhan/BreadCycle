using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform target;
    private float speed = 3;
    private bool move;
    private bool stop;
    private Vector3 tarPos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        tarPos = target.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop & move)
        {
            Vector3 displacement = tarPos - transform.position;
            displacement.z = 0;
            float distance = displacement.magnitude;

            //float step = speed * Time.deltaTime;
            //Vector3 newPosition = Vector3.MoveTowards(transform.position, tarPos, step);
            //transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

            rb.velocity = displacement.normalized * speed;

            if (distance < 0.05f)
            {
                stop = true;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = true;
        }
    }

}
