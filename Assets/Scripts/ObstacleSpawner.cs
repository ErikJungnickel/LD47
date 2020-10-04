using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject spawnPoint;
    public GameObject rotationPoint;

    private float spawnThreshold = 3;
    private float spawnTime = 0;

    private float spawnDescreaseThreshold = 2;
    private float spawnDecreaseTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = spawnThreshold;    
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        spawnDecreaseTime += Time.deltaTime;

        if (spawnDecreaseTime >= spawnDescreaseThreshold)
        {
            spawnDecreaseTime = 0;
            if (spawnThreshold >= 1)
            {
                spawnThreshold -= 0.1f;
            }
        }
        
        if(spawnTime >= spawnThreshold)
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);
            GameObject go = GameObject.Instantiate(obstacles[obstacleIndex], spawnPoint.transform);
            go.transform.parent = rotationPoint.transform;
            spawnTime = 0;
        }
    }
}
