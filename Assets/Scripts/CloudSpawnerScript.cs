using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            // Debug.Log("now cloud should spawn");
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(0.9f, 2.5f);
            whereToSpawn = new Vector2(transform.position.x, randY);
            // Debug.Log("new spawn loc: " + whereToSpawn);
            Instantiate(cloud, whereToSpawn, Quaternion.identity);
        }

    }
}