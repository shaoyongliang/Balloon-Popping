using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D coll;
    Animator anim;
    SpriteRenderer sprite;
    float movement;
    [SerializeField] LayerMask jumpableGround;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    enum movementState {idle,running,jumping,falling }

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(movement * moveSpeed, rigid.velocity.y);

        if (Input.GetButtonDown("Jump")&&IsGrounded())
        {
            rigid.velocity = new Vector3(rigid.velocity.x,jumpForce);
        }

        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        movementState state;

        if (movement > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        else if (movement < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (rigid.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        else if (rigid.velocity.y < -.1f)
        {
            state = movementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag( "MainCamera") ) // or if(gameObject.CompareTag("YourWallTag"))
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
