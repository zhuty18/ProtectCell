using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed ;
    public float jumpforce;
    public Animator Anim; 
    public Collider2D coll;
    public LayerMask ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        
        float hztMove = Input.GetAxis("Horizontal");
        float dir = Input.GetAxisRaw("Horizontal");

        //fox animation 
        Anim.SetFloat("running" , Mathf.Abs(dir));

        //deltatime for 不同电脑兼容 

        //Move
        if(hztMove != 0 ) rb.velocity = new Vector2(hztMove * speed * Time.deltaTime, rb.velocity.y);
        if(dir != 0)transform.localScale = new Vector3(dir,1,1); 


        //Jump
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        { rb.velocity = new Vector2(rb.velocity.x, jumpforce* Time.deltaTime);
        
        }
    }
}
