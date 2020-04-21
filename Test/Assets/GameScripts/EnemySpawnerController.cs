using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject grunt;
    int randomSpawnPoint;
    public static bool spawnAllowed;

    public float spawnInterval = 2f;
    public float currentSpawnTime = 0;
    public static int currentPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {

        currentSpawnTime += Time.deltaTime;
        if(spawnAllowed)
        {
            if(currentSpawnTime >= spawnInterval)
            {
                SpawnGrunt();
                currentSpawnTime = 0;
            }

            if(currentPoints >= 500)
            {
                spawnInterval -= .1f;
                currentPoints = 0;
                //increase grunt point amount
                GruntController.gruntAmt += 5;
            }
        }

    }
    void SpawnGrunt()
    {
        if(spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(grunt, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
