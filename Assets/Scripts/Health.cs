using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public UnityEvent<int, int> OnHealthChanged;
    public UnityEvent OnDeath;
    public bool destroyOnDeath;

    private int health;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChanged.Invoke(health, maxHealth);

        if (health == 0)
        {
            OnDeath.Invoke();
            if (destroyOnDeath) Destroy(gameObject);
        }
    }
}
