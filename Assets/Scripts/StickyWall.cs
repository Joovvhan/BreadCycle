using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyWall : MonoBehaviour
{
    public float stickyness = 2.0f * 9.8f;
    private Vector2 stickyVector;
    // Start is called before the first frame update
    void Start()
    {
        float rot = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;
        stickyVector = new Vector2(+1.0f * stickyness * Mathf.Sin(rot),
                                 -1.0f * stickyness * Mathf.Cos(rot));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Vector2 contact = collision.GetContact(0).point;

        List<Vector2> contactVectors = new List<Vector2>();
        foreach (ContactPoint2D contact in collision.contacts)
        {
            contactVectors.Add(contact.point);
        }

        float x = 0;
        float y = 0;

        foreach (Vector2 position in contactVectors)
        {
            x += position.x;
            y += position.y;
        }

        x /= contactVectors.Count;
        y /= contactVectors.Count;


        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log(new Vector4(x, y, contactVectors.Count));
            Vector2 contactPoint = new Vector2(x, y);
            //Debug.Log(stickyVector);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(stickyVector, contactPoint);
        }
    }
}
