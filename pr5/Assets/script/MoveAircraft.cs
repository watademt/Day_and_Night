using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private bool canJump = true;
    public float jumpCooldown = 2.0f;

    public float speed = 3.0f;
    public float maxSpeed = 6.0f;
    public float rotationSpeed = 360.0f;
    public float jumpForce = 1.0f;
    public float gravity = 9.8f;
    public float hoverHeight = 2.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // �������� ���� �� ����������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �������� ���� �� ����
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationX, 0f);

        // ��������� ���� ��� ����������� � �������������� � ������������ ����������
        Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        rb.AddRelativeForce(movement * speed);

        // ����������� ��������
        Vector3 clampedVelocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.velocity = clampedVelocity;

        // ������������� ��� ������� ������� ������
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(EnableJump());
        }


        float distanceToGround = hoverHeight;
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, hoverHeight))
        {
            distanceToGround = hit.distance;
        }

        float verticalVelocity = rb.velocity.y;


        float adjustment = Mathf.Clamp((hoverHeight - distanceToGround) * 0.3f, 0, 1) * jumpForce;
        rb.AddRelativeForce(Vector3.up * adjustment, ForceMode.Impulse);
    }

    IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

}
