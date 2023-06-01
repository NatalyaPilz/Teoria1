using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouvement : MonoBehaviour//INHERITANCE
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    
    [SerializeField] private LayerMask jumpableGround;// ENCAPSULATION
    [SerializeField] private Text fruitsText;
    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7;// ENCAPSULATION
    [SerializeField]private float jumpForce = 14;// ENCAPSULATION

    private enum MovementsState { idle, running, jumpping, falling }

    private int score;

    // Start is called before the first frame update
    void Start()
    {

       
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
                
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
       
    }

    private void UpdateAnimationState() //ABSTRACTION
    {
        MovementsState state;

        if (dirX > 0)
        {
            state = MovementsState.running;
            sprite.flipX = false;
            
        }

        else if (dirX < 0)
        {

            state = MovementsState.running;
            sprite.flipX = true;

        }

        else
        {
            state = MovementsState.idle;
        }

        if(rb.velocity.y> .1f)
        {
            state = MovementsState.jumpping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementsState.falling;
        }


        anim.SetInteger("state", ((int)state));
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    


}
