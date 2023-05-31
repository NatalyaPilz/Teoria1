using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7;
    [SerializeField]private float jumpForce = 14;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
       
    }

    private void UpdateAnimationState()
    {

        if (dirX > 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
            
        }

        else if (dirX < 0)
        {

            anim.SetBool("running", true);
            sprite.flipX = true;

        }

        else
        {
            anim.SetBool("running", false);
        }

    }
}
