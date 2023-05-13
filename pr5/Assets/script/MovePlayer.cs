using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float gravityDis = 0.4f;

    private float mouseSens = 100f;

    [SerializeField] private Transform camRoot;
    [SerializeField] private Transform graundCheck;
    [SerializeField] private LayerMask graundMask;

    private bool isGrounded;
    private Vector3 velocity;
    private float xRotation;

    private CharacterController player;
    private CharacterStats characterStats;
    private float speed = 3.0f;

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        player = GetComponent<CharacterController>();
        speed = characterStats.BaseMovementSpeed;
    }

    void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(graundCheck.position, gravityDis, graundMask);

        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        player.Move(move * speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if(Input.GetButton("Jump") && isGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    } 
}