using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;

    public int attackDamage = 10;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<HealthManager>().TakeDamage(attackDamage);
                }

                cooldownTimer = cooldownTime;
            }
        }

        else
        {
            cooldownTimer -= Time.deltaTime; 
        }
    }
}
