using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static float movement;

    public float speed;
    public float jumnpForce;

    private bool isJumping;
    private bool isAtk;
    
    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Atk();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");
        

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition",1);
            }
           
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition",1); 
            }
           
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movement == 0 && !isJumping && !isAtk)
        {
            anim.SetInteger("transition",0);
        }
        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0,jumnpForce * 2), ForceMode2D.Impulse);
                isJumping = true;
            }
            
        }
    }
    
    void Atk()
        {
            StartCoroutine("Attack");
        }
    
        IEnumerator Attack()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isAtk = true;
                anim.SetInteger("transition", 3);
                
                yield return new WaitForSeconds(0.5f);
                isAtk = false;
                anim.SetInteger("transition", 0);
            }
        }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 6)
        {
            isJumping = false;
        }

    }
}