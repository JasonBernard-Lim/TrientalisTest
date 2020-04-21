using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBulletController3 : MonoBehaviour
{
    public float speed; 

    // Update is called once per frame
    void Update()
    {
         GetComponent<Rigidbody2D>().velocity = new Vector2(-1, speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border") 
        {
            Destroy   (gameObject);
        }
        else if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
