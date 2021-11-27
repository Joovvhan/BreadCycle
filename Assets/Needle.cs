using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    [SerializeField] float timeToWait;
    [SerializeField] float timeToChangeState;
    float timePassed;

    bool isStarted = false;

    Animator animator;
    bool isHiding = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (!isStarted)
        {
            if (timePassed >= timeToWait)
            {
                isStarted = true;
                timePassed = 0;
            }
        }
        else
        {
            if (timePassed >= timeToChangeState)
            {
                timePassed = 0;

                isHiding = !isHiding;
                animator.SetBool("isHiding", isHiding);
            }
        }
    }
}
