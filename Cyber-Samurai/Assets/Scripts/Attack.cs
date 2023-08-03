using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private BoxCollider2D colliderAttack;
    public int damage;
    void Start()
    {
        colliderAttack = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Player.movement < 0)
        {
            transform.localEulerAngles = new Vector3(-0.6f, 0, 0);
        }
        else if (Player.movement > 0)
        {
            transform.localEulerAngles = new Vector3(0.6f, 0, 0);
        } 
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(damage);
        }
    }
}
