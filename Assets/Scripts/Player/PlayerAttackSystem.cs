using System;
using UnityEngine;

public class PlayerAttackSystem : PlayerSystem //hereda de playerSystem
{
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask whatIsDamageable;
    
    private Animator animator;

    private float timer;
    protected override void Awake() 
    {
        base.Awake(); //primero ejecuto el awake de la clase padre ...
        //Ahora escribo lo que quiera en el awake
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if(Input.GetMouseButtonDown(0) && timer >= cooldown)
        {
            animator.SetTrigger("Attack");
            timer = 0f;
        }
    }
    
    //METODO QUE SE INVOCA DESDE UN EVENTO DE ANIMACION
    private void AttackHits()
    {
        Collider2D result = Physics2D.OverlapCircle(attackPoint.position, attackRadius, whatIsDamageable);

        if (result != null) // hay algo?
        {
            if (result.GetComponent<IDahable>() != null) //es dañable?
            {
                //daño
                if (result.TryGetComponent(out IDahable dahable)) //mirame si esto que tengo delante tiene la interfaz y si la tiene pilla el game component y dale daño
                {
                    dahable.TakeDamage(gameObject, 20f);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }
}
