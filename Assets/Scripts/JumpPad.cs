using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 30.0f;
    private Vector2 jumpVector;
    private float rot;

    // Start is called before the first frame update
    void Start()
    {
        rot = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;
        //jumpVector = new Vector2(-1.0f * jumpForce * Mathf.Sin(rot), jumpForce * Mathf.Cos(rot));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            float relativeRot = Mathf.Deg2Rad * collision.transform.rotation.eulerAngles.z - rot;
            float y = Mathf.Max(Mathf.Abs(Mathf.Sin(relativeRot)), Mathf.Abs(Mathf.Cos(relativeRot)));
            float x = GetX(relativeRot, y);
            jumpVector = new Vector2(jumpForce * x, jumpForce * y);
            jumpVector = rotate(jumpVector, rot);
            //Debug.Log(new Vector2(x, y));
            //Debug.Log(jumpVector.magnitude);
            //Debug.Log(relativeRot);
            //Debug.Log(rot);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(jumpVector,
                ForceMode2D.Impulse);
        }
    }

    static float GetX(float relativeRot, float y)
    {
        int q = Mathf.FloorToInt(relativeRot / (Mathf.PI / 2));
        //float r = relativeRot - q * (Mathf.PI / 2);
        //float mag = Mathf.Min(Mathf.Sin(r), Mathf.Sin(r));
        float mag = Mathf.Sqrt(1 - Mathf.Pow(y, 2));

        float sign;
        if ((q + 4) % 2 == 0) {
            sign = +1.0f;
        }
        else
        {
            sign = -1.0f;
        }

        //Debug.Log(r);
        //Debug.Log(sign);
        return sign * mag;
    }

    static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
