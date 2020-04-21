using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBulletController : MonoBehaviour
{
    public float speed; 
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border") 
        {
            Destroy   (gameObject);
        }
        else if(other.tag == "Player")
        {
            UIScript.currentHealth -= 10;
            if(UIScript.currentHealth <= 0)
            {
                PlayerController.alive = false;
                Instantiate(explosion, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
