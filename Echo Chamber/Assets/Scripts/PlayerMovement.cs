using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = 19.81f;
    public float jumpHeight = 3f;

    public float speed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public string booster;
    public float timer = 10f;

    CharacterController cont;

    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        cont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (booster == "SpeedBoost")
        {
            speed = 18f;
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                booster = "";
                speed = 12f;
                timer = 10f;
            }
        }

        isGrounded = cont.isGrounded;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = (jumpHeight);
        }

        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}