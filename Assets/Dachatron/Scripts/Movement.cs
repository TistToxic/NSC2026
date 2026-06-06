using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Key Bindings")]
    public KeyCode moveLeftKey  = KeyCode.D;
    public KeyCode moveRightKey = KeyCode.A;
    public KeyCode moveForwardKey  = KeyCode.S;
    public KeyCode moveBackwardKey = KeyCode.W;
    public KeyCode jumpKey      = KeyCode.Space;

    [Header("Movement Settings")]
    public float moveSpeed  = 5f;
    public float jumpForce  = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontal = 0f;

        if (Input.GetKey(moveRightKey))
        {
            horizontal = 1f;
        }

        if (Input.GetKey(moveLeftKey))
        {
            horizontal = -1f;
        }

        float depth = 0f;

        if (Input.GetKey(moveForwardKey))
        {
            depth = 1f;
        }

        if (Input.GetKey(moveBackwardKey))
        {
            depth = -1f;
        }

        Vector3 movement = new Vector3(horizontal, 0f, depth);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
        Vector3 newVelocity = new Vector3(
            movement.x * moveSpeed,
            rb.linearVelocity.y,      
            movement.z * moveSpeed
        );

        rb.linearVelocity = newVelocity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}