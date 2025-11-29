using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.linearVelocity = new Vector2(moveHorizontal, rb.linearVelocity.y);
        Debug.Log(moveHorizontal);

        if (moveHorizontal != 0)
        {
            spriteRenderer.flipX = moveHorizontal > 0;
        }
    }
}