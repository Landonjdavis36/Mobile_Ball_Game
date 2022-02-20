using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    float horizontalMultiplier = 2;
    public float jumpspeed = 10f;
    public float gravityScale = 5;
    public bool jumpReady;
    public float jumpCD = 1.2f;
    public float jumpCDCurrent = 0.0f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (jumpCDCurrent >= jumpCD)
        {
            jumpReady = true;
        }
        else
        {
            jumpCDCurrent += Time.deltaTime;
            jumpCDCurrent = Mathf.Clamp(jumpCDCurrent, 0.0f, jumpCD);
            jumpReady = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpReady)
        {
            rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
            jumpCDCurrent = 0.0f;
        }
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }
}
