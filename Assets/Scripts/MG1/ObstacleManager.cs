using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager: MonoBehaviour
{
    public GameObject[] obstacles;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float TimePrevSpawn;
    [SerializeField] float spawnTime;


    // Start is called before the first frame update
    void Update()
    {
        if (Time.time > spawnTime && GMaster1.Instance.startG)
        {
            Spawn();
            spawnTime = Time.time + TimePrevSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        int randomobs = Random.Range(0, 3);

        GameObject obs = obstacles[randomobs];

        Instantiate(obs, transform.position + new Vector3(randomX, transform.position.y, 0), transform.rotation);

    }
}
