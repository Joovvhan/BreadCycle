using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    public float distanceLimit = 5.0f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = target.position - transform.position;
        displacement.z = 0;
        float distance = displacement.magnitude;
        if (distance > distanceLimit)
        {
            float step = speed * Time.deltaTime;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, step);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
