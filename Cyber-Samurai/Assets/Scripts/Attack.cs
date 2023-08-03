using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;

    private BoxCollider2D coliderAtkPlayer;
    // Start is called before the first frame update
    void Start()
    {
        coliderAtkPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.movement < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        else if (Player.movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Enemy")
        {
            collsion.GetComponent<Enemy>().Damage(damage);
        }
    }
}