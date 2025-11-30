using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public float jumpForce = 10f;
    public float groundedTolerance = 0.05f;

    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.linearVelocity = new Vector2(moveHorizontal, rb.linearVelocity.y);
        //Debug.Log(moveHorizontal);

        if (moveHorizontal != 0)
        {
            transform.localScale = new Vector3(moveHorizontal < 0 ? 1 : -1, 1, 1);
        }

        bool isGrounded = Mathf.Abs(rb.linearVelocity.y) < groundedTolerance;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}