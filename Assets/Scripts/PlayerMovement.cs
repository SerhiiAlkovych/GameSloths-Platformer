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

    private enum MovementState {idle, running, jumping, falling}
    private MovementState mState = MovementState.idle;
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
        MovementState mState;
        if(dirX > 0f) {
            mState = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f) {
            mState = MovementState.running;
            spriteRenderer.flipX = true;
        }

        else
        {
            mState = MovementState.idle;
        }

        if(rigidbody2D.velocity.y > .1f) {
            mState = MovementState.jumping;
        }
        else if (rigidbody2D.velocity.y < -.1f)
        {
            mState = MovementState.falling;
        }

        animator.SetInteger("mState", ((int)mState));
    }
}
