using System;
using UnityEngine;

public class Slime : MonoBehaviour, IDahable
{
    [SerializeField] private float health;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; //asegurarme que empiezo sin fisicas
    }
    
    public void TakeDamage(GameObject dealer, float damage)
    {
        Vector3 knockBackDirection = dealer.transform.position - transform.position;
        
        
        KnockBack(knockBackDirection);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void KnockBack(Vector3 knockBackDirection)
    {
        rb.bodyType = RigidbodyType2D.Dynamic; //ahora tengo fisicas
        rb.AddForce(knockBackDirection * 10f, ForceMode2D.Impulse);
        
    }
    
    
}
