using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    Animator animator;

    private void OnTriggerEnter(Collider other) {
        animator.SetBool("isClose", true);
        Debug.Log("Player in skeleton proximity");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Got animator: " + animator);
    }

    void Update()
    {

    }

}
