using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance = 0.5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Damage Settings")]
    [SerializeField] private int contactDamage = 10;
    [SerializeField] private float damageCooldown = 1f;

    private float damageTimer = 0f;

    private void Update()
    {
        if (player == null) return;

        damageTimer += Time.deltaTime;

        float distance = player.position.x - transform.position.x;

        if (Mathf.Abs(distance) > stopDistance)
        {
            float direction = Mathf.Sign(distance);
            transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);
            transform.localScale = new Vector3(-direction, 1, 1);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && damageTimer >= damageCooldown)
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>();

            if (hp != null)
            {
                hp.TakeDamage(contactDamage);
            }

            damageTimer = 0f; // reset cooldown
        }
    }
}