using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb2d;
    Animator anim;
    bool directionToRight = true;
    public float heroSpeed;
    public float jumpForce;
    public bool grounded;
    public Transform startPoint;
    BoxCounter boxCounter;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        grounded = true;
        boxCounter = GameObject.Find("Manager").GetComponent<BoxCounter>();
    }

    void Update() {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("DeadCactus"))
        {
            rb2d.velocity = Vector2.zero;
            return;

        }
        
        float horizontalMove = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        rb2d.velocity = new Vector2(horizontalMove*heroSpeed, rb2d.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space)&&grounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("jump");
            grounded = false;
        }

        if (horizontalMove < 0 && directionToRight )
        {
            Flip();
        }
        if (horizontalMove > 0 && directionToRight==false)
        {
            Flip();
        }

    }


    void Flip()
    {
        directionToRight = !directionToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    private void OnTriggerEnter2D()
    {

        grounded = true;

    }

    public void RestartHero()
    {
        gameObject.transform.position = startPoint.position;
       // boxCounter.ResetCounter();
    }

}
