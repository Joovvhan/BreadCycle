using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLiner : MonoBehaviour
{

    LineRenderer lineRender;
    // Start is called before the first frame update
    void Start()
    {

        Vector3 start = transform.Find("MovingPlatform").transform.position;
        Vector3 end = transform.Find("Target").transform.position;
        lineRender = GetComponent<LineRenderer>();
        Vector3[] positions = new Vector3[2];
        positions[0] = start;
        positions[1] = end;
        lineRender.SetPositions(positions);
        lineRender.startColor = Color.grey;
        lineRender.endColor = Color.grey;
        lineRender.startWidth = 0.05f;
        lineRender.endWidth = 0.05f;

        float width = lineRender.startWidth;
        lineRender.material.mainTextureScale = new Vector2(1f / width / 2, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
