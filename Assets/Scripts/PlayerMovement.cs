using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Unity References")]
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("References")]
    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpSpeed = 14f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * moveSpeed, rigidbody2D.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpSpeed);
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        if(dirX > 0f) {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f) {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }

        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
