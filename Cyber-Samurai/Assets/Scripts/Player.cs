using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static float movement;

    public float speed;
    public float jumnpForce;
    
    public int health;

    private bool isJumping;
    private bool isAtk;
    
    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        GameController.instance.UpdateLives(health);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Atk();
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine("Attack");
        }
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping && !isAtk)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement < 0)
        {
            if (!isJumping && !isAtk)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (movement == 0 && !isJumping && !isAtk)
        {
            anim.SetInteger("transition", 0);
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
        
        public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        anim.SetTrigger("hit");

        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-2,0,0);
        }    
        
        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(2,0,0);
        }
        
        if (health <= 0)
        {
            //GameController.instance.GameOver(); 
        }

    }
    
    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }
}