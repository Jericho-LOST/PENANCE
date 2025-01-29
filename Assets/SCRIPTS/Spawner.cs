using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    //create a public array of objects to spawn, we will fill this up using the unity editor 
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn;                  //Tracks long we should wait before spawning a new object
    float timeSinceLastSpawn = 0.0f;        //maximum amount of time between spawning objects

    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 3.0f;

    void Start()
    {
        //random.rage returns a fandom float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}
