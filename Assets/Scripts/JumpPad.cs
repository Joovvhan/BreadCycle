using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float jumpForce = 30.0f;
    private Vector2 jumpVector;

    // Start is called before the first frame update
    void Start()
    {
        float rot = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;
        jumpVector = new Vector2(-1.0f * jumpForce * Mathf.Sin(rot), jumpForce * Mathf.Cos(rot));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(jumpVector,
                ForceMode2D.Impulse);
        }
    }
}
