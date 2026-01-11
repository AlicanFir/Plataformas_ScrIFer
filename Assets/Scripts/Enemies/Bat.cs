using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour, IDahable
{
    [SerializeField] private float health;
    [SerializeField] private AudioClip hitSound;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; //asegurarme que empiezo sin fisicas
    }
    
    public void TakeDamage(GameObject dealer, float damage)
    {
        Vector3 knockBackDirection = transform.position - dealer.transform.position;
        knockBackDirection.y = 0;
        
        StartCoroutine(KnockBack(knockBackDirection));
        
        health -= damage;
        if (health <= 0)
        {
            GameManager.instance.SavedScore += 100;
            Destroy(gameObject);
        }
    }

    private IEnumerator KnockBack(Vector3 knockBackDirection)
    {
        //Debug.Log("KnockBack");
        rb.linearVelocity = Vector3.zero; // cancelo la velocidad
        rb.bodyType = RigidbodyType2D.Dynamic; //ahora tengo fisicas
        rb.AddForce(knockBackDirection.normalized * 10f, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(0.15f);
        
        rb.linearVelocity = Vector3.zero; // cancelo la velocidad
        rb.bodyType = RigidbodyType2D.Kinematic; // volvemos a no tener fisicas
        AudioManager.instance.PlaySFX(hitSound);
    }
}
