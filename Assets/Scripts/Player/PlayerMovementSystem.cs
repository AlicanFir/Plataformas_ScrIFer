using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementSystem : PlayerSystem
{
    private float hInput;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;

    protected override void Awake() // awake siempre será lo primero que se realice -- all lo que sea tuyo en el awake
    {
        base.Awake(); //awake del padre
        //Ahora mi awake
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Jump();
        Movement();
    }

    private void Movement()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        
        animator.SetFloat("xSpeed", math.abs(hInput));
        animator.SetFloat("ySpeed", rb.linearVelocityY);
        
        if (hInput < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (hInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        main.ActualizaMovimiento(hInput); //se lo mando al mediador
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(hInput, 0) * movementForce, ForceMode2D.Force);
    }
}
