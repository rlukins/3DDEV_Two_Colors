using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController controller;
    public Transform groundCheck;
    public Transform Spider;
    public LayerMask groundMask;
    AudioSource audio;
    AudioClip footstep;
    public float movespeed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    float distToSpider;
    Vector3 velocity;
    bool isGround;
    bool isFollowing;

    void Start() {
        audio = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGround && velocity.y < 0) {
            velocity.y = -2f;
        }
        
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMove + transform.forward * zMove;

        controller.Move(move * movespeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        // Yump logic
        if(Input.GetKeyDown("space") && isGround) {
            velocity.y = Mathf.Sqrt(-6f * gravity);
        }
        // Sprint logic
        if(Input.GetKey(KeyCode.LeftShift)) {
            if(movespeed < 24f) {
                movespeed+= 0.1f;
            }
        } else {
            movespeed = 12f;
        }

        // Following logic
        distToSpider = Vector3.Distance(transform.position, Spider.position);
        if(distToSpider < 20f && !isFollowing) {
            StartCoroutine(MyCoroutine(Spider));
        }

        // Footstep sound
        if(isGround &&
        (Input.GetKey(KeyCode.W) ||
        Input.GetKey(KeyCode.A) ||
        Input.GetKey(KeyCode.S) ||
        Input.GetKey(KeyCode.D))
        ){ 
            PlaySound();
        }
    }

    IEnumerator MyCoroutine(Transform Spider) {
        isFollowing = true;
        while(Vector3.Distance(transform.position, Spider.position) > 5f) {
            Spider.position = Vector3.Lerp(Spider.position, transform.position, 0.5f * Time.deltaTime); // zirnekļa pos = no zirnekļa pos līdz player pos, step = puse no frametime
            yield return null;
        }
        isFollowing = false;
    }

    void PlaySound() {
        if(!audio.isPlaying) {
            audio.Play();
        }
    }
}
