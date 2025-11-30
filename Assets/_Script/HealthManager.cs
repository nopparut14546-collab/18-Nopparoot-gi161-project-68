using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //public HealthBar healthbar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
            Debug.Log("enemy dead");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
