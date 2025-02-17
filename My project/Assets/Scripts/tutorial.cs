using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    
    public float moveSpeed = 2f; // Velocidad de movimiento
    private bool movingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = movingRight ? 1 : -1;
        transform.eulerAngles = new Vector3(0, movingRight ? 0 : 180, 0);
        animator.SetBool("Walking", true);
        rigidbody2D.velocity = new Vector2(direction * moveSpeed, rigidbody2D.velocity.y);
    }
}
