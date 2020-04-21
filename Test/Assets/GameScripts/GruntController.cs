using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntController : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed;
    GameObject target;
    public GameObject explosion;
    public GameObject explosion2;
    public Transform firePoint;
    public GameObject gruntBullet;
    public float nextFire = 2f;
    public float currTime = 0.0f;
    public static int gruntAmt = 10;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("PlayerShip");
        rb = GetComponent<Rigidbody2D> ();
        moveSpeed = Random.Range(1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveGrunt();
        gruntShoot();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border") 
        {
            Destroy   (gameObject);
        }
        else if(other.tag == "Bullet")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            UIScript.totalScore += gruntAmt;
            EnemySpawnerController.currentPoints += gruntAmt;
        }
        else if(other.tag == "Player")
        {
            //EnemySpawnerController.spawnAllowed = false;
            //PlayerController.alive = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            //Instantiate(explosion2, other.transform.position, Quaternion.identity);
            //Destroy(other.gameObject);
            UIScript.currentHealth -= 20;
            if(UIScript.currentHealth <= 0)
            {
                PlayerController.alive = false;
                Instantiate(explosion, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }

    void MoveGrunt()
    {
        rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
    }

    public void gruntShoot()
    {
        currTime += Time.deltaTime;

        if(currTime > nextFire)
        {
            nextFire += currTime;
            Instantiate(gruntBullet, firePoint.position, Quaternion.identity);
        }
    }
}
