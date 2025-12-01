using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance = 0.5f;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // === Damage Settings ===
    [Header("Damage Settings")]
    [SerializeField] private int contactDamage = 10;
    [SerializeField] private float damageCooldown = 1f;
    private float damageTimer = 0f;

    void Update()
    {
        if (player == null) return;

        damageTimer += Time.deltaTime;

        float distance = player.position.x - transform.position.x;
        float absDistance = Mathf.Abs(distance);

        if (absDistance <= detectionRange && absDistance > stopDistance)
        {
            float direction = Mathf.Sign(distance);
            transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);

            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = direction > 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && damageTimer >= damageCooldown)
        {
            Health hp = other.GetComponent<Health>();
            if (hp != null)
            {
                hp.TakeDamage(contactDamage);
            }
            damageTimer = 0f;
        }
    }
}