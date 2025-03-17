using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Transform target;
    
    void Update()
    {
        if (target != null) transform.LookAt(target);
        
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage); // if health null, don't call TakeDamage
            Destroy(gameObject);
        }
    }
}
